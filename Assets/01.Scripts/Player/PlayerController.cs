using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameStateComponent
{
	[SerializeField] private PlayerMovement player;

	public override void OnGameStateChangedHandle(GAME_STATE state)
	{
		if (state == GAME_STATE.RUNNING)
		{
			player.ActiveMovement(true);
		}
	}
}