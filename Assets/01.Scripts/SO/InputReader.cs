using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
	public Vector2 InputMove { get; private set; }

	public event Action LeftClickEvent;

	private Controls controls;

	private void OnEnable()
	{
		if (controls == null)
		{
			controls = new Controls();
			controls.Player.SetCallbacks(this);
		}
		controls.Player.Enable();
	}

	public void OnClick(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			LeftClickEvent?.Invoke();
		}
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
		InputMove = context.ReadValue<Vector2>();
	}
}
