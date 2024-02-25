using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : UIControllerByState
{
	[SerializeField] private Button playButton;

	private void Awake()
	{
		playButton.onClick.AddListener(PlayButtonClickHandler);
	}

	private void PlayButtonClickHandler()
	{
		GameManager.Instance?.ChangeGameState(GAME_STATE.READY);
	}

	public override void EnterState()
	{
		playButton.gameObject.SetActive(true);
	}

	public override void ExitState()
	{
		playButton.gameObject.SetActive(false);
	}
}
