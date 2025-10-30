using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IGameManager
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToScene(int index)
    {
        //SceneManager.LoadScene(index);
        Debug.Log("SCENE SHOULD BE SWITCHED");
    }

    public void ToScene(ScenesEnum index)
    {
        //SceneManager.LoadScene((int)index);
        Debug.Log("SCENE SHOULD BE SWITCHED");
    }
}
