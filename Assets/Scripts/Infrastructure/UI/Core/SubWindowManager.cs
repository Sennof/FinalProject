using System.Collections.Generic;
using UnityEngine;

public class SubWindowManager : MonoBehaviour, ISubWindowManager
{
    [SerializeField] private List<GameObject> _pages = new();
    [SerializeField] private bool _resetPageOnDisable = true;

    public void Initialize()
    {
        //Initialization 
    }

    private void OnDisable()
    {
        if (_resetPageOnDisable)
            ToPage(0);
    }


    public void ToPage(int index)
    {
        try
        {
            for (int i = 0; i < _pages.Count; i++)
            {
                if (i == index)
                    _pages[i].SetActive(true);
                else
                    _pages[i].SetActive(false);
            }
        }
        catch
        {
            Debug.LogError($"Failed to load page {index} on {name}");
        }
    }
}
