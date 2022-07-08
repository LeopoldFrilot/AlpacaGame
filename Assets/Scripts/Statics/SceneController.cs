using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Singleton
    private static SceneController _instance;
    public static SceneController Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("SceneController");
                gO.AddComponent<SceneController>().Awake();
            }
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(GetActiveSceneIndex() + 1);
    }

    public void LoadSplashScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(GetActiveSceneIndex());
    }

    public void Quit()
    {
        Application.Quit();
    }
}