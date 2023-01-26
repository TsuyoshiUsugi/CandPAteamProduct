using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ok");

        var scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager._perfect = 0;
        scoreManager._great = 0;
        scoreManager._bad = 0;
        scoreManager._miss = 0;
        scoreManager._score.Value = 0;
    }
}
