using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] _messageObj;//�v���C���[�ɔ����`����Q�[���I�u�W�F�N�g
    [SerializeField] BridgeNotesGenerator _notesManager;//�X�N���v�g�unotesManager�v������ϐ�

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
    /// ���ɗ����m�[�c�����邩�m�F
    /// </summary>
    private bool CheckNotes()
    {
        if (_notesManager._notesTime.Count == 0)
        {
            Debug.Log("�����m�[�c�Ȃ�");

            MusicManager.Instance.CurrentState = MusicManager.GameState.End;
            return false;
        }
        return true;
    }

    /// <summary>
    /// �������^�C�~���O��]������
    /// </summary>
    private void JudgeScore()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickJudgement(Mathf.Abs(Time.time - (_notesManager._notesTime[0] + MusicManager.Instance.StartTime)));
            return;
        }

        //������Ȃ�������
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
