using UnityEngine;

public class EntryPoint : MonoBehaviour
{

    private void Awake()
    {
        InitializeUIWindows();
        InitializeUIManager();
        InitializeSubWindows();
        InitializePlayerMovement();
        InitializeHintShower();
        Debug.Log("Entry point awake is over");
    }

    private void Start()
    {
        LateInitializePlayerMovement();
        LateInitializeUIManagers();
        LateInitializeInteractRay();

        Debug.Log("Entry point start is over");
    }

    //Initialization
    private void InitializeUIManager() 
    {
        (FindAnyObjectByType(typeof(UIManager)) as UIManager).Initialize();
        Debug.Log("Entry point UI manager initialization is over");
    }

    private void InitializeSubWindows()
    {
        SubWindowManager[] subWindowManagers = GameObject.FindObjectsByType<SubWindowManager>(0);

        foreach (SubWindowManager subWindow in subWindowManagers)
        {
            subWindow.Initialize();
            Debug.Log($"Entry point UI subwindow {subWindow.gameObject.name} initialized");
        }

        Debug.Log("Entry point SubWindows initialization is over");
    }

    private void InitializeUIWindows()
    {
        UIWindow[] uiWindows = GameObject.FindObjectsByType<UIWindow>(0);

        foreach (UIWindow uiWindow in uiWindows)
        {
            uiWindow.Inititalize();
            Debug.Log($"Entry point UI subwindow {uiWindow.gameObject.name} initialized");
        }
        Debug.Log("Entry point UIWindows initialization is over");
    }

    private void InitializePlayerMovement()
    {
        (FindAnyObjectByType(typeof(FirstPersonController)) as FirstPersonController).Initialize();
        Debug.Log($"Entry point Players movement initialized");
    }

    private void InitializeHintShower()
    {
        (FindAnyObjectByType(typeof(HintShower)) as HintShower).Initialize();
        Debug.Log("Entry point HintShower initialized");
    }

    //Late initialization
    private void LateInitializeInteractRay()
    {
        (FindAnyObjectByType(typeof(InteractRay)) as InteractRay).LateInitialize();
        Debug.Log("Entry point late InteractRay initialized");
    }

    private void LateInitializePlayerMovement()
    {
        (FindAnyObjectByType(typeof(FirstPersonController)) as FirstPersonController).LateInitialize();
        Debug.Log($"Entry point late Players movement initialized");
    }

    private void LateInitializeUIManagers()
    {
        (FindAnyObjectByType(typeof(UIManager)) as UIManager).LateInitialize();
        Debug.Log($"Entry point late UIManagers initialized");
    }
}
