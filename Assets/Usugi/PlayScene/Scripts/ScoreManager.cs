using UnityEngine;
using System.Collections.Generic;
using UniRx;
using UnityEngine.SceneManagement;

/// <summary>
/// スコア情報を保持する
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    public string _songName;
    public ReactiveProperty<int> _combo;
    public ReactiveProperty<int> _score;

    public int _perfect;
    public int _great;
    public int _bad;
    public int _miss;

    public const int _perfectScorePoint = 200;
    const int _greatScorePoint = 100;
    const int _badScorePoint = -50;
    const int _missScorePoint = -100;

    [SerializeField] List<ShowSongDateObj> _songList;

    public void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        MusicManager.Instance.CurrentState.Where(state => state == MusicManager.GameState.End).Subscribe(_ => SaveHighScore());
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if(nextScene.name == "PlayScene02")
        {
            Debug.Log("初期化");
            
            _combo.Value = 0;
            _score.Value = 0;
            _perfect = 0;
            _great = 0;
            _bad = 0;
            _miss = 0;
        }
    }

    private void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        _score.Value = 
            _perfectScorePoint * _perfect
            + _greatScorePoint * _great
            + _badScorePoint * _bad
            + _missScorePoint * _miss; 
    }

    private void SaveHighScore()
    {
        foreach (var song in _songList)
        {
            if(song.MusicFilePath == _songName)
            {
                Debug.Log("呼ばれた");

                if(song.HighScore < _score.Value )
                {
                    song.HighScore = _score.Value;
                    Debug.Log("touroku");
                }
            }
        }
    }
}
