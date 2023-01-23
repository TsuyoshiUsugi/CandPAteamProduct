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

    [SerializeField] Button _startButton;
    [SerializeField] string _playScene;

    private void Start()
    {
        if (_startButton == null) return;
        _startButton.onClick.AddListener(() => SceneManager.LoadScene(_playScene));
    }
}
