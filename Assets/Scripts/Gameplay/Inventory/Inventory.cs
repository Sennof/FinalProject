using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    #region variables
    [Header("UI")]
    [Tooltip("View ñontroller")]
    [SerializeField] private InventoryUI _uiController;

    [Header("Folders")]
    [Tooltip("The character's hands, into which the object will be \"taken\"")]
    [SerializeField] private Transform _handsFolder;
    [Tooltip("Folder of the entire game scene (free position of the object)")]
    [SerializeField] private Transform _playgroundFolder;
    
    [Header("Interaction")]
    [Tooltip("The key for throwing away an object")]
    [SerializeField] private KeyCode _throwTriggerey = KeyCode.Mouse0;
    [Tooltip("The key for droping an object")]
    [SerializeField] private KeyCode _dropTriggerey = KeyCode.Mouse1;

    private EventBinding<ItemPickUpEvent> _itemPickUpEventBinding;
    private EventBinding<UIOpenEvent> _uiOpenEventBinding;

    private GameObject[] _keptItemObjects = new GameObject[2];
    private ItemBase[] _keptItemBases = new ItemBase[2];

    private int _currentItemSlotIndex = 0;

    private bool _enabled = true;
    private Coroutine _cooldownCoroutine = null;

    #endregion

    public void Initialize()
    {
        _itemPickUpEventBinding = new EventBinding<ItemPickUpEvent>(HandlePickUp);
        EventBus<ItemPickUpEvent>.Register(_itemPickUpEventBinding);

        _uiOpenEventBinding = new EventBinding<UIOpenEvent>(HandleUIOpen);
        EventBus<UIOpenEvent>.Register(_uiOpenEventBinding);

        if (_handsFolder == null || _playgroundFolder == null)
            Debug.LogError($"There is not enough data for normal operation | {name}");
    }

    private void Update()
    {
        if (!_enabled)
            return;

        if (Input.GetKeyDown(_throwTriggerey) && _keptItemObjects[_currentItemSlotIndex] != null)
            ThrowObj();

        if (Input.GetKeyDown(_dropTriggerey) && _keptItemObjects[_currentItemSlotIndex] != null)
            DropObj();

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            if (_keptItemObjects[_currentItemSlotIndex] != null)
                _keptItemObjects[_currentItemSlotIndex].SetActive(false);

            _currentItemSlotIndex = 1 - _currentItemSlotIndex;

            if (_keptItemObjects[_currentItemSlotIndex] != null)
                _keptItemObjects[_currentItemSlotIndex].SetActive(true);

            _uiController.SelectSlot(_currentItemSlotIndex);
        }
    }

    private void OnDisable()
    {
        EventBus<ItemPickUpEvent>.Deregister(_itemPickUpEventBinding);
        EventBus<UIOpenEvent>.Deregister(_uiOpenEventBinding);
    }
    private void HandleUIOpen(UIOpenEvent UIOpenEvent)
    {
        if (UIOpenEvent.opened)
            _enabled = false;
        else
            _enabled = true;
    }

    public void HandlePickUp(ItemPickUpEvent eventData)
    {
        if (!enabled)
            return;

        int slotIndex = _currentItemSlotIndex;
        bool isLocalSlotDifferent = false;

        if (_keptItemObjects[_currentItemSlotIndex] != null)
        {
            slotIndex = 1 - _currentItemSlotIndex;
            isLocalSlotDifferent = true;

            if (_keptItemObjects[slotIndex] != null)
            {
                Debug.Log($"Not enough space in inventory | {name}");
                return;
            }
        }

        _keptItemObjects[slotIndex] = eventData.ItemObject;
        _keptItemBases[slotIndex] = eventData.ItemScript;

        _keptItemObjects[slotIndex].transform.SetParent(_handsFolder);
        _keptItemBases[slotIndex].PickUp();

        if(isLocalSlotDifferent)
            _keptItemObjects[slotIndex].SetActive(false);

        _uiController.SetIcon(_keptItemBases[slotIndex].Icon, slotIndex);

        StartCooldown();
    }

    public void ThrowObj()
    {
        if (_keptItemObjects[_currentItemSlotIndex] != null)
        {
            _keptItemBases[_currentItemSlotIndex].transform.SetParent(_playgroundFolder);
            _keptItemBases[_currentItemSlotIndex].Throw();

            _keptItemBases[_currentItemSlotIndex] = null;
            _keptItemObjects[_currentItemSlotIndex] = null;

            _uiController.ClearIcon(_currentItemSlotIndex);

            StartCooldown();
        }
    }

    public void DropObj()
    {
        _keptItemBases[_currentItemSlotIndex].transform.SetParent(_playgroundFolder);
        _keptItemBases[_currentItemSlotIndex].Drop();

        _keptItemBases[_currentItemSlotIndex] = null;
        _keptItemObjects[_currentItemSlotIndex] = null;

        _uiController.ClearIcon(_currentItemSlotIndex);

        StartCooldown();
    }

    public void StartCooldown()
    {
        if(_cooldownCoroutine != null)
            StopCoroutine(_cooldownCoroutine);
        
        _cooldownCoroutine = StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        _enabled = false;
        yield return new WaitForSeconds(0.3f);
        _enabled = true;

        _cooldownCoroutine = null;
    }
}
