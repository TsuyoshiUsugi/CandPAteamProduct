using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourself : MonoBehaviour
{
    float _deleteNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(Destroy));
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_deleteNum);
        Destroy(this.gameObject);
    }
}
