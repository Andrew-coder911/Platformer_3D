using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private float _rotationSpeed = 5f;


    private Transform _playerTransform;
    private Vector3 _targetEuler;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        if(transform.position.x < _playerTransform.transform.position.x)
		{
            _targetEuler = _rightEuler;
        }
		else
		{
            _targetEuler = _leftEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }
}
