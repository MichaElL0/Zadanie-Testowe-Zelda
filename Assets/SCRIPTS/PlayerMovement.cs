using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    Rigidbody2D rigidbody;
    Vector2 movement;


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
    }

	private void FixedUpdate()
	{
		rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
	}
}
