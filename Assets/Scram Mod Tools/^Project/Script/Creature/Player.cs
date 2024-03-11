using Bolt;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scram
{
    [DisallowMultipleComponent]
    public sealed class Player : EntityBehaviour<IPlayerState>, IDamageable
    {

        [SerializeField] private Dictionary<string, GameObject> abilities = null;

        [SerializeField] private GameObject[] localGameObjects = null;
        [SerializeField] private GameObject[] remoteGameObjects = null;

        [SerializeField] private GameObject view;
        [SerializeField] private Camera worldViewer = null;
        [SerializeField] private GameObject identity = null;
        [SerializeField] private GameObject spectateCamera = null;
        [SerializeField] private LayerMask originalWorldViewerLayerMask = default(LayerMask);
        [SerializeField] private LayerMask originalImpactLayerMask = default(LayerMask);
        [SerializeField] private LayerMask originalWallLayerMask = default(LayerMask);
        [SerializeField] private LayerMask impactLayerMask = default(LayerMask);
        [SerializeField] private LayerMask wallLayerMask = default(LayerMask);

        private string dataName = string.Empty;
        private CreatureData data = null;

        private AudioSource audioSource = null;
        private CharacterController characterController = null;
        public LayerMask ImpactLayerMask { get { return impactLayerMask; } }
        public LayerMask WallLayerMask { get { return wallLayerMask; } }
        private List<Collider> ignoredColliders = new List<Collider>();

        private float voicePitch;

        private void Awake() {}

        public override void Attached() {}

        public override void Detached() {}

        public override void ControlGained() {}

        public override void ControlLost() {}

        public void Spectate(bool isTrue) {}

        public void IgnoreCollider(Collider collider, bool isIgnore) {}

        private void ResetIgnoredColliders() {}

        public void TakeDamage(int damage, Vector3 direction, string enemyName = "", PlayerConnection enemyConnection = null, bool isFall = false) {}

        public void Die(Vector3 direction, string enemyName = "", PlayerConnection enemyConnection = null) {}

        private void SendKillfeed(string enemyName) {}

        public void ToggleTurretView(bool isActive) {}

        private void OnScaleChange() {}

        public void StartBriefHealth() {}

        private IEnumerator<float> DecreaseBriefHealth()
        {
            yield return 0;
        }
    }

    public class TimeController {
		public static double GetTime(double startTime){
			return 0;
		}

		public static double GetTime(){
			return 0;
		}
	}
}