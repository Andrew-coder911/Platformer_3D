using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
	[SerializeField] private bool _dieOnAnyCollision;

	private void OnTriggerEnter (Collider other)
	{
		if (other.attachedRigidbody)
		{
			if (other.attachedRigidbody.GetComponent<Bullet> ())
			{
				_enemyHealth.TakeDamage (1);
				Destroy (other.gameObject);
			}
		}
		
		if (_dieOnAnyCollision == true)
		{
			if(other.isTrigger == false)
			{
				_enemyHealth.TakeDamage (1000);
			}			
		}
	}
}
