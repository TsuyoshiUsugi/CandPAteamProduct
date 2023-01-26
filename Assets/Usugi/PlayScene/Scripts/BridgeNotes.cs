using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeNotes : MonoBehaviour
{
    int _notesNum;
    public int NotesNum { get => _notesNum; set => _notesNum = value; }

    float _notesSpeed;
    public float NotesSpeed { get => _notesSpeed; set => _notesSpeed = value; }

    MusicManager _musicManager;

    [SerializeField] List<GameObject> _notes;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_musicManager.CurrentState.Value == MusicManager.GameState.Playing)
        {
            transform.position -= transform.forward * Time.deltaTime * _notesSpeed;
        }
    }
}
