using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] _messageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] BridgeNotesGenerator _notesManager;//スクリプト「notesManager」を入れる変数

    float _perfectTime = 0.1f;
    float _greatTime = 0.15f;
    float _missTime = 0.2f;

    void Update()
    {
        if (MusicManager.Instance.CurrentState != MusicManager.GameState.Playing) return;

        if (!CheckNotes()) return;

        JudgeScore();
        
    }

    /// <summary>
    /// 次に流れるノーツがあるか確認
    /// </summary>
    private bool CheckNotes()
    {
        if (_notesManager._notesTime.Count == 0)
        {
            Debug.Log("もうノーツなし");

            MusicManager.Instance.CurrentState = MusicManager.GameState.End;
            return false;
        }
        return true;
    }

    /// <summary>
    /// 押したタイミングを評価する
    /// </summary>
    private void JudgeScore()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickJudgement(Mathf.Abs(Time.time - (_notesManager._notesTime[0] + MusicManager.Instance.StartTime)));
            return;
        }

        //押されなかった時
        if (Time.time > _notesManager._notesTime[0] + _missTime + MusicManager.Instance.StartTime)
        {
            message(3);
            deleteData();
            Debug.Log("Miss");
            ScoreManager.Instance._miss++;
            ScoreManager.Instance._combo = 0;
        }

        
    }

    void OnClickJudgement(float timeLag)
    {
        switch (timeLag)
        {
            case float when timeLag <= _perfectTime:
                Debug.Log("Perfect");
                message(0);
                ScoreManager.Instance._perfect++;
                ScoreManager.Instance._combo++;
                deleteData();
                break;

            case float when timeLag <= _greatTime:
                Debug.Log("Great");
                message(1);
                ScoreManager.Instance._great++;
                ScoreManager.Instance._combo++;
                deleteData();
                break;

           case float when timeLag <= _missTime:
                Debug.Log("Bad");
                message(2);
                ScoreManager.Instance._bad++;
                ScoreManager.Instance._combo = 0;
                deleteData();
                break;

        }
    }

    void deleteData()
    {
        _notesManager._notesTime.RemoveAt(0);
        _notesManager._laneNum.RemoveAt(0);
        _notesManager._noteType.RemoveAt(0);    
    }

    void message(int judge)
    {
        Instantiate(_messageObj[judge], _messageObj[judge].transform.position, Quaternion.Euler(45, 0, 0));
    }
}
