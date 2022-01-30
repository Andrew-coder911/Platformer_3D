using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
	[SerializeField] private int _gunIndex;
	[SerializeField] private int _numberOfBullets;

	private void OnTriggerEnter (Collider other)
	{
		if (other.attachedRigidbody.GetComponent<PlayerArmory> ())
		{
			other.attachedRigidbody.GetComponent<PlayerArmory> ().AddBulletsByIndex(_gunIndex, _numberOfBullets);
			Destroy (gameObject);
		}
	}
}
