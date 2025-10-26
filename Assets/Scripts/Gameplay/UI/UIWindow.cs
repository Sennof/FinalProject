using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private UIWindowsEnum _type;
    [SerializeField] private KeyCode _triggerKey = KeyCode.None;

    public UIWindowsEnum GetWindowType() => _type;

    private SubWindowManager _subWindowManager;
    private GameObject _window;

    public void Update()
    {
        if (Input.GetKeyUp(_triggerKey))
        {
            if (!transform.GetChild(0).gameObject.activeInHierarchy)
                TurnOn();
            else
                TurnOff();
        }
    }

    public void Inititalize()
    {
        _window = transform.GetChild(0).gameObject;
        _subWindowManager = _window.GetComponent<SubWindowManager>();
    }

    public void TurnOn()
    {
        if (_triggerKey != KeyCode.None)
        {
            _window.SetActive(true);
            _subWindowManager.ToPage(0);

            Cursor.lockState = CursorLockMode.Confined;
            EventBus<UIOpenEvent>.Raise(new UIOpenEvent
            {
                opened = true,
            });
        }
    }

    public void TurnOff() 
    {
        if (_triggerKey != KeyCode.None)
        {
            _window.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            EventBus<UIOpenEvent>.Raise(new UIOpenEvent
            {
                opened = false,
            });
        }
    }
}
