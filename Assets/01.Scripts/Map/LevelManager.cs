using System.Collections.Generic;
using UnityEngine;

public struct LevelData
{
    public Vector2 position;
    public float width;
	public WallController wall;
}

public class LevelManager : GameStateComponent
{
	[Header("References")]
	[SerializeField] private Transform player;
    [SerializeField] private WallController wallPrefab;

    [Header("Setting Values")]
	[SerializeField] private float startDistance;
    [SerializeField] private float distanceXMax;
    [SerializeField] private float distanceY;
    [SerializeField][Range(0f, 1f)] private float distanceYRandom;
    [SerializeField] private float width;
    [SerializeField][Range(0f, 1f)] private float widthRandom;

	[Header("Spawning")]
	[SerializeField] private float spawnDistance;
	[SerializeField] private float despawnDistance;

	[Header("Flags")]
	private bool isActive = false;

    private List<LevelData> levelDatas = new();

	private void Awake()
	{
		//levelDatas = new List<LevelData>();
		//StartCreate();
		//CreateLevel();
	}

	private void Update()
	{
		if (!isActive) return;

		if (CheckSpawnDistance())
		{
			CreateLevel();
		}
		if (CheckDestroyDistance())
		{
			PoolManager.Instance?.Push(levelDatas[0].wall);
			levelDatas.RemoveAt(0);
		}
	}

	private void CreateWall(LevelData data)
	{
		WallController wall = PoolManager.Instance.Pop(wallPrefab.name) as WallController;
		wall.SetWalls(data);
		data.wall = wall;
		levelDatas.Add(data);
	}

	public void StartCreate()
	{
		isActive = true;
		float randomWidth = width - width * Random.Range(-widthRandom, widthRandom);
		Vector2 startPos = new Vector2(0, startDistance);
        LevelData data = new LevelData() { position = startPos, width = randomWidth };
		CreateWall(data);
	}

	private void CreateLevel()
	{
		float x = distanceXMax * Random.Range(-1f, 1f);
		float y = distanceY - distanceY * Random.Range(-distanceYRandom, distanceYRandom);

		x += levelDatas[levelDatas.Count - 1].position.x;
		y += levelDatas[levelDatas.Count - 1].position.y;

		float randomWidth = width - width * Random.Range(-widthRandom, widthRandom);
		LevelData data = new LevelData() { position = new Vector2(x, y), width = randomWidth };
		CreateWall(data);
	}

	public bool CheckSpawnDistance()
	{
		if (levelDatas == null || levelDatas.Count == 0) return false;
		float distance = levelDatas[levelDatas.Count - 1].position.y - player.transform.position.z;
		return distance < spawnDistance;
	}

	public bool CheckDestroyDistance()
	{
		if (levelDatas is null || levelDatas.Count == 0) return false;

		float distance = player.transform.position.z - levelDatas[0].position.y;

		return distance > despawnDistance;
	}

	private void DespawnAllLevels()
	{
		while (levelDatas.Count > 0)
		{
			PoolManager.Instance?.Push(levelDatas[0].wall);
			levelDatas.RemoveAt(0);
		}
	}

	public override void OnGameStateChangedHandle(GAME_STATE state)
	{
		switch (state)
		{
			case GAME_STATE.MENU:
				if (levelDatas.Count > 0)
				{
					DespawnAllLevels();
				}
				break;
			case GAME_STATE.READY:
				if (levelDatas?.Count > 0)
				{
					DespawnAllLevels();
				}
				StartCreate();
				break;
			case GAME_STATE.RUNNING:
				break;
			case GAME_STATE.RESULT:
				isActive = false;
				break;
			default:
				break;
		}
	}
}
