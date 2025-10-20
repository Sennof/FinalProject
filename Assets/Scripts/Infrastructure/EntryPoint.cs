using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public void Awake()
    {
        InitializeUIManager();
        InitializeSubWindows();
    }

    public void Start()
    {

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


    //Late initialization
}
