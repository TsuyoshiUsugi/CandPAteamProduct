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
        _songSelectScene = SceneManager.GetActiveScene();

        
    }

    private void Update()
    {
        Debug.Log(_startButton.gameObject.GetComponent<Button>().onClick.GetPersistentEventCount());

        if(SceneManager.GetActiveScene() == _songSelectScene)
        {
            if(_startButton.gameObject.GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
            {
                _startButton.gameObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(_playScene));
            }
        }
    }
}
