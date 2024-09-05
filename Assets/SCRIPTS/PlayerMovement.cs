using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float movementSpeed = 10f;
	public bool isMoving;
	Vector2 movement;
	Rigidbody2D rb;
	bool isFacingRight = true;
	
	[Header("Dash mechanic")]
	[SerializeField] private float dashCooldown = 1f;
	float timeBetweenDash;
	bool isDashing = false;
	public float dashForce = 20f;
	public float dashDuration = 0.1f;

	[Header("Salto mechanic")]
	bool isSalting = false; 
	private float saltoCooldown = 1f;      
	private float timeBtwnSalto;      

	PlayerInput playerInput;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		playerInput = new PlayerInput();
	}

	void Update()
	{
		movement = playerInput.GetMovementInput();

		isMoving = movement != Vector2.zero;

		//Flip sprite
		if (movement.x > 0 && !isFacingRight)
		{
			Flip();
		}
		else if (movement.x < 0 && isFacingRight)
		{
			Flip();
		}


		// Dash mechanic
		if (timeBetweenDash <= 0 && !isDashing)
		{
			if (playerInput.IsDashPressed() && isMoving)
			{
				StartCoroutine(PerformDash());
				timeBetweenDash = dashCooldown;
			}
		}
		else
		{
			timeBetweenDash -= Time.deltaTime;
		}

	}

	void FixedUpdate()
	{
		if (!isDashing)
		{
			rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement.normalized);
		}

	}

	// Coroutine to handle the dash action
	private IEnumerator PerformDash()
	{
		isDashing = true;
		Vector2 dashDirection = movement.normalized; 
		rb.velocity = dashDirection * dashForce; 

		yield return new WaitForSeconds(dashDuration); 

		rb.velocity = Vector2.zero;
		isDashing = false;
	}

	void Flip()
	{
		Vector3 currScale = gameObject.transform.localScale;
		currScale.x *= -1;
		gameObject.transform.localScale = currScale;
		isFacingRight = !isFacingRight;
	}
}
