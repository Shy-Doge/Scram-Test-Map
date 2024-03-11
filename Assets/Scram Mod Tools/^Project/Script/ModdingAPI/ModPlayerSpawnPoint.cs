using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scram {
	public class ModPlayerSpawnPoint : MonoBehaviour {

		public enum SpawnPointType { Default, Zombie };
		public SpawnPointType spawnType = SpawnPointType.Default;

		void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Vector3 middlePos = transform.position + Vector3.up * 0.7684905f;
			Gizmos.DrawWireCube(middlePos, new Vector3(0.6156186f , 1.536981f, 0.6156186f));
			Gizmos.color = spawnType == SpawnPointType.Default ? Color.green : Color.red;
			Gizmos.DrawLine(middlePos, middlePos + (transform.forward * 0.25f));
			Gizmos.DrawLine(middlePos + (transform.forward * 0.10f) + (transform.right * 0.10f), middlePos + (transform.forward * 0.25f));
			Gizmos.DrawLine(middlePos + (transform.forward * 0.10f) + (transform.right * -0.10f), middlePos + (transform.forward * 0.25f));
		}
	}
}