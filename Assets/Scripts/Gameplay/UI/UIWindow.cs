using System.Collections;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [Header("Main Configuration")]
    [SerializeField] private UIWindowsEnum _type;
    [SerializeField] private KeyCode _triggerKey = KeyCode.None;
    [SerializeField] private bool _canBeOpened = false;

    [Header("Update Configuration")]
    [SerializeField] private bool _enableManagement = false;

    [Header("Start Configuration")]
    [SerializeField] private bool _isActiveOnStart = false;
    
    public UIWindowsEnum GetWindowType() => _type;

    private SubWindowManager _subWindowManager;
    private GameObject _window;

    private EventBinding<UIOpenEvent> _eventBinding;

    private Coroutine _coroutine;


    public void Initialize()
    {
        _window = transform.GetChild(0).gameObject;
        _subWindowManager = _window.GetComponent<SubWindowManager>();

        _eventBinding = new EventBinding<UIOpenEvent>(HandleExtraOpenedUI);
        EventBus<UIOpenEvent>.Register(_eventBinding);

        if (_isActiveOnStart)
            TurnOn();
        else
            TurnOff();
    }

    private void OnDisable()
    {
        EventBus<UIOpenEvent>.Deregister(_eventBinding);
    }

    private void Update()
    {
        if (!_enableManagement)
            return;

        if (Input.GetKeyDown(_triggerKey))
        {
            if (!transform.GetChild(0).gameObject.activeInHierarchy)
            {
                if(_canBeOpened)
                    TurnOn();
            }
            else
                TurnOff();
        }
    }

    public void TurnOn()
    {
        _window.SetActive(true);
        _subWindowManager.ToPage(0);

        Cursor.lockState = CursorLockMode.Confined;
        EventBus<UIOpenEvent>.Raise(new UIOpenEvent
        {
            opened = true,
        });
    }

    public void TurnOff() 
    {
        _window.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(EventInvoker());
    }

    private void HandleExtraOpenedUI(UIOpenEvent UIOpenEvent)
    {
        if (_window.activeInHierarchy)
            return;

        if(UIOpenEvent.opened)
            _enableManagement = false;
        else
            _enableManagement = true;
    }

    private IEnumerator EventInvoker()
    {
        yield return new WaitForSeconds(0.5f);

        EventBus<UIOpenEvent>.Raise(new UIOpenEvent
        {
            opened = false,
        });
    }
}
