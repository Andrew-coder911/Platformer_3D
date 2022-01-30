using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;
	[SerializeField] private UnityEvent _eventOnTakeDamage;
	[SerializeField] private UnityEvent _eventOnDie;

	public void TakeDamage ( int damageValue)
	{
		_health -= damageValue;
		if(_health <= 0)
		{
			Die();
		}
		_eventOnTakeDamage.Invoke();
	}

	public void Die ()
	{
		_eventOnDie.Invoke();
		Destroy(gameObject);
	}
}
