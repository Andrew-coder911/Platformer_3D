using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currerntGunIndex;

    void Start()
    {
        TakeGunByIndex(_currerntGunIndex);
    }   
    
    public void TakeGunByIndex(int gunIndex)
	{
		_currerntGunIndex = gunIndex;
		for (int i = 0; i < _guns.Length; i++)
		{
            if(i == gunIndex)
			{
                _guns[i].Activate();
			}
			else
			{
				_guns[i].Deactivate();
			}
		}
	}

	public void AddBulletsByIndex (int gunIndex, int numberOfBullets)
	{
		_guns[gunIndex].AddBullets(numberOfBullets);
	}
}
