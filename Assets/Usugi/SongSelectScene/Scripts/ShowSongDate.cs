using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ȃ̃X�N���v�^�u���I�u�W�F�N�g
/// 
/// �Ȗ�
/// �����̃t�@�C���p�X
/// ���ʂ̃t�@�C���p�X
/// ��Փx
/// �n�C�X�R�A
/// 
/// </summary>
[CreateAssetMenu(fileName = "SongData", menuName = "ScriptableObjects/CreateSongData")]
public class ShowSongDate : ScriptableObject
{
    [SerializeField] string _songName;
    [SerializeField] string _musicFilePath;
    [SerializeField] string _musicSheetPath;
    [SerializeField] int _songDiff;
    [SerializeField] int _highScore;

    public string SongName => _songName;
    public string MusicFilePath => _musicFilePath;
    public string MusicSheetPath => _musicSheetPath;
    public int SongDiff => _songDiff;
    public int HighScore { set => _highScore = value; }
}
