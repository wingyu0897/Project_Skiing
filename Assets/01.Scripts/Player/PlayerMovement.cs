using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private InputReader inputReader;
    private Rigidbody rigid;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Vector3 move = new Vector3(inputReader.InputMove.x, 0, inputReader.InputMove.y);
		rigid.velocity = move * 5f;
	}
}
