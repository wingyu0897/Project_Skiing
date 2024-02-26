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
		else if (state == GAME_STATE.READY)
		{
			player.StopMovement(true);
		}
	}
}
