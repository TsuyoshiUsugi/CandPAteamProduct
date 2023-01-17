using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    //総ノーツ数
    public int _noteNum;
    //曲名
    [SerializeField] private string songName;

    public List<int> _laneNum = new List<int>();
    public List<int> _noteType = new List<int>();
    public List<float> _notesTime = new List<float>();
    public List<GameObject> _notesObj = new List<GameObject>();

    [SerializeField] private float _notesSpeed;
    [SerializeField] GameObject _noteObj;

    void OnEnable()
    {
        //_noteNum = 0;
        //songName = "テスト";
        Load(songName);
    }

    private void Load(string SongName)
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        _noteNum = inputJson.notes.Length;

        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float duration = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = duration * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset + 0.01f;
            _notesTime.Add(time);
            _laneNum.Add(inputJson.notes[i].block);
            _noteType.Add(inputJson.notes[i].type);

            float z = _notesTime[i] * _notesSpeed;
            _notesObj.Add(Instantiate(_noteObj, new Vector3(inputJson.notes[i].block, 0.55f, z), Quaternion.identity));
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



