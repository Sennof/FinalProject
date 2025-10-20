using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    private List<UIWindow> UIWindows = new();

    public void Initialize()
    {
        UIWindow[] windows = FindObjectsByType<UIWindow>(0);
        foreach (UIWindow window in windows)
            UIWindows.Add(window);

        OffWindows();
    }

    public void ToWindow(UIWindowsEnum type)
    {
        OffWindows();
        OnWindow(type);
    }

    public void OffWindows()
    {
        foreach (UIWindow window in UIWindows)
            window.TurnOff();
    }

    public void OnWindow(UIWindowsEnum type)
    {
        UIWindow target = null;
        foreach (UIWindow window in UIWindows)
        {
            if(window.GetWindowType() == type)
            {
                target = window;
                break;
            }
        }

        target.TurnOn();
    }
}
