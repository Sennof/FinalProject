using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{

    private void Awake()
    {
        InitializeItems();
        InitializeInventory();
        InitializeInventoryUI();
        InitializeHintShower();

        InitializeInteractables();

        InitializeUIDelieverySideMenu();
        InitializeUIFactories();

        InitializeUIManager();
        InitializeUIWindows();
        InitializeSubWindows();

        InitializeProductDelievery();

        InitializePlayerMovement();

        InitializeUIMoneyBalance();
        InitializeMoneyManager();
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
    #region Global UI
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
            UIWindow[] uiWindows = FindObjectsByType<UIWindow>(0);

            foreach (UIWindow uiWindow in uiWindows)
            {
                uiWindow.Initialize();
                Debug.Log($"Entry point UI window {uiWindow.gameObject.name} initialized");
            }
            Debug.Log("Entry point UIWindows initialization is over");
        }
        catch
        {
            Debug.LogError("Failed to initialize UIWindows | EntryPoint");
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

    private void InitializeUIFactories()
    {
        try
        {
            UIFactoryBase[] factories = FindObjectsByType<UIFactoryBase>(0);
            foreach (UIFactoryBase factory in factories)
            {
                factory.Initialize();
            }

            Debug.Log("EntryPoint initialized UIFactories");
        }
        catch
        {
            Debug.LogError("Failed to initialize UIFactories | EntryPoint");
        }
    }
    #endregion

    #region PlayerMovement
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
    #endregion

    #region Inventory & Items
    private void InitializeItems()
    {
        try
        {
            ItemBase[] items = FindObjectsByType<ItemBase>(0);

            foreach (ItemBase item in items)
            {
                item.Initialize();
                Debug.Log($"Entry point initialized Item {item.name}");
            }
            Debug.Log("Entry point HintShower initialized");
        }
        catch
        {
            Debug.LogError("Failed to initialize HintShower | EntryPoint");
        }
    }

    private void InitializeInventory()
    {
        try
        {
            (FindAnyObjectByType(typeof(Inventory)) as Inventory).Initialize();
            Debug.Log("Entry point Inventory initialized");
        }
        catch
        {
            Debug.LogError("Failed to initialize Inventory | EntryPoint");
        }
    }

    private void InitializeInteractables()
    {
        try
        {
            Interactable[] interactables = FindObjectsByType<Interactable>(0);

            foreach (Interactable interactable in interactables)
            {
                interactable.Initialize();
                Debug.Log($"Entry point initialized interactable {interactable.name}");
            }
            Debug.Log("Entry point initialized Interactables | EntryPoint");
        }
        catch
        {
            Debug.LogError($"Failed to initialize Interactables | EntryPoint");
        }
    }
    #endregion

    #region UI
    private void InitializeInventoryUI()
    {
        try
        {
            (FindAnyObjectByType(typeof(InventoryUI)) as InventoryUI).Initialize();
            Debug.Log("EntryPoint initialized InventoryUI");
        }
        catch
        {
            Debug.LogError("Failed to initialize InventoryUI | EntryPoint");
        }
    }

    private void InitializeUIDelieverySideMenu()
    {
        try
        {
            DelieverySideMenu menu = FindAnyObjectByType<DelieverySideMenu>().GetComponent<DelieverySideMenu>();
            menu.Initialize();
            Debug.Log("EntryPoint intialized UIDelieverySideMenu");
        }
        catch
        {
            Debug.LogError("Failed to intialize UIDelieverySideMenu | EntryPoint ");
        }
    }

    private void InitializeUIMoneyBalance()
    {
        try
        {
            UIMoneyBalance[] uiMoneyBalances = GameObject.FindObjectsByType<UIMoneyBalance>(0);

            foreach (UIMoneyBalance balance in uiMoneyBalances)
            {
                balance.Initialize();
                Debug.Log($"Entry point initialized: {balance.gameObject.name}");
            }
        }
        catch
        {
            Debug.Log("Failed to initialize UIMoneyBalances | EntryPoint");
        }
    }
    #endregion

    #region ProductDelievery
    private void InitializeProductDelievery()
    {
        try
        {
            FindAnyObjectByType<ProductDelievery>().Initialize();
            Debug.Log("EntryPoint initialized ProductDelievery");
        }
        catch
        {
            Debug.Log("Failed to initialize ProductDelievery | EntryPoint");
        }
    }
    #endregion

    #region Money
    private void InitializeMoneyManager()
    {
        try
        {
            FindAnyObjectByType<MoneyManager>().Initialize();
            Debug.Log("EntryPoint initialized MoneyManager");
        }
        catch
        {
            Debug.Log("Failed to initialize MoneyManager | EntryPoint");
        }
    }
    #endregion

    //Late initialization
    #region InteractRay
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
    #endregion

    #region PlayerMovement
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
    #endregion

    #region Global UI
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
    #endregion
}
