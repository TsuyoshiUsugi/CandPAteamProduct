using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowResult : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] Text _rankText;

    // Start is called before the first frame update
    void Start()
    {
        _rankText.gameObject.SetActive(false);
        var resultSequence = DOTween.Sequence();

        resultSequence
            .AppendCallback(() => ShowResultPoint())
            .AppendCallback(() => ShowResultRank());      
    }

    void ShowResultPoint()
    {
        int num = 0;
        int score = ScoreManager.Instance._score.Value;

        DOTween.To
            (
                () => num,
                (x) => num = x,
                score,
                1f
            )
            .OnUpdate(() => _scoreText.text = $"SCORE:{num.ToString("00000")}");
    }

    void ShowResultRank()
    {
        _rankText.gameObject.SetActive(true);
        _rankText.text = JudgeRunk();
    }

    string JudgeRunk()
    {
        var notesNum = BridgeNotesGenerator.NotesNum;
        var scoreLimit = notesNum * ScoreManager._perfectScorePoint;
        int score = ScoreManager.Instance._score.Value;

        if(score == scoreLimit)
        {
            return "S";
        }
        else if(scoreLimit > score && score >= scoreLimit * 3/4)
        {
            return "A";
        }
        else if(scoreLimit * 3/4 > score && score >= scoreLimit * 2/4)
        {
            return "B";
        }
        else
        {
            return "C";
        }
    }
}
