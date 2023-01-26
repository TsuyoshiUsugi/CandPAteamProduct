using System;
using System.Collections.Generic;
using UnityEngine;

public class BridgeNotesGenerator : MonoBehaviour
{
    //‘ƒm[ƒc”
    static int _noteNum;
    public static int NotesNum => _noteNum;

    public List<int> _laneNum = new List<int>();
    public List<int> _noteType = new List<int>();
    public List<float> _notesTime = new List<float>();
    public List<GameObject> _notesObj = new List<GameObject>();

    [SerializeField] private float _notesSpeed;

    [SerializeField] GameObject _noteObj;

    [SerializeField] List<GameObject> _notes;

    void Start()
    {
        SetNotesType();

        Load();
    }

    void SetNotesType()
    {
        if(SongInfoManager.Instance.SongPath == "Lofi")
        {
            _noteObj = _notes[0];
        }
        else if(SongInfoManager.Instance.SongPath == "Fancy2")
        {
            _noteObj = _notes[1];
        }
    }

    private void Load()
    {
        string inputString = Resources.Load<TextAsset>(SongInfoManager.Instance.SongPath).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        _noteNum = inputJson.notes.Length;

        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float duration = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = duration * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            _notesTime.Add(time);
            _laneNum.Add(inputJson.notes[i].block);
            _noteType.Add(inputJson.notes[i].type);

            float z = _notesTime[i] * _notesSpeed;

            GameObject notes = Instantiate(_noteObj, new Vector3(inputJson.notes[i].block, 0.55f, z), _noteObj.gameObject.transform.rotation);

            BridgeNotes thisBridgeNotes = notes.GetComponent<BridgeNotes>();
            thisBridgeNotes.NotesSpeed = _notesSpeed;
            thisBridgeNotes.NotesNum = i;

            _notesObj.Add(notes);
        }
    }
}

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;

}

[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}



