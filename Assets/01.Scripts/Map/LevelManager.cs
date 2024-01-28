using System.Collections.Generic;
using UnityEngine;

struct LevelData
{
    public Vector2 position;
    public float width;
}

public class LevelManager : MonoBehaviour
{
    [Header("Setting Values")]
    [SerializeField] private float distanceX;
    [SerializeField][Range(0f, 1f)] private float distanceXRandom;
    [SerializeField] private float distanceY;
    [SerializeField][Range(0f, 1f)] private float distanceYRandom;
    [SerializeField] private float width;
    [SerializeField][Range(0f, 1f)] private float widthRandom;

    [SerializeField] private GameObject test;

    private List<LevelData> levelDatas;

	private void Start()
	{
		StartCreate();
	}

	public void StartCreate()
	{
        float randomWidth = width - width * Random.Range(-widthRandom, widthRandom);
        LevelData data = new LevelData() { position = Vector2.zero, width = randomWidth };

	}
}
