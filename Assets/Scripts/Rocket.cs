using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    

    private Transform _playerTransform;    

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;        
    }

    
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);        
    }
}
