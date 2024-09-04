using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
	public Vector2 GetMovementInput()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		return new Vector2(horizontal, vertical);
	}

	public bool IsDashPressed()
	{
		return Input.GetKeyDown(KeyCode.LeftShift);
	}

	public bool IsAttackPressed()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}
}
