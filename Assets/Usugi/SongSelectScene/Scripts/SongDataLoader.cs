using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リストにあるsongDataをロードして曲選択ボタンを生成する
/// </summary>
public class SongDataLoader : MonoBehaviour
{
    [Header("参照")]
    [SerializeField, Header("曲データのリスト")] List<ShowSongDateObj> _songDataList;
    [SerializeField] GameObject _songPrefab;
    [SerializeField] GameObject _anker;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<Sprite> _songImages;

    [SerializeField] Text _songName;
    [SerializeField] Text _diffCulty;
    [SerializeField] Text _highScore;

    // Start is called before the first frame update
    void Start()
    {
        if (_songDataList.Count == 0) return;

        InstantiateSongSelectButton();

        ShowInfo(0);
    }

    /// <summary>
    /// 曲選択ボタンを生成する
    /// </summary>
    private void InstantiateSongSelectButton()
    {
        for (int i = 0; i < _songDataList.Count; i++)
        {
            GameObject songPrefab = Instantiate(_songPrefab);
            songPrefab.gameObject.transform.SetParent(_anker.transform);

            songPrefab.GetComponent<Image>().sprite = _songImages[i];


            Debug.Log(i);
            int index = i;
            songPrefab.GetComponent<Button>().onClick.AddListener(() => ShowInfo(index));
            songPrefab.GetComponent<Button>().onClick.AddListener(() => _audioSource.Play());
        }
    }

    /// <summary>
    /// 曲選択ボタンが押された時の処理を追加する
    /// </summary>
    void ShowInfo(int index)
    {
        _songName.text = _songDataList[index].SongName;

        _diffCulty.text = ReturnDiffText(index);

        _highScore.text = $"{_songDataList[index].HighScore}pt";

        SongInfoManager.Instance.SongPath = _songDataList[index].MusicFilePath;

        Debug.Log("押された");
    }

    string ReturnDiffText(int index)
    {
        string diff = "";

        for (int i = 0; i < _songDataList[index].SongDiff; i++)
        {
            diff += "★";
        }

        return diff;
    }
}
