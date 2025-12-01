using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    private EventBinding<UIChangeStateEvent> _eventBinding;

    private List<UIWindow> _uiWindows = new();


    public void Initialize()
    {
        _eventBinding = new EventBinding<UIChangeStateEvent>(HandleUIChangeStateEvent);
        EventBus<UIChangeStateEvent>.Register(_eventBinding);

        UIWindow[] windows = FindObjectsByType<UIWindow>(0);
        foreach (UIWindow window in windows)
        {
            _uiWindows.Add(window);
        }
    }

    private void OnDisable()
    {
        EventBus<UIChangeStateEvent>.Deregister(_eventBinding);
    }

    public void LateInitialize() 
    {
        OffWindows();

        foreach (UIWindow window in _uiWindows)
        {
            if (window.EnabledOnStart)
                window.TurnOn();
        }
    }

    public void HandleUIChangeStateEvent(UIChangeStateEvent eventData)
    {
        foreach(UIWindow window in _uiWindows)
        {
                window.SetOpenAvailiableness(eventData.canBeAnyOpened);
        }
    }

    public void ToWindow(int type)
    {
        OffWindows();
        OnWindow((UIWindowsEnum)type);
    }

    public void OffWindows()
    {
        foreach (UIWindow window in _uiWindows)
            window.TurnOff();
    }

    public void OnWindow(UIWindowsEnum type)
    {
        UIWindow target = null;
        foreach (UIWindow window in _uiWindows)
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
