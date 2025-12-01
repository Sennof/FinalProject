using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [Header("Main Configuration")]
    public bool EnabledOnStart;

    [SerializeField] private UIWindowsEnum _type;
    [SerializeField] private KeyCode _triggerKey = KeyCode.None;

    [Header("Update Configuration")]
    [SerializeField] private bool _enableManagement; 

    [SerializeField] private bool _canBeClosed;
    [SerializeField] private bool _canBeOpened;

    private GameObject _window;

    public void Initialize()
    {
        _window = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (_enableManagement & Input.GetKeyDown(_triggerKey))
        {
            if (!transform.GetChild(0).gameObject.activeInHierarchy)
            {
                if(_canBeOpened)
                    TurnOn();
            }
            else
            {
                if (_canBeClosed) 
                    TurnOff();
            }
                
        }
    }

    public void TurnOn()
    {
        _window.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;

        EventBus<UIChangeStateEvent>.Raise(new UIChangeStateEvent
        {
            canBeAnyOpened = false,
        });
    }

    public void TurnOff() 
    {
        _window.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        EventBus<UIChangeStateEvent>.Raise(new UIChangeStateEvent
        {
            canBeAnyOpened = true,
        });
    }

    public void SetOpenAvailiableness(bool state)
    {
        _canBeOpened = state;
    }

    public UIWindowsEnum GetWindowType() => _type;

}
