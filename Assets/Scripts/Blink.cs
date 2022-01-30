using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartBlink ()
	{
		StartCoroutine(BlinkEffect());
	}

	public IEnumerator BlinkEffect()
	{
		for (float t = 0; t < 1; t += Time.deltaTime)
		{
			for (int i = 0; i < _renderers.Length; i++)
			{
				for (int j = 0; j < _renderers[i].materials.Length; j++)
				{
					//Mathf.Sin(t * 30) * 0.5f + 0.5f это 0.5f + 0.5f смещает график синуса в положит. сторону от 0 до 1
					_renderers[i].materials[j].SetColor ("_EmissionColor", new Color (Mathf.Sin (t * 30) * 0.5f + 0.5f, 0, 0, 0));
				}				
			}			
			yield return null;
		}
	}
}
