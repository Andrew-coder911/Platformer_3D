using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private Transform _playerTransform;
	[SerializeField] private float _speed = 3f;
	[SerializeField] private float _timeToReachSpeed = 1f;

	private void Start ()
	{
		_playerTransform = FindObjectOfType<PlayerMove>().transform;
	}

	void FixedUpdate()
    {
		Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
		Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) /_timeToReachSpeed;

       _rigidbody.AddForce(force); 
    }
}
