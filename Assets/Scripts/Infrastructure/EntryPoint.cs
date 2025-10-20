using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public void Awake()
    {
        InitializeUIManager();
        InitializeSubWindows();
        InitializePlayerMovement();
    }

    public void Start()
    {
        LateInitializePlayerMovement();
    }

    //Initialization
    private void InitializeUIManager() 
    {
        GameObject.FindAnyObjectByType(typeof(UIManager)).GetComponent<UIManager>().Initialize();
    }

    private void InitializeSubWindows()
    {
        SubWindowManager[] subWindowManagers = GameObject.FindObjectsByType<SubWindowManager>(0);

        foreach (SubWindowManager subWindow in subWindowManagers)
        {
            subWindow.Initialize();
        }
    }

    private void InitializePlayerMovement()
    {
        FindAnyObjectByType(typeof(FirstPersonController)).GetComponent<FirstPersonController>().Initialize();
    }

    //Late initialization

    private void LateInitializePlayerMovement()
    {
        FindAnyObjectByType(typeof(FirstPersonController)).GetComponent<FirstPersonController>().LateInitialize();
    }
}
