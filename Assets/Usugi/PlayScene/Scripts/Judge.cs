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
        if (!PlaySceneManager.instance.Start) return;

        if(Input.GetKeyDown(KeyCode.S))
        {
            
            if (_notesManager._laneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
            {
                
                Judgement(Mathf.Abs(Time.time - (_notesManager._notesTime[0] + PlaySceneManager.instance.StartTime)));
            }
        }

        //ミス
        if (Time.time > _notesManager._notesTime[0] + _missTime + PlaySceneManager.instance.StartTime)
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
        switch (timeLag)
        {
            case float when timeLag <= _perfectTime:
                Debug.Log("Perfect");
                message(0);
                PlaySceneManager.instance.perfect++;
                PlaySceneManager.instance.combo++;
                deleteData();
                break;

            case float when timeLag <= _greatTime:
                Debug.Log("Great");
                message(1);
                PlaySceneManager.instance.great++;
                PlaySceneManager.instance.combo++;
                deleteData();
                break;

           case float when timeLag <= _missTime:
                Debug.Log("Bad");
                message(2);
                PlaySceneManager.instance.bad++;
                PlaySceneManager.instance.combo = 0;
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
