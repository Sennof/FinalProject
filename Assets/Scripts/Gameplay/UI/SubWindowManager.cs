using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(UIWindow))]
public class SubWindowManager : MonoBehaviour, ISubWindowManager
{
    [SerializeField] private KeyCode _triggerKey = KeyCode.None;

    [SerializeField] private List<GameObject> _pages = new();

    private UIWindow _uiWindow;

    public void Initialize()
    {
        _uiWindow = GetComponent<UIWindow>();
    }

    public void ToPage(int index)
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            if (i == index)
                _pages[i].SetActive(true);
            else
                _pages[i].SetActive(false);
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(_triggerKey))
        {
            if(!_uiWindow.GetState())
                _uiWindow.TurnOn();
            else
                _uiWindow.TurnOff();
        }
    }
}
