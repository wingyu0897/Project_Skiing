using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIController
{
	public GAME_STATE state;
	public UIControllerByState controller;
}

public class UIManager : GameStateComponent
{
	[SerializeField] private List<UIController> controllers = new List<UIController>();

	private GAME_STATE previousState = GAME_STATE.MENU;

	public override void OnGameStateChangedHandle(GAME_STATE state)
	{
		foreach (UIController controller in controllers)
		{
			if (controller.state == previousState)
			{
				controller.controller.ExitState();
			}
			else if (controller.state == state)
			{
				controller.controller.EnterState();
			}
		}

		previousState = state;
	}
}
