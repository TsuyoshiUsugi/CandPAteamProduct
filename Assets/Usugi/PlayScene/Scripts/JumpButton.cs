using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    [SerializeField] Button _jumpButton;
    // Start is called before the first frame update
    void Start()
    {
        _jumpButton.onClick.AddListener(()=> Jump());
    }

    void Jump()
    {
        Debug.Log("Jump");
    }
}
