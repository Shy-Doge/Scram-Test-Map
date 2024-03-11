using Bolt;
using System.Collections.Generic;
using UnityEngine;

namespace Scram
{
    [DisallowMultipleComponent]
    public sealed class BoltPooler : MonoBehaviour
    {
        public static BoltPooler Instance { get; private set; }

        private Dictionary<PrefabId, List<BoltEntity>> vacantPools = new Dictionary<PrefabId, List<BoltEntity>>();
        private List<BoltEntity> refreshPools = new List<BoltEntity>();

        private void Start() {}

        private void OnDestroy() {}

        public BoltEntity Instantiate(PrefabId id, IProtocolToken token, Vector3 position, Quaternion rotation, bool canRefresh)
        {
            return null;
        }

        public void Destroy(BoltEntity entity) {}

        public void Destroy(BoltEntity entity, int seconds) {}

        private IEnumerator<float> DelayDestroy(BoltEntity entity, int seconds)
        {
            yield return 0;
        }

        public void Refresh() {}
    }
}