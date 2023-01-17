using System;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    [Serializable]
    public class InputJson
    {
        public Notes[] notes;
        public int BPM;
    }

    [Serializable]
    public class Notes
    {
        public int num;
        public int block;
        public int LPB;
    }

    [SerializeField] private int[] scoreNum;//ノーツの番号を順に入れる
    private int[] scoreBlock;//ノーツの種類を順に入れる
    private int BPM;
    private int LPB;

    [SerializeField] private GameObject notesPre;

    private float moveSpan = 0.01f;
    [SerializeField] private float nowTime;// 音楽の再生されている時間
    [SerializeField] private int beatNum;// 今の拍数
    private int beatCount;// json配列用(拍数)のカウント
    [SerializeField] private bool isBeat;// ビートを打っているか(生成のタイミング)
    
    [SerializeField] private AudioSource gameAudio;
    public static bool IsAudioPlay = false;


    void Awake()
    {
        MusicReading();

        InvokeRepeating(nameof(NotesIns), 0f, moveSpan);
    }

    /// <summary>
    /// 譜面の読み込み
    /// </summary>
    void MusicReading()
    {
        string inputString = Resources.Load<TextAsset>("Test4").ToString();
        InputJson inputJson = JsonUtility.FromJson<InputJson>(inputString);

        scoreNum = new int[inputJson.notes.Length];
        scoreBlock = new int[inputJson.notes.Length];
        BPM = inputJson.BPM;
        LPB = inputJson.notes[0].LPB;

        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            //ノーツがある場所を入れる
            scoreNum[i] = inputJson.notes[i].num;
            //ノーツの種類を入れる(scoreBlock[i]はscoreNum[i]の種類)
            scoreBlock[i] = inputJson.notes[i].block;
        }
        Debug.Log("ok");

    }

    /// <summary>
    /// 譜面上の時間とゲームの時間のカウントと制御
    /// </summary>
    void GetScoreTime()
    {
        //今の音楽の時間の取得
        nowTime += moveSpan; 

        //ノーツが無くなったら処理終了
        if (beatCount > scoreNum.Length) return;

        //楽譜上でどこかの取得
        beatNum = (int)(nowTime * BPM / 60 * LPB); 
    }

    /// <summary>
    /// ノーツを生成する
    /// </summary>
    void NotesIns()
    {
        GetScoreTime();

        //json上でのカウントと楽譜上でのカウントの一致
        if (beatCount < scoreNum.Length)
        {
            isBeat = (scoreNum[beatCount] == beatNum); //(3)
        }

        //生成のタイミングなら
        if (isBeat)
        {
            //ノーツ0の生成
            if (scoreBlock[beatCount] == 0)
            {
                AudioPlay();
                Instantiate(notesPre);
            }
            else
            {
                Instantiate(notesPre);
            }

            beatCount++; //(5)
            isBeat = false;

        }
    }

    //音再生開始
    void AudioPlay()
    {
        gameAudio.enabled = IsAudioPlay;
        Debug.Log("ok");
    }
}
