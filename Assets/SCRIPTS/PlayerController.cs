using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Health healthScript;

	// Start is called before the first frame update
	void Start()
    {
		healthScript = GetComponent<Health>();
        Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {
        if(!healthScript.IsAlive)
        {
            Die();
        }
    }

    void Die()
    {
        print("Player died!");
    }
}
