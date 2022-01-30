using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<ActivateByDistance> _objectsToActivate = new List<ActivateByDistance>();
    [SerializeField] private Transform _playerTransform;

    
    void Update()
    {
		for (int i = 0; i < _objectsToActivate.Count; i++)
		{
            _objectsToActivate[i].CheckDistance(_playerTransform.position);
		}
    }

    public void AddToList (ActivateByDistance objects)
	{
        _objectsToActivate.Add(objects);
	}

    public void RemoveFromList(ActivateByDistance objects)
	{
        _objectsToActivate.Remove(objects);
	}
}
