using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scram {
	public class ModPickupSpawner : MonoBehaviour {
		
		/*
			This will be a spawnpoint for: Peanut Bags, Peanut Jars, and Grenades. Used in Evacuation.
		*/

		void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;

			int iterations = 10;
			float angle = 0;
			Vector3 lastPos = transform.position + new Vector3(Mathf.Sin(0) * 0.25f, 0, Mathf.Cos(0) * 0.25f);
			for(int i = 0; i < iterations + 1; i++){
				Vector3 curPos = transform.position + new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle) * 0.25f, 0, Mathf.Cos(Mathf.Deg2Rad * angle) * 0.25f);
				Gizmos.DrawLine(lastPos, curPos);
				lastPos = curPos;
				angle += (360f / iterations);
			}
		}
	}
}