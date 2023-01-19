using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 曲のスクリプタブルオブジェクト
/// 
/// 曲名
/// 音源のファイルパス
/// 譜面のファイルパス
/// 難易度
/// ハイスコア
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
