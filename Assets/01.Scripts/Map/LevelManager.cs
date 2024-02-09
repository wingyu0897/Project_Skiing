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
    [SerializeField] private float distanceX;
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
	}

	private void Update()
	{
		if (CheckDistance())
		{

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
		float randomWidth = width - width * Random.Range(-widthRandom, widthRandom);
		LevelData data = new LevelData() { position = Vector2.zero, width = randomWidth };
	}

	public bool CheckDistance()
	{
		if (levelDatas == null || levelDatas.Count == 0) return false;
		float distance = levelDatas[levelDatas.Count - 1].position.y - player.transform.position.z;
		return distance < spawnDistance;
	}
}
