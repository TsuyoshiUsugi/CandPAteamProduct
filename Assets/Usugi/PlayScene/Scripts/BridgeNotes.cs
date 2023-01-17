using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeNotes : MonoBehaviour
{
    [SerializeField] float _notesSpeed = 8;
    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * _notesSpeed;
    }
}
