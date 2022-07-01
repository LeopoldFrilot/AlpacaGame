using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(GetActiveSceneIndex() + 1);
    }

    public static void LoadSplashScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(GetActiveSceneIndex());
    }

    public static void Quit()
    {
        Application.Quit();
    }
}