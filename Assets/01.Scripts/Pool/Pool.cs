using System.Collections.Generic;
using UnityEngine;

public class Pool
{
	private PoolMonobehaviour prefab;
	private Stack<PoolMonobehaviour> items;
	private Transform parent;

    public Pool(PoolMonobehaviour prefab, int count, Transform parent)
	{
		this.prefab = prefab;
		this.parent = parent;

		items = new Stack<PoolMonobehaviour>();

		for (int i = 0; i < count; ++i)
		{
			PoolMonobehaviour obj = GameObject.Instantiate(prefab, parent).GetComponent<PoolMonobehaviour>();
			obj.name = obj.name.Replace("(Clone)", "");
			Push(obj);
		}
	}

	public void Push(PoolMonobehaviour obj)
	{
		obj.gameObject.SetActive(false);
		items.Push(obj);
	}

	public PoolMonobehaviour Pop()
	{
		PoolMonobehaviour obj;

		if (items.Count > 0)
		{
			obj = items.Pop();
		}
		else
		{
			obj = GameObject.Instantiate(prefab, parent).GetComponent<PoolMonobehaviour>();
			obj.name = obj.name.Replace("(Clone)", "");
		}

		obj.Initialize();
		return obj;
	}
}
