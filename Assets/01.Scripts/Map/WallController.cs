using UnityEngine;

public class WallController : PoolMonobehaviour
{
	public override void Initialize()
	{
		// Nothing
	}

    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;

	/// <summary>
	/// ����ü ���� �������� ��ġ, ������ ���ߴ� �Լ�
	/// </summary>
	/// <param name="levelData">���� ����ü</param>
	public void SetWalls(LevelData levelData)
	{
        transform.position = new Vector3(levelData.position.x, 0, levelData.position.y);
        leftWall.localPosition = new Vector3(levelData.width, 0, 0);
        rightWall.localPosition = new Vector3(-levelData.width, 0, 0);

		leftWall.localScale = new Vector3(1f, 1f * Random.Range(0.5f, 4.0f), 1f);
		rightWall.localScale = new Vector3(1f, 1f * Random.Range(0.5f, 4.0f), 1f);
	}
}
