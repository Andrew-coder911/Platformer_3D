using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 2;

	private void OnTriggerEnter (Collider other)
	{
		if (other.attachedRigidbody)
		{
			if (other.attachedRigidbody.GetComponent<PlayerHealth> ())
			{
				other.attachedRigidbody.GetComponent<PlayerHealth> ().TakeDamage (_damageValue);
			}
		}		
	}
}
