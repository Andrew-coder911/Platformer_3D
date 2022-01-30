using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shotPeriod = 0.2f;

    private float _timer;

    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

    [SerializeField] private ParticleSystem _shotEffect;

	private void Start ()
	{
		_flash.SetActive(false);
	}

	void Update()
    {

        _timer += Time.unscaledDeltaTime;
        if(_timer > _shotPeriod)
		{
			if (Input.GetMouseButton (0))
			{
               Shot();
            }
		}

        
    }

    public virtual void Shot ()
	{
        _timer = 0f;
        GameObject newBullet = Instantiate (_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody> ().velocity = _spawn.forward * _bulletSpeed;
        _shotSound.Play ();
        _flash.SetActive (true);
        Invoke ("HideFlash", 0.12f);
        _shotEffect.Play();
    }

    public void HideFlash ()
	{
        _flash.SetActive(false);
	}

    public virtual void Activate ()
	{
        gameObject.SetActive(true);
	}

    public virtual void Deactivate ()
	{
        gameObject.SetActive (false);
    }

    public virtual void AddBullets ( int numberOfBullets)
	{
        // переопределяем в Automat
	}
}
