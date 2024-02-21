using UnityEngine;

public abstract class GameStateComponent : MonoBehaviour
{
	public abstract void OnGameStateChangedHandle(GAME_STATE state);
}
