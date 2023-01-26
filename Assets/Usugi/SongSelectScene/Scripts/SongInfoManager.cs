using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 再生する曲の情報を保持するマネージャー
/// </summary>
public class SongInfoManager : SingletonMonobehavior<SongInfoManager>
{
    [SerializeField] string _songPath = "";
    public string SongPath { get => _songPath; set => _songPath = value; }

    [SerializeField] GuidReference _startButton;
    [SerializeField] string _playScene;

    Scene _songSelectScene;

    private void Start()
    {
        
        _startButton.gameObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(_playScene));
        

        SceneManager.sceneLoaded += SubscribeButtonEvent;
    }

    void SubscribeButtonEvent(Scene scene, LoadSceneMode mode)
    {
        if(scene == _songSelectScene)
        {
            _startButton.gameObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(_playScene));

        }
    }

    private void Update()
    {
        Debug.Log(_songSelectScene.name);
    }
}
