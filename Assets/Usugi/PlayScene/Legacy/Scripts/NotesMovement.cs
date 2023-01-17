using System;
using System.Collections.Generic;
using UnityEngine;

public class NotesMovement : MonoBehaviour
{
    [SerializeField]
    private float notesSpeed;

    [SerializeField]
    private Vector3 startPos;//ノーツの開始位置
    [SerializeField]
    private Vector3 judgePos;//判定したい場所

    public static float moveSpan = 0.01f;//回すスパン 

    private float notesTime;

    void Start()
    {
        notesTime = (startPos.x - judgePos.x) / notesSpeed;
        InvokeRepeating("NotesMove", 0, moveSpan);
    }

    void NotesMove()
    {
        transform.position += new Vector3(0f, 0f, -notesSpeed);
        notesTime -= moveSpan;
        NotesJudge();
    }

    void NotesJudge()
    {
        if (Math.Abs(notesTime) < 0.5f)
        {
            //判定した時の処理を書く 
        }
    }

    private void Update()
    {
        if (notesTime <= 0)//判定位置に来たら
        {
            NotesGenerator.IsAudioPlay = true;
            Debug.Log("kita");
        }
    }
}
