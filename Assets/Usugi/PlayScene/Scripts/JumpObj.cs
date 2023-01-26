using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �W�����v����L�����̃X�N���v�g
/// 
/// �@�\
/// �ŏ��͈�Ԗڂ̃m�[�c�̈ʒu�ɐ������A�ꏏ�ɗ���Ă���
/// 
/// �W�����v�{�^���������ꂽ��W�����v
/// ���̋��������璅�n
/// �~�X������M���
/// 
/// </summary>
public class JumpObj : MonoBehaviour
{
    [SerializeField] ObjState _currentState;
    public ObjState CurrentState { get => _currentState; set => _currentState = value; }

    BridgeNotesGenerator _bridgeNotesGenerator;

    GameObject _firstNote;

    public enum ObjState
    {
        ready,
        playing,
    }

    private void Start()
    {
        _currentState = ObjState.ready;

        SearchFirstNote();

        GetLandingTime();
    }

    void GetLandingTime()
    {
        BridgeNotesGenerator bridgeNotesGenerator = FindObjectOfType<BridgeNotesGenerator>();

        _bridgeNotesGenerator = bridgeNotesGenerator;
    }

    private void SearchFirstNote()
    {
        var notes = FindObjectsOfType<BridgeNotes>();

        foreach (var note in notes)
        {
            if (note.NotesNum == 0)
            {
                this.transform.position = note.transform.position;
                _firstNote = note.gameObject;
                break;
            }
        }
    }

    private void Update()
    {
        if(_currentState == ObjState.ready)
        {
            if (_firstNote == null) SearchFirstNote();

            gameObject.transform.position = _firstNote.transform.position;
        }
        else if(_currentState == ObjState.playing)
        {
            if(_bridgeNotesGenerator._notesTime.Count == 0)
            {
                GetLandingTime();
 
            }

            if (Mathf.Abs(Time.time - (_bridgeNotesGenerator._notesTime[0] + MusicManager.Instance.StartTime)) <= 0.8 && Mathf.Abs(Time.time - (_bridgeNotesGenerator._notesTime[0] + MusicManager.Instance.StartTime)) > 0)
            {
                //���n��
                transform.position = new Vector3(0, 1, 0);
            }
            else
            {
                transform.position = new Vector3(0, 2, 0);
            }
        }
    }
}
