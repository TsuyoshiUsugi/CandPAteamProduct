using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SongDataLoader : MonoBehaviour
{
    [Header("参照")]
    [SerializeField, Header("曲データのリスト")] List<ScriptableObject> _songDataList;
    [SerializeField] GameObject _songPrefab;

    string _songDataDir = @"C:\Users\qesul\Documents\CandPAteamProduct\Assets\Resources\SongData";

    // Start is called before the first frame update
    void Start()
    {
        int fileCount = Directory.GetFiles(_songDataDir, "*.asset", SearchOption.TopDirectoryOnly).Length;
        DirectoryInfo di = new System.IO.DirectoryInfo(_songDataDir);
        FileInfo[] files =
            di.GetFiles("*.txt", System.IO.SearchOption.AllDirectories);

        foreach (var file in files)
        {
            //_songDataList.Add((ScriptableObject)file);
        }

        if (_songDataList.Count == 0) return;

        for (int i = 0; i < _songDataList.Count; i++)
        {
            Instantiate(_songPrefab);
        }
    }

}
