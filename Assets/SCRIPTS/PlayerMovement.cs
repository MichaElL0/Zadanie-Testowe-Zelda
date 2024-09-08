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


	bool isSalting = false;
	[SerializeField] private float saltoCooldown = 1f;
	float timeBetweenSalto;

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
		if (timeBetweenDash <= 0 && !isDashing && !isSalting)
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

		//Salto
		if (timeBetweenSalto <= 0 && !isDashing && !isSalting)
		{
			if (playerInput.IsSaltoPressed() && !isSalting)
			{
				StartCoroutine(Teleport());
				timeBetweenSalto = saltoCooldown;
			}
		}
		else
		{
			timeBetweenSalto -= Time.deltaTime;
		}

	}

	void FixedUpdate()
	{
		if (!isDashing)
		{
			rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement.normalized);
		}
	}

	private IEnumerator PerformDash()
	{
		isDashing = true;
		Vector2 dashDirection = movement.normalized; 
		rb.velocity = dashDirection * dashForce; 

		yield return new WaitForSeconds(dashDuration); 

		rb.velocity = Vector2.zero;
		isDashing = false;
	}

	IEnumerator Teleport()
	{
		isSalting = true;
		print("Is salting!");

		float elapsedTime = 0;
		float duration = 1;

		Vector2 dir = transform.right.normalized;
		Vector2 startPosition = rb.position;
		Vector2 targetPosition = startPosition + dir * -2;

		float startAngle = rb.rotation;
		float targetAngle = startAngle + 360f;
		float jumpHeight = 1f;

		while (elapsedTime < duration)
		{
			float t = elapsedTime / duration;

			Vector2 horizontalPosition = Vector2.Lerp(startPosition, targetPosition, t);

			float verticalOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;
			Vector2 jumpPosition = new Vector2(horizontalPosition.x, startPosition.y + verticalOffset);

			rb.position = jumpPosition;

			float currentAngle = Mathf.Lerp(startAngle, targetAngle, t);

			rb.rotation = currentAngle;

			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}

		rb.position = targetPosition;
		rb.rotation = targetAngle % 360f;

		isSalting = false;
	}

	void Flip()
	{
		Vector3 currScale = gameObject.transform.localScale;
		currScale.x *= -1;
		gameObject.transform.localScale = currScale;
		isFacingRight = !isFacingRight;
	}
}
