using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public string name;
    //itd...
    public bool IsAlive => currentHealth > 0;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public bool TakeDamage(int damageAmmount)
    {
        currentHealth -= damageAmmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        return !IsAlive;
    }


}
