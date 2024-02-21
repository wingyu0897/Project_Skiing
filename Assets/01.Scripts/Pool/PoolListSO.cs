using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolPair
{
    public PoolMonobehaviour prefab;
    public int count;
}

[CreateAssetMenu(fileName = "PoolList", menuName = "SO/Pool/PoolList")]
public class PoolListSO : ScriptableObject
{
    public List<PoolPair> list;
}
