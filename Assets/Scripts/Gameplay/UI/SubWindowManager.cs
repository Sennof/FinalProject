using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SubWindowManager : MonoBehaviour, ISubWindowManager
{
    [SerializeField] private List<GameObject> _pages = new();
    private UIWindow _uiWindow;

    [Inject] private IGameManager _gameManager;

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

    public void QuitGame() => _gameManager.ToScene(0);
}
