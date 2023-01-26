using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// �v���C�V�[����UI�̕\���������s��
/// </summary>
public class PlaySceneUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.CurrentState.Where(state => state == MusicManager.GameState.Ready).Subscribe(_ => ReadyUI());
    }

    void ReadyUI()
    {
        Debug.Log("mati");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
