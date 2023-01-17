using System;
using System.Collections.Generic;
using UnityEngine;

public class NotesMovement : MonoBehaviour
{
    [SerializeField]
    private float notesSpeed;

    [SerializeField]
    private Vector3 startPos;//�m�[�c�̊J�n�ʒu
    [SerializeField]
    private Vector3 judgePos;//���肵�����ꏊ

    public static float moveSpan = 0.01f;//�񂷃X�p�� 

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
            //���肵�����̏��������� 
        }
    }

    private void Update()
    {
        if (notesTime <= 0)//����ʒu�ɗ�����
        {
            NotesGenerator.IsAudioPlay = true;
            Debug.Log("kita");
        }
    }
}
