using UnityEngine;
using UnityEngine.UI;

public class UIManager : GameStateComponent
{
	[SerializeField] private Button gameStartBtn;

	private void OnEnable()
	{
		gameStartBtn.onClick.AddListener(OnStartClickHandle);
	}

	private void OnStartClickHandle()
	{
		GameManager.Instance.ChangeGameState(GAME_STATE.RUNNING);
	}

	public override void OnGameStateChangedHandle(GAME_STATE state)
	{
		switch (state)
		{
			case GAME_STATE.MENU:
				break;
			case GAME_STATE.READY:
				gameStartBtn.gameObject.SetActive(true);
				break;
			case GAME_STATE.RUNNING:
				gameStartBtn.gameObject.SetActive(false);
				break;
			case GAME_STATE.RESULT:
				break;
			default:
				break;
		}
	}
}
