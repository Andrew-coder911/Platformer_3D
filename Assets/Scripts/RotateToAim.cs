using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToAim : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private float _rotationSpeed = 5f;


    [SerializeField] private Transform _aimTransform;
    private Vector3 _targetEuler;
   

    void Update ()
    {
        if (transform.position.x < _aimTransform.transform.position.x)
        {
            _targetEuler = _rightEuler;
        }
        else
        {
            _targetEuler = _leftEuler;
        }

        transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler (_targetEuler), Time.deltaTime * _rotationSpeed);
    }
}
