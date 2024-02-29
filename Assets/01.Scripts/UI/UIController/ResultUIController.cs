using UnityEngine;
using UnityEngine.UI;

public class ResultUIController : UIControllerByState
{
	[SerializeField] private Button restartButton;
	[SerializeField] private GameObject scoreTxt;
	[SerializeField] private GameObject highScoreTxt;

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
		highScoreTxt.SetActive(true);
	}

	public override void ExitState()
	{
		restartButton.gameObject.SetActive(false);
		scoreTxt.SetActive(false);
		highScoreTxt.SetActive(false);
	}
}
