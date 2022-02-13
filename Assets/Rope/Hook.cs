using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
	private FixedJoint _fixedJoint;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Collider _collaider;
	[SerializeField] private Collider _playerCollaider;
	[SerializeField] private RopeGun _ropeGun;

	private void Start ()
	{
		Physics.IgnoreCollision(_collaider, _playerCollaider);
	}

	private void OnCollisionEnter (Collision collision)
	{
		if(_fixedJoint == null)
		{
			_fixedJoint = gameObject.AddComponent<FixedJoint> ();
			if (collision.rigidbody)
			{
				_fixedJoint.connectedBody = collision.rigidbody;
			}
			_ropeGun.CreateSpring();
		}
		
	}

	public void StopFix ()
	{
		if (_fixedJoint)
		{
			Destroy(_fixedJoint);
		}
	}

	public void ChangeVelocity (Vector3 value)
	{
		_rigidbody.velocity = value;
	}
}
