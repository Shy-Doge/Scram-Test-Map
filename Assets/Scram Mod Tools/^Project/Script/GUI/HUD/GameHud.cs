using Bolt;
using System.Collections.Generic;
using UnityEngine;

namespace Scram
{
    [DisallowMultipleComponent]
    public sealed class GameHud : EntityBehaviour<IGameState>
    {
        public static GameHud Instance { get; private set; }

        private int activeBread = 0;

        private void Awake() {}

        private void OnDestroy() {}

        public override void Attached() {}

        public void HideGUI() {}

        private void ApplyTimer() {}

        private void ApplyStatus() {}

        public void SetBread(int amount) {}

        public void SetCue(string text, Color32 color) {}

        public void SetObjective(string text, string audioClip, Color32 color) {}

        private IEnumerator<float> FadeBread()
        {
            yield return 0;
        }

        private IEnumerator<float> SetNewObjective(string text, string audioClip, Color32 color)
        {
            yield return 0;
        }
    }
}