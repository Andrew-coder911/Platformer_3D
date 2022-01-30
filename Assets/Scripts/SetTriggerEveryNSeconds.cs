using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] private float _period = 7f;
    [SerializeField] private Animator _animator;
    private float _timer;
    private string _triggerName = "Attack";


    
    void Update()
    {
        _timer += Time.deltaTime;
		if (_timer > _period)
		{
            _timer = 0;
            _animator.SetTrigger(_triggerName);
		}
	}
}
