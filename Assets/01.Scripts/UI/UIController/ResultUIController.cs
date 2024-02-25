using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIController : UIControllerByState
{
	[SerializeField] private Button restartButton;

	private void Awake()
	{
		restartButton.onClick.AddListener(StartButtonClickHandler);
	}

	private void StartButtonClickHandler()
	{
		GameManager.Instance?.ChangeGameState(GAME_STATE.READY);
	}

	public override void EnterState()
	{
		restartButton.gameObject.SetActive(true);
	}

	public override void ExitState()
	{
		restartButton.gameObject.SetActive(false);
	}
}
