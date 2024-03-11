using Bolt;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scram
{
    [DisallowMultipleComponent]
    public sealed class PlayerInfo : EntityBehaviour<IPlayerInfoState>
    {
        public static PlayerInfo Instance { get; private set; }

        public Player MyPlayer { get; set; }

        public override void Attached() {}

        public override void Detached() {}

        public override void ControlGained() {}

        private void OnDestroy() {}
    }
}