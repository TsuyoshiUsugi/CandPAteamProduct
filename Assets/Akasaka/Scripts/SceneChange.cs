using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickSelect()
    {
        SceneManager.LoadScene("SongSelectScene");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
