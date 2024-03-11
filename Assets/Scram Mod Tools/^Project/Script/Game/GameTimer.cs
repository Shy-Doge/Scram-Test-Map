using System;
using UnityEngine;

namespace Scram
{
    [DisallowMultipleComponent]
    [BoltGlobalBehaviour(BoltNetworkModes.Server)]
    public sealed class GameTimer : MonoBehaviour
    {
        public static GameTimer Instance { get; private set; }

        private int fullTime;
        private double dateTime = 0;

        private void Awake() {}

        private void OnDestroy() {}

        private void Update() {}

        public void StartTimer(int time) {}

        private int GetTime(double dateTime)
        {
            return 0;
        }
    }
}