using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneController : MonoBehaviour
{
    [SerializeField] private AudioClip switchSceneSound;
    [SerializeField][Range(0f, 1f)] private float switchSceneSoundVolume = 1f;
    [SerializeField] private AudioClip quitSound;
    [SerializeField][Range(0f, 1f)] private float quitSoundVolume = 1f;
    
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
        AudioHub.Instance.PlayClip(switchSceneSound, switchSceneSoundVolume);
        SceneManager.LoadScene(GetActiveSceneIndex() + 1);
    }

    public void LoadSplashScene()
    {
        AudioHub.Instance.PlayClip(quitSound, quitSoundVolume);
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int buildIndex)
    {
        AudioHub.Instance.PlayClip(switchSceneSound, switchSceneSoundVolume);
        SceneManager.LoadScene(buildIndex);
    }

    public void RestartScene()
    {
        AudioHub.Instance.PlayClip(switchSceneSound, switchSceneSoundVolume);
        SceneManager.LoadScene(GetActiveSceneIndex());
    }

    public void Quit()
    {
        AudioHub.Instance.PlayClip(quitSound, quitSoundVolume);
        Application.Quit();
    }
}