using UnityEngine;
using UnityEngine.UI;

public class ReadyUIController : UIControllerByState
{
	[SerializeField] private Button startButton;

	private void Awake()
	{
		startButton.onClick.AddListener(StartButtonClickHandler);
	}

	private void StartButtonClickHandler()
	{
		GameManager.Instance?.ChangeGameState(GAME_STATE.RUNNING);
	}

	public override void EnterState()
	{
		startButton.gameObject.SetActive(true);
	}

	public override void ExitState()
	{
		startButton.gameObject.SetActive(false);
	}
}
