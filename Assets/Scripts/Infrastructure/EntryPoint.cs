using UnityEngine;

public class EntryPoint : MonoBehaviour
{

    private void Awake()
    {
        InitializeItems();

        InitializeUIManager();
        InitializeUIWindows();
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
        try
        {
            (FindAnyObjectByType(typeof(UIManager)) as UIManager).Initialize();
            Debug.Log("Entry point UI manager initialization is over");
        }
        catch
        {
            Debug.LogError("Failed to initialize UIManager | EntryPoint");
        }
    }

    private void InitializeSubWindows()
    {
        try
        {
            SubWindowManager[] subWindowManagers = GameObject.FindObjectsByType<SubWindowManager>(0);

            foreach (SubWindowManager subWindow in subWindowManagers)
            {
                subWindow.Initialize();
                Debug.Log($"Entry point UI subwindow {subWindow.gameObject.name} initialized");
            }

            Debug.Log("Entry point SubWindows initialization is over");
        }
        catch
        {
            Debug.LogError("Failed to initialize SubWindows | EntryPoint");
        }
    }


    private void InitializeUIWindows()
    {
        try
        {
            UIWindow[] uiWindows = GameObject.FindObjectsByType<UIWindow>(0);

            foreach (UIWindow uiWindow in uiWindows)
            {
                uiWindow.Initialize();
                Debug.Log($"Entry point UI subwindow {uiWindow.gameObject.name} initialized");
            }
            Debug.Log("Entry point UIWindows initialization is over");
        }
        catch
        {
            Debug.LogError("Failed to initialize UIWindows | EntryPoint");
        }
    }


    private void InitializePlayerMovement()
    {
        try
        {
            (FindAnyObjectByType(typeof(FirstPersonController)) as FirstPersonController).Initialize();
            Debug.Log($"Entry point Players movement initialized");
        }
        catch
        {
            Debug.LogError("Failed to initialize PlayerMovements | EntryPoint");
        }
    }

    private void InitializeHintShower()
    {
        try
        {
            (FindAnyObjectByType(typeof(HintShower)) as HintShower).Initialize();
            Debug.Log("Entry point HintShower initialized");
        }
        catch 
        {
            Debug.LogError("Failed to initialize HintShower | EntryPoint");
        }
    }

    private void InitializeItems()
    {
        try
        {
            (FindAnyObjectByType(typeof(ItemBase)) as ItemBase).Initialize();
            Debug.Log("Entry point HintShower initialized");
        }
        catch
        {
            Debug.LogError("Failed to initialize HintShower | EntryPoint");
        }
    }

    //Late initialization
    private void LateInitializeInteractRay()
    {
        try
        {
            (FindAnyObjectByType(typeof(InteractRay)) as InteractRay).LateInitialize();
            Debug.Log("Entry point late InteractRay initialized");
        }
        catch
        {
            Debug.LogError("Failed to lateInitialize InteractRay | EntryPoint");
        }
    }

    private void LateInitializePlayerMovement()
    {
        try
        {
            (FindAnyObjectByType(typeof(FirstPersonController)) as FirstPersonController).LateInitialize();
            Debug.Log($"Entry point late Players movement initialized");
        }
        catch
        {
            Debug.LogError("Failed to lateInitialize PlayerMovement | EntryPoint");
        }
    }

    private void LateInitializeUIManagers()
    {
        try
        {
            (FindAnyObjectByType(typeof(UIManager)) as UIManager).LateInitialize();
            Debug.Log($"Entry point late UIManagers initialized");
        }
        catch
        {
            Debug.LogError("Failed to lateInitialize UIManagers | EntryPoint");
        }
    }
}
