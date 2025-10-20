using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private UIWindowsEnum _type;

    public UIWindowsEnum GetWindowType() => _type;

    public void TurnOn()
    {
        Cursor.lockState = CursorLockMode.Confined;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void TurnOff() 
    { 
        transform.GetChild(0).gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public bool GetState() => transform.GetChild(0).gameObject.activeInHierarchy;
}
