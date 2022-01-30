using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	[SerializeField] private Transform _spawn;

	public void Create ()
	{
		Instantiate(_prefab, _spawn.position, _spawn.rotation);
	}
}
