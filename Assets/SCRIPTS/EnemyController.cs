using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	Health healthScript;
	public ParticleSystem particle;

	private void Start()
	{
		healthScript = GetComponent<Health>();
	}

	void Update()
	{
		if (!healthScript.IsAlive)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.LogAssertion($"{healthScript.name} has died. RIP!");

		ParticleSystem deathEffect = Instantiate(particle, transform.position, Quaternion.identity);

		Destroy(deathEffect, 1f);
		Destroy(gameObject);
	}
}
