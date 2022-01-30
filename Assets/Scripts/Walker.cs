using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;

    [SerializeField] private float _speed;    

    [SerializeField] private float _stopTime;

    [SerializeField] private Direction _currentDirection;

    private bool _isStopped;

    [SerializeField] private UnityEvent _eventOnLeftTarget;
    [SerializeField] private UnityEvent _eventOnRightTarget;

    [SerializeField] private Transform _rayStart;

    private void Start ()
	{
		_leftTarget.parent = null;
        _rightTarget.parent = null;
    }

	void Update ()
    {
        if(_isStopped == true)
		{
            return;
		}

		if (_currentDirection == Direction.Left)
		{
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);

            if(transform.position.x < _leftTarget.position.x)
			{
                _currentDirection = Direction.Right;
                _isStopped = true;
                Invoke (nameof (ContinueWalk), _stopTime);
                _eventOnLeftTarget.Invoke();
            }
		}
		else
		{
            transform.position += new Vector3 (Time.deltaTime * _speed, 0, 0);

            if (transform.position.x > _rightTarget.position.x)
            {
                _currentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                _eventOnRightTarget.Invoke();
            }
        }

        RaycastHit hit;
        if(Physics.Raycast(_rayStart.position, Vector3.down, out hit))
		{
            transform.position = hit.point;
		}
    }

    void ContinueWalk ()
	{
        _isStopped = false;
	}
}
