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
    ObjState _currentState;
    GameObject _firstNote;

    enum ObjState
    {
        ready,
        playing,
    }

    private void Start()
    {
        _currentState = ObjState.ready;

        SearchFirstNote();
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

            Debug.Log("������");
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

        }
    }
}
