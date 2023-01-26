using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MoveToPlayScene : MonoBehaviour
{
    string _playScene = "PlayScene02";

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => ToPlayScene());
    }

    void ToPlayScene()
    {
        SceneManager.LoadScene(_playScene);
    }
}
