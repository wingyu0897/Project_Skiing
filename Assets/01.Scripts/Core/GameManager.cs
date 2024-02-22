using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

    [SerializeField] private GAME_STATE gameState;

	public Action<GAME_STATE> OnGameStateChanged;

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
	}

	private void OnEnable()
	{
		foreach (GameStateComponent compo in FindObjectsOfType<GameStateComponent>())
		{
			OnGameStateChanged += compo.OnGameStateChangedHandle;
		}
	}

	private void Start()
	{
		ChangeGameState(GAME_STATE.READY);
	}

	private void OnDisable()
	{
		foreach (GameStateComponent compo in FindObjectsOfType<GameStateComponent>())
		{
			OnGameStateChanged -= compo.OnGameStateChangedHandle;
		}
	}

	public void ChangeGameState(GAME_STATE state)
	{
		gameState = state;
		OnGameStateChanged?.Invoke(gameState);
	}
}