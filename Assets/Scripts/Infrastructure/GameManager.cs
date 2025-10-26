using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IGameManager
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToScene(ScenesEnum scene)
    {
        Debug.Log("SCENE SHOULD BE SWITCHED");
    }
}
