using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private InputReader inputReader;
    private Rigidbody rigid;

	[Header("Settings")]
	[SerializeField] private float maxAngle = 45f;
	[SerializeField] private float turnTime = 0.5f;

	[Header("Flags")]
	private bool isRight = true;

	private Coroutine turnAngleCo;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		inputReader.LeftClickEvent += HandleOnClick;
	}

	private void Update()
	{
		Vector3 move = new Vector3(inputReader.InputMove.x, 0, inputReader.InputMove.y);
		rigid.velocity = move * 5f;
	}

	private void HandleOnClick()
	{
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
}
