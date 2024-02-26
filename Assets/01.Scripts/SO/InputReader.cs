using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
	public Vector2 InputMove { get; private set; }
	public Vector2 MousePosition { get; private set; }

	public event Action LeftClickEvent;

	private Controls controls;

	private PointerEventData pointerEventData;
	private List<RaycastResult> raycastResultsList = new();

	private void OnEnable()
	{
		if (controls == null)
		{
			controls = new Controls();
			controls.Player.SetCallbacks(this);
		}
		controls.Player.Enable();

		pointerEventData = new PointerEventData(EventSystem.current);
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

	public void OnMouse(InputAction.CallbackContext context)
	{
		MousePosition = context.ReadValue<Vector2>();
	}

	public bool IsPointerOverUI()
	{
		pointerEventData.position = Touchscreen.current.primaryTouch.position.ReadValue(); ;
		raycastResultsList.Clear();
		EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
		for (int i = 0; i < raycastResultsList.Count; i++)
		{
			if (raycastResultsList[i].gameObject.GetType() == typeof(GameObject))
			{
				return true;
			}
		}

		return false;
	}
}
