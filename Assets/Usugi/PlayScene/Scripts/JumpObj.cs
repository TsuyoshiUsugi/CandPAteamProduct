using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ジャンプするキャラのスクリプト
/// 
/// 機能
/// 最初は一番目のノーツの位置に生成し、一緒に流れてくる
/// 
/// ジャンプボタンが押されたらジャンプ
/// 次の橋が来たら着地
/// ミスしたら溺れる
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

            Debug.Log("検索中");
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
