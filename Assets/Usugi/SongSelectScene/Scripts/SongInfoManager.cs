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

    //private void Start()
    //{
        
    //    _startButton.gameObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(_playScene));

    //    _songSelectScene = SceneManager.GetSceneByName("SongSelectScene");
    //    SceneManager.sceneLoaded += SubscribeButtonEvent;
    //}

    //void SubscribeButtonEvent(Scene scene, LoadSceneMode mode)
    //{
    //    if(scene == _songSelectScene)
    //    {

    //        Debug.Log("ok");
    //        _startButton.gameObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(_playScene));

    //    }
    //}

    public void MoveToPlayScene()
    {
        SceneManager.LoadScene(_playScene);
    }
}
