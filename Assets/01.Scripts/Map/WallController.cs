using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private float wallOffset;
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;

    public void SetWalls(LevelData levelData)
	{
        transform.position = levelData.position;
        leftWall.localPosition = new Vector3(wallOffset + levelData.width, 0, 0);
        rightWall.localPosition = new Vector3(-wallOffset - levelData.width, 0, 0);
	}
}
