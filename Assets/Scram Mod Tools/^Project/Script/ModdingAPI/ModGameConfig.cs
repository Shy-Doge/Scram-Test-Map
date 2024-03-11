using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scram {
	public class ModGameConfig : MonoBehaviour {

		public enum SkyboxVariants { HorizonRich, ScramDay, DayBreak, SunMid, SunMidStormyClouds, BlueSunset, MoonGlow }
		public SkyboxVariants skybox;
	}
}