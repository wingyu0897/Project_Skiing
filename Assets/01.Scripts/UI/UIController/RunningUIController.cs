using UnityEngine;
using UnityEngine.UI;

public class RunningUIController : UIControllerByState
{
	[SerializeField] private CanvasGroup canvasGroup;
	[SerializeField] private Button pauseBtn;
	[SerializeField] private GameObject scoreTxt;

	private void OnEnable()
	{
		pauseBtn.onClick.AddListener(PauseButtonClickHandle);
	}

	private void OnDisable()
	{
		pauseBtn.onClick.RemoveListener(PauseButtonClickHandle);
	}

	private void PauseButtonClickHandle()
	{

	}

	public override void EnterState()
	{
		scoreTxt.SetActive(true);
		canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}

	public override void ExitState()
	{
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}
}
