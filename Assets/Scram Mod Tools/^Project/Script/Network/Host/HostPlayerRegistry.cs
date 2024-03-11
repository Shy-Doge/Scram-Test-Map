using Bolt;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Scram
{
    [DisallowMultipleComponent]
    [BoltGlobalBehaviour(BoltNetworkModes.Server)]
    public sealed class HostPlayerRegistry : MonoBehaviour
    {
        public static HostPlayerRegistry Instance { get; private set; }

        public PlayerConnection ServerPlayerConnection { get; set; }
        public List<PlayerConnection> PlayerConnections { get; private set; }

        private void Awake() {}

        private void OnDestroy() {}

        public void InstantiatePlayerConnection(BoltConnection connection, IProtocolToken serverConnectToken = null, IProtocolToken serverAcceptToken = null) {}

        public void DestroyPlayerConnection(PlayerConnection connection) {}

        public Player InstantiatePlayer(IProtocolToken token, Vector3 position, Quaternion rotation, PlayerConnection connection) 
        {
            return null;
        }

        public void DestroyPlayer(PlayerConnection connection) {}

        public void DestroyAllPlayers() {}
    }
}