using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    public string charaterName;
    public bool IsAlive => currentHealth > 0;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public bool TakeDamage(int damageAmmount)
    {
        currentHealth -= damageAmmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        print($"{charaterName} took {damageAmmount} damage!");
        return !IsAlive;
    }


}
