using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] _messageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] BridgeNotesManager _notesManager;//スクリプト「notesManager」を入れる変数

    void Update()
    {
        if (!PlaySceneManager.instance.Start) return;

        if(Input.GetKeyDown(KeyCode.S))
        {
            Judgement(Mathf.Abs(Time.time - _notesManager._notesTime[0] + PlaySceneManager.instance.StartTime));

        }

        //ミス
        if (Time.time > _notesManager._notesTime[0] + 0.2f + PlaySceneManager.instance.StartTime)
        {
            message(3);
            deleteData();
            Debug.Log("Miss");
            PlaySceneManager.instance.miss++;
            PlaySceneManager.instance.combo = 0;
        }
    }
    void Judgement(float timeLag)
    {
        if (timeLag <= 0.10)
        {
            Debug.Log("Perfect");
            message(0);
            PlaySceneManager.instance.perfect++;
            PlaySceneManager.instance.combo++;
            deleteData();
        }
        else
        {
            if (timeLag <= 0.15)
            {
                Debug.Log("Great");
                message(1);
                PlaySceneManager.instance.great++;
                PlaySceneManager.instance.combo++;
                deleteData();
            }
            else
            {
                if (timeLag <= 0.20)
                {
                    Debug.Log("Bad");
                    message(2);
                    PlaySceneManager.instance.bad++;
                    PlaySceneManager.instance.combo = 0;
                    deleteData();
                }
            }
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
