using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GameStateComponent
{
	[SerializeField] private Button startBtn;
	[SerializeField] private Button restartBtn;

	private void OnEnable()
	{
		startBtn.onClick.AddListener(OnStartClickHandle);
		restartBtn.onClick.AddListener(OnRestartClickHandle);
	}

	private void OnStartClickHandle()
	{
		GameManager.Instance.ChangeGameState(GAME_STATE.RUNNING);
	}

	private void OnRestartClickHandle()
	{
		GameManager.Instance.ChangeGameState(GAME_STATE.READY);
	}

	public override void OnGameStateChangedHandle(GAME_STATE state)
	{
		switch (state)
		{
			case GAME_STATE.MENU:
				startBtn.gameObject.SetActive(false);
				restartBtn.gameObject.SetActive(false);
				break;
			case GAME_STATE.READY:
				startBtn.gameObject.SetActive(true);
				restartBtn.gameObject.SetActive(false);
				break;
			case GAME_STATE.RUNNING:
				startBtn.gameObject.SetActive(false);
				break;
			case GAME_STATE.RESULT:
				restartBtn.gameObject.SetActive(true);
				break;
			default:
				break;
		}
	}
}
