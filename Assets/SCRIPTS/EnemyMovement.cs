using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    GameObject targetPlayer;

    public float radius;
    public LayerMask playerMask;

	bool isNearPlayer = false;

	// Start is called before the first frame update
	void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		isNearPlayer = Physics2D.OverlapCircle(transform.position, radius, playerMask);

		if (targetPlayer != null && !isNearPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, moveSpeed * Time.deltaTime);
        }

		if(isNearPlayer)
        {
            print("Player is in the radius. Kill the ugly skeleton");

        }
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
