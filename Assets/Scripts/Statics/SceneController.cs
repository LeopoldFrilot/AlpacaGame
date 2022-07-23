using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameSO gameData;
    
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
        AudioHub.Instance.PlayClip(gameData.clickMenuSound, gameData.clickMenuSoundVolume);
        SceneManager.LoadScene(GetActiveSceneIndex() + 1);
    }

    public void LoadSplashScene()
    {
        AudioHub.Instance.PlayClip(gameData.clickMenuSound, gameData.clickMenuSoundVolume);
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int buildIndex)
    {
        AudioHub.Instance.PlayClip(gameData.clickMenuSound, gameData.clickMenuSoundVolume);
        SceneManager.LoadScene(buildIndex);
    }

    public void RestartScene()
    {
        AudioHub.Instance.PlayClip(gameData.clickMenuSound, gameData.clickMenuSoundVolume);
        SceneManager.LoadScene(GetActiveSceneIndex());
    }

    public void Quit()
    {
        AudioHub.Instance.PlayClip(gameData.clickMenuSound, gameData.clickMenuSoundVolume);
        Application.Quit();
    }
}