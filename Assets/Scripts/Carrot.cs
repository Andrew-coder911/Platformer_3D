using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;


    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * _speed;
    }    
}
