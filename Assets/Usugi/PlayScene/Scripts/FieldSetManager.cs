using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// �t�B�[���h�ݒ�p�̃X�N���v�g
/// ���\�̂��߂̂ЂƂ܂��̃X�N���v�g
/// </summary>
public class FieldSetManager : MonoBehaviour
{
    [SerializeField] GameObject _lofiField;
    [SerializeField] GameObject _fancyField;
    [SerializeField] string _lofiSongName;
    [SerializeField] string _fancySongName;

    private void Start()
    {
        var songName = SongInfoManager.Instance.SongPath;

        if(songName == _lofiSongName)
        {
            SetLofiField();
        }
        else if(songName == _fancySongName)
        {
            SetFancyField();
        }
        else
        {
            SetFancyField();
            SetLofiField();
        }
    }

    public void SetLofiField()
    {
        _lofiField.SetActive(true);
        _fancyField.SetActive(false);
    }

    public void SetFancyField()
    {
        _fancyField.SetActive(true);
        _lofiField.SetActive(false);
    }
}
