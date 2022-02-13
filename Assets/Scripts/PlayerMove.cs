using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _jumpSpeed;
	[SerializeField] private float _friction;
	public bool Grounded;

	[SerializeField] private float _maxSpeed;

	[SerializeField] private Transform _colliderTransform;

	private int _jumpFrameCounter;

	private float _lerpTime = 15f;

	void Update ()
	{
		if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey (KeyCode.S) || Grounded == false)
		{
			_colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * _lerpTime);
		}
		else
		{
			_colliderTransform.localScale = Vector3.Lerp (_colliderTransform.localScale, new Vector3 (1f, 1f, 1f), Time.deltaTime * _lerpTime);
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (Grounded)
			{
				Jump();
			}
		}
	}

	public void Jump ()
	{
		_rigidbody.AddForce (0, _jumpSpeed, 0, ForceMode.VelocityChange);
		_jumpFrameCounter = 0;		
	}

	private void FixedUpdate ()
	{
		float speedMultiplier = 1f;

		if (Grounded == false)
		{
			speedMultiplier = 0.2f;

			if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis ("Horizontal") > 0)
			{
				speedMultiplier = 0;
			}
			if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis ("Horizontal") < 0)
			{
				speedMultiplier = 0;
			}
		}

		_rigidbody.AddForce (Input.GetAxis ("Horizontal") * _moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

		if (Grounded)
		{
			//сила по Х вместо drag сопротивления воздуха
			_rigidbody.AddForce (-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
		}

		_jumpFrameCounter += 1;
		if (_jumpFrameCounter == 2)
		{
			_rigidbody.freezeRotation = false;
			_rigidbody.AddRelativeTorque (0f, 0f, 10f, ForceMode.VelocityChange);
		}
	}

	private void OnCollisionStay (Collision collision)
	{
		//for (int i = 0; i < collision.contactCount; i++)
		//{
		float angle = Vector3.Angle (collision.contacts[0 /*i*/].normal, Vector3.up);
		if (angle < 45f)
		{
			Grounded = true;
			_rigidbody.freezeRotation = true;
		}
		//}		
	}

	private void OnCollisionExit (Collision collision)
	{
		Grounded = false;
	}
}
