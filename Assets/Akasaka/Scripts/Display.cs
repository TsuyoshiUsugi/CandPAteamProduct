using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] GameObject Image;
    [SerializeField] GameObject CloseButton;

    public void display()
    {
        Image.SetActive(true);
        CloseButton.SetActive(true);
    }

    public void hidden()
    {
        Image.SetActive(false);
        CloseButton.SetActive(false);
    }
}
