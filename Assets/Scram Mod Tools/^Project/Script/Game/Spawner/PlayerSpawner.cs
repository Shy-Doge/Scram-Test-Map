using System.Collections.Generic;
using UnityEngine;

namespace Scram
{
    [DisallowMultipleComponent]
    public sealed class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private TeamData teamData = null;
        [SerializeField] private Transform[] spawns = null;
        [SerializeField] private int respawnRate = 3;

        private List<Transform> newSpawns = new List<Transform>(64);

        private void Awake() {}

        private void Start() {}

        public void ResetSpawns() {}

        public void Spawn(PlayerConnection connection, Vector3 position = default(Vector3), float yaw = 0.0f) {}

        public IEnumerator<float> SpawnWithDelay(PlayerConnection connection, Vector3 position = default(Vector3), float yaw = 0.0f)
        {
            yield return 0;
        }
    }
}