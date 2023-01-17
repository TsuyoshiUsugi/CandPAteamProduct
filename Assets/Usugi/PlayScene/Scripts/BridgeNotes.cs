using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeNotes : MonoBehaviour
{
    float _notesSpeed;
    public float NotesSpeed { get => _notesSpeed; set => _notesSpeed = value; }

    MusicManager _musicManager;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_musicManager.CurrentState == MusicManager.GameState.Playing)
        {
            transform.position -= transform.forward * Time.deltaTime * _notesSpeed;
        }

    }
}
