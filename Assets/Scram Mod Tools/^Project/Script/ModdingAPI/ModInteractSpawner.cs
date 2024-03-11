using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scram {
	public class ModInteractSpawner : MonoBehaviour {

		public enum SpawnType { AmmoBox, RadioSpawnPoint, HelicopterStart, HelicopterArrive, HelicopterLeave, InstantDeath };
		public SpawnType spawnType = SpawnType.AmmoBox;
	}
}