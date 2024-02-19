using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

    [SerializeField] private GAME_STATE gameState;

	private void Awake()
	{
		if (Instance is not null)
		{
			Debug.LogError("Multiple GameManager");
			Destroy(gameObject);
			return;
		}
		else
		{
			Instance = this;
		}

		SetGameState(GAME_STATE.MENU);
	}

	public void SetGameState(GAME_STATE state)
	{
		gameState = state;
	}
}
