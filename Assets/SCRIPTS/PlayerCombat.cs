using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] int maxDamage, minDamage;
    [SerializeField] float radius;
    [SerializeField]LayerMask enemyMask;

    float timeBtwnAttack;
    [SerializeField] float startTimeBtwnAttack;

    [SerializeField] Transform attackPos;

    PlayerInput playerinput;

    // Start is called before the first frame update
    void Start()
    {
        playerinput = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
		if (timeBtwnAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                print("attack");
                int damage = UnityEngine.Random.Range(minDamage, maxDamage);
                Collider2D[] enemiesToDamage =  Physics2D.OverlapCircleAll(attackPos.position, radius, enemyMask);
                foreach(var enemy in enemiesToDamage)
                {
                    enemy.GetComponent<Health>().TakeDamage(damage);
                    print("Attack");
                }
				timeBtwnAttack = startTimeBtwnAttack;
			}

            
        }
        else
        {
            timeBtwnAttack -= Time.deltaTime;
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, radius);
	}
}
