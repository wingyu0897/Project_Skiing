using UnityEngine;
using UnityEngine.UI;

public class RunningUIController : UIControllerByState
{
	[SerializeField] private CanvasGroup canvasGroup;

	public override void EnterState()
	{
		canvasGroup.alpha = 1f;
	}

	public override void ExitState()
	{
		canvasGroup.alpha = 0;
	}
}
