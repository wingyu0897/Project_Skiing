using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private InputReader inputReader;
    private Rigidbody rigid;
	private Transform visualTrm;
	private TrailRenderer trailRenderer;

	[Header("Settings")]
	[SerializeField] private float maxSpeed = 5f;
	[SerializeField] private float maxAngle = 45f;
	[SerializeField] private float turnTime = 0.5f;

	[Header("Flags")]
	private bool isMove = false;
	private bool isRight = true;

	private Coroutine turnAngleCo;
	private int wallLayer;

	private void Awake()
	{
		wallLayer = LayerMask.NameToLayer("Wall");
		rigid = GetComponent<Rigidbody>();
		visualTrm = transform.Find("Visual");
		trailRenderer = visualTrm.Find("Trail").GetComponent<TrailRenderer>();
		inputReader.LeftClickEvent += HandleOnClick;
	}

	private void Update()
	{
		if (isMove)
		{
			rigid.velocity = transform.forward * maxSpeed;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == wallLayer)
		{
			StopMovement();
			GameManager.Instance?.ChangeGameState(GAME_STATE.RESULT);
		}
	}

	#region Movement
	public void ActiveMovement(bool active)
	{
		isMove = active;
		rigid.isKinematic = false;
	}

	public void StopMovement(bool reset = false)
	{
		isMove = false;
		rigid.isKinematic = true;

		if (turnAngleCo != null)
			StopCoroutine(turnAngleCo);
		
		if (reset)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.position = Vector3.zero;
			trailRenderer.Clear();
		}
	}
	#endregion

	#region Angle
	private void HandleOnClick()
	{
		if (!isMove || inputReader.IsPointerOverUI()) return;

		isRight = !isRight;
		ChangeAngle(isRight ? maxAngle : -maxAngle);
	}

	private void ChangeAngle(float angle)
	{
		if (turnAngleCo != null)
			StopCoroutine(turnAngleCo);

		turnAngleCo = StartCoroutine(TurnAngleCo(angle));
	}

	private IEnumerator TurnAngleCo(float targetAngle)
	{
		float time = 0f;
		float startAngle = transform.eulerAngles.y;
		startAngle = startAngle > 180 ? startAngle - 360 : startAngle;
		float calcTurnTime = turnTime * (Mathf.Abs(targetAngle - startAngle) / maxAngle * 0.5f);

		while (time <= calcTurnTime)
		{
			float per = time / calcTurnTime;
			float angle = Mathf.LerpAngle(startAngle, targetAngle, per);
			transform.rotation = Quaternion.Euler(0, angle, 0);
			time += Time.unscaledDeltaTime;
			if (time > calcTurnTime)
			{
				transform.rotation = Quaternion.Euler(0, targetAngle, 0);
			}
			yield return null;
		}
	}
	#endregion
}
