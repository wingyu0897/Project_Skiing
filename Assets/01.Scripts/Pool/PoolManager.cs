using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

	[SerializeField] private PoolListSO poolList;
	private Dictionary<string, Pool> pools;

	private void Awake()
	{
		if (Instance is not null)
		{
			Debug.LogWarning("PoolManager: Multiple Instance");
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

		pools = new Dictionary<string, Pool>();

		foreach (PoolPair pair in poolList.list)
		{
			if (pools.ContainsKey(pair.prefab.name)) continue;
			Pool pool = new Pool(pair.prefab, pair.count, transform);
			pools.Add(pair.prefab.name, pool);
		}
	}

	public void Push(PoolMonobehaviour obj)
	{
		if (!pools.ContainsKey(obj.name))
		{
			Debug.LogError($"PoolManager<Push Error>: Pool of {obj.name} is not exist.");
		}
		else
		{
			pools[obj.name].Push(obj);
		}
	}

	public PoolMonobehaviour Pop(string name)
	{
		if (!pools.ContainsKey(name))
		{
			Debug.LogError($"PoolManager<Pop Error>: Pool of {name} is not exist.");
			return null;
		}
		else
		{
			PoolMonobehaviour pop = pools[name].Pop();
			return pop;
		}
	}
}
