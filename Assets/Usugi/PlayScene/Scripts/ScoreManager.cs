using UnityEngine;
using UniRx;

/// <summary>
/// ÉXÉRÉAèÓïÒÇï€éùÇ∑ÇÈ
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

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

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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
}
