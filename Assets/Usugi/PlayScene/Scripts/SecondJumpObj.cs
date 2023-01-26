using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// Jump����X�N���v�g�̉�����
/// 
/// ������͋��I�u�W�F�N�g�������悤�ɔ��
/// ���ۂɂ�SPACE�ŃW�����v���A���̍��x����ɂ͔�΂Ȃ��悤�ɂ���
/// </summary>
public class SecondJumpObj : MonoBehaviour
{
    [SerializeField] GameObject _jumpObj;
    [SerializeField] Vector3 _originPos;
    [SerializeField] Vector3 _jumpForce;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    Rigidbody _rb;
    bool isGround;

    const float _hightLimit = 0.7f;

    private void Start()
    {
        _rb = _jumpObj.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (!isGround) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.PlayOneShot(_audioClip);
            _rb.AddForce(_jumpForce);
            isGround = false;
        }

        if(_jumpObj.transform.position.y > _hightLimit)
        {
            _rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
