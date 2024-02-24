using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIController
{
	public GAME_STATE state;
	public UIControllerByState controller;
}

public class UIManager : GameStateComponent
{
	[SerializeField] private List<UIController> controllers = new List<UIController>();

	[SerializeField] private Button startBtn;
	[SerializeField] private Button restartBtn;

	private GAME_STATE previousState = GAME_STATE.MENU;

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

		previousState = state;
	}
}
