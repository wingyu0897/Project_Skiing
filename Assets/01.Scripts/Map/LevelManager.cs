using System.Collections.Generic;
using UnityEngine;

public struct LevelData
{
    public Vector2 position;
    public float width;
}

public class LevelManager : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform player;

    [Header("Setting Values")]
    [SerializeField] private float distanceXMax;
    [SerializeField][Range(0f, 1f)] private float distanceXRandom;
    [SerializeField] private float distanceY;
    [SerializeField][Range(0f, 1f)] private float distanceYRandom;
    [SerializeField] private float width;
    [SerializeField][Range(0f, 1f)] private float widthRandom;
	[SerializeField] private float spawnDistance;

    [SerializeField] private WallController test;

    private List<LevelData> levelDatas;

	private void Start()
	{
		levelDatas = new List<LevelData>();
		StartCreate();
		CreateLevel();
	}

	private void Update()
	{
		if (CheckDistance())
		{
			CreateLevel();
		}
	}

	public void StartCreate()
	{
        float randomWidth = width - width * Random.Range(-widthRandom, widthRandom);
        LevelData data = new LevelData() { position = Vector2.zero, width = randomWidth };
		levelDatas.Add(data);
		WallController wall = Instantiate(test);
		wall.SetWalls(data);
	}

	private void CreateLevel()
	{
		float x = distanceXMax * Random.Range(-1f, 1f);
		float y = distanceY - distanceY * Random.Range(-distanceYRandom, distanceYRandom);

		x += levelDatas[levelDatas.Count - 1].position.x;
		y += levelDatas[levelDatas.Count - 1].position.y;

		float randomWidth = width - width * Random.Range(-widthRandom, widthRandom);
		LevelData data = new LevelData() { position = new Vector2(x, y), width = randomWidth };
		levelDatas.Add(data);
		WallController wall = Instantiate(test);
		wall.SetWalls(data);
	}

	public bool CheckDistance()
	{
		if (levelDatas == null || levelDatas.Count == 0) return false;
		float distance = levelDatas[levelDatas.Count - 1].position.y - player.transform.position.z;
		return distance < spawnDistance;
	}
}
