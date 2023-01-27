using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �Đ�����Ȃ̏���ێ�����}�l�[�W���[
/// </summary>
public class SongInfoManager : SingletonMonobehavior<SongInfoManager>
{
    [SerializeField] string _songPath = "";
    public string SongPath { get => _songPath; set => _songPath = value; }

    [SerializeField] GuidReference _startButton;
    [SerializeField] string _playScene;

    public void MoveToPlayScene()
    {
        SceneManager.LoadScene(_playScene);
    }
}
