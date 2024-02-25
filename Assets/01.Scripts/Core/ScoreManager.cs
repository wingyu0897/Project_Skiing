using TMPro;
using UnityEngine;

public class ScoreManager : GameStateComponent
{
	[SerializeField] private Transform player;
	[SerializeField] private TextMeshProUGUI scoreText;

	private bool isActive = false;

	public override void OnGameStateChangedHandle(GAME_STATE state)
	{
		isActive = state == GAME_STATE.RUNNING;
	}

	private void Update()
	{
		if (isActive)
		{
			scoreText.text = $"{(int)player.position.z}m";
		}
	}
}
