using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Minimap : MonoBehaviour
{
	public GameObject scriptMan;
	public GameObject iconPrefab;
	public GameObject Minimaptex;
	[HideInInspector]
	public BoltEntity local;
	[HideInInspector]
	public float updatetimer = 0f;
	[HideInInspector]
	public Dictionary<BoltEntity, GameObject> dict = new Dictionary<BoltEntity, GameObject>();
	List<BoltEntity> allPlayers = new List<BoltEntity>();

	void Start()
	{
	}

	void ReSpawnIcons()
	{
		allPlayers = FindObjectsOfType<BoltEntity>().Where(x => x.isAttached && x.StateIs(typeof(IPlayerState))).ToList();
		foreach (var obj in dict)
		{
			Destroy(obj.Value.gameObject);
		}
		dict.Clear();
		foreach (var plr in allPlayers)
		{
			Vector3 pos = Vector3.zero;
			pos.z = 1000f;
			var obj = Instantiate(iconPrefab, pos, Quaternion.identity);
			// obj.transform.SetParent(this.transform);
			dict.Add(plr, obj);
		}
	}

	void UpdateIcons()
	{
		foreach (var obj in dict)
		{
			obj.Value.transform.position = obj.Key.transform.position + Vector3.up * 800f;
		}
	}

	void Update()
	{
		updatetimer -= Time.deltaTime;
		if (updatetimer <= 0f)
		{
			updatetimer = 2f;
			ReSpawnIcons();
			foreach (var plr in allPlayers)
			{
				if (plr.hasControl)
				{
					local = plr;
					break;
				}
			}
		}
		UpdateIcons();
		if (local == null)
		{
			foreach (var plr in allPlayers)
			{
				if (plr.hasControl)
				{
					local = plr;
					break;
				}
			}
		}
		if (local != null)
		{
			transform.position = local.transform.position + Vector3.up * 1001f;
		}
		else
		{
			transform.position = new Vector3(126.8f, 1001f, 113.5f);
		}
	}
}