using System.Collections.Generic;
using UnityEngine;

public class SongDataLoader : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField, Header("�ȃf�[�^�̃��X�g")] List<GameObject> _songDataList;
    [SerializeField] GameObject _songPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (_songDataList.Count == 0) return;

        for (int i = 0; i < _songDataList.Count; i++)
        {
            Instantiate(_songPrefab);
        }
    }

}
