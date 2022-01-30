using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
	[SerializeField] private int _healthValue = 1;

	private void OnTriggerEnter (Collider other)
	{
		if (other.attachedRigidbody.GetComponent<PlayerHealth> ())
		{
			other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(_healthValue);
			Destroy(gameObject);
		}
	}
}
