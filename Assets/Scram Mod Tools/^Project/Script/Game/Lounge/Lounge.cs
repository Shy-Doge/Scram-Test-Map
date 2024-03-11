using Bolt;
using UnityEngine;

namespace Scram
{
    [DisallowMultipleComponent]
    public sealed class Lounge : GlobalEventListener
    {
        public static Lounge Instance { get; private set; }

        [SerializeField] private GameModeData gameModeData = null;
        [SerializeField] private PlayerSpawner loungePlayerSpawner = null;

        private void Awake() {}

        private void OnDestroy() {}

        public override void Disconnected(BoltConnection connection) {}

        public void ConnectedDuringWaitingForPlayers() {}

        public void ConnectedDuringIntermission(PlayerConnection connection) {}

        private void WaitForPlayers() {}

        public void StartIntermission() {}

        private void EndIntermission() {}

        private void SpawnAllPlayers() {}

        private void OnPlayerDeath(PlayerConnection connection, Vector3 position, float yaw) {}
    }
}