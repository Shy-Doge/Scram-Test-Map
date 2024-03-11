using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scram {
	public class ModWeaponSpawnPoint : MonoBehaviour {

		public enum WeaponType { AK47, AR15, Famas, K2, L96, M16A, M60, SPAS12, Thompson, Uzi };
		public WeaponType powerupType = WeaponType.AK47;

		void OnDrawGizmos()
		{
			Gizmos.color = Color.magenta;

			int iterations = 10;
			float angle = 0;
			Vector3 lastPos = transform.position + new Vector3(Mathf.Sin(0), 0, Mathf.Cos(0));
			for(int i = 0; i < iterations + 1; i++){
				Vector3 curPos = transform.position + new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
				Gizmos.DrawLine(lastPos, curPos);
				lastPos = curPos;
				angle += (360f / iterations);
			}
		}
	}
}