using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;

    void Start()
    {
        float random = Random.Range(-_maxRotationSpeed, _maxRotationSpeed);
        Rigidbody _rigidbody = GetComponent<Rigidbody> ();

        _rigidbody. AddRelativeForce(_velocity, ForceMode.VelocityChange);

        _rigidbody.angularVelocity = new Vector3(random, random, random);
    }

    
}
