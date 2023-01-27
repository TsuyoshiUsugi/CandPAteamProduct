using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

/// <summary>
/// プレイシーンのUIの表示処理を行う
/// </summary>
public class PlaySceneUIManager : MonoBehaviour
{
    [SerializeField] Text _howToStartButton;
    [SerializeField] Text _combCount;
    [SerializeField] Text _scoreCount;
    int _score;

    private void Awake()
    {
        _howToStartButton.gameObject.SetActive(true);
        _combCount.gameObject.SetActive(true);
        _scoreCount.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.CurrentState
            .Where(state => state == MusicManager.GameState.Playing)
            .Subscribe(_ => _howToStartButton.gameObject.SetActive(false)).AddTo(this);

        MusicManager.Instance.CurrentState
            .Where(state => state == MusicManager.GameState.Ready)
            .Subscribe(_ => ReadyUIAnim()).AddTo(this);

        ScoreManager.Instance._combo.Subscribe(comb => CombUICount(comb));
        ScoreManager.Instance._score.Subscribe(score => ScoreUICount(score));

    }

    void ReadyUIAnim()
    {
        _howToStartButton.gameObject.SetActive(true);
        _howToStartButton.DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetLink(_howToStartButton.gameObject);
    }

    void CombUICount(int comb)
    {
        if(comb == 0)
        {
            _combCount.gameObject.SetActive(false);
        }
        else
        {
            _combCount.gameObject.SetActive(true);
            _combCount.text = comb.ToString();
        }
    }

    void ScoreUICount(int score)
    {
        DOTween.To
            (
                () => _score,
                point => _score = point,
                score,
                0.5f
            )
            .OnUpdate(() => _scoreCount.text = $"SCORE:{_score.ToString("00000")}").SetLink(_scoreCount.gameObject);
    }

}
