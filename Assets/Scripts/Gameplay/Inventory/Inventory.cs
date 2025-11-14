using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
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

    public EventBinding<ItemPickUpEvent> _eventBinding;

    public GameObject[] _keptItemObjects = new GameObject[2];
    public ItemBase[] _keptItemBases = new ItemBase[2];

    public int _currentItemSlotIndex = 0;

    private void OnDisable()
    {
        EventBus<ItemPickUpEvent>.Deregister(_eventBinding);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_throwTriggerey))
            ThrowObj();

        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            if (_keptItemObjects[_currentItemSlotIndex] != null)
                _keptItemObjects[_currentItemSlotIndex].SetActive(false);
            
            _currentItemSlotIndex = 1 - _currentItemSlotIndex;

            if (_keptItemObjects[_currentItemSlotIndex] != null)
                _keptItemObjects[_currentItemSlotIndex].SetActive(true);

            _uiController.SelectSlot(_currentItemSlotIndex);
        }
    }

    public void Initialize()
    {
        _eventBinding = new EventBinding<ItemPickUpEvent>(HandlePickUp);
        EventBus<ItemPickUpEvent>.Register(_eventBinding);


        if (_handsFolder == null || _playgroundFolder == null)
            Debug.LogError($"There is not enough data for normal operation | {name}");
    }

    public void HandlePickUp(ItemPickUpEvent eventData)
    {
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

        _uiController.SetIcon(_keptItemBases[_currentItemSlotIndex].Icon, _currentItemSlotIndex);
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
        }
    }
}
