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

    [SerializeField] private int[] scoreNum;//�m�[�c�̔ԍ������ɓ����
    private int[] scoreBlock;//�m�[�c�̎�ނ����ɓ����
    private int BPM;
    private int LPB;

    [SerializeField] private GameObject notesPre;

    private float moveSpan = 0.01f;
    [SerializeField] private float nowTime;// ���y�̍Đ�����Ă��鎞��
    [SerializeField] private int beatNum;// ���̔���
    private int beatCount;// json�z��p(����)�̃J�E���g
    [SerializeField] private bool isBeat;// �r�[�g��ł��Ă��邩(�����̃^�C�~���O)
    
    [SerializeField] private AudioSource gameAudio;
    public static bool IsAudioPlay = false;


    void Awake()
    {
        MusicReading();

        InvokeRepeating(nameof(NotesIns), 0f, moveSpan);
    }

    /// <summary>
    /// ���ʂ̓ǂݍ���
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
            //�m�[�c������ꏊ������
            scoreNum[i] = inputJson.notes[i].num;
            //�m�[�c�̎�ނ�����(scoreBlock[i]��scoreNum[i]�̎��)
            scoreBlock[i] = inputJson.notes[i].block;
        }
        Debug.Log("ok");

    }

    /// <summary>
    /// ���ʏ�̎��ԂƃQ�[���̎��Ԃ̃J�E���g�Ɛ���
    /// </summary>
    void GetScoreTime()
    {
        //���̉��y�̎��Ԃ̎擾
        nowTime += moveSpan; 

        //�m�[�c�������Ȃ����珈���I��
        if (beatCount > scoreNum.Length) return;

        //�y����łǂ����̎擾
        beatNum = (int)(nowTime * BPM / 60 * LPB); 
    }

    /// <summary>
    /// �m�[�c�𐶐�����
    /// </summary>
    void NotesIns()
    {
        GetScoreTime();

        //json��ł̃J�E���g�Ɗy����ł̃J�E���g�̈�v
        if (beatCount < scoreNum.Length)
        {
            isBeat = (scoreNum[beatCount] == beatNum); //(3)
        }

        //�����̃^�C�~���O�Ȃ�
        if (isBeat)
        {
            //�m�[�c0�̐���
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

    //���Đ��J�n
    void AudioPlay()
    {
        gameAudio.enabled = IsAudioPlay;
        Debug.Log("ok");
    }
}
