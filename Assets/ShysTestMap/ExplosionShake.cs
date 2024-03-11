using System;
using UnityEngine;

namespace Scram
{
	// Token: 0x02000009 RID: 9
	[DisallowMultipleComponent]
	public sealed class ExplosionShake : MonoBehaviour
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00008067 File Offset: 0x00006267
		private void Awake()
		{
			this.cachedTransform = base.transform;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000290D4 File Offset: 0x000272D4
		public void Shake()
		{
			Collider[] array = Physics.OverlapSphere(this.cachedTransform.position, this.explosionRadius, this.playerLayerMask);
			for (int i = 0; i < array.Length; i++)
			{
				Player component = array[i].GetComponent<Player>();
				if (component != null)
				{
					component.state.Effect.ShakeScreen();
				}
			}
		}

		// Token: 0x0400001E RID: 30
		[SerializeField]
		private float explosionRadius = 20f;

		// Token: 0x0400001F RID: 31
		[SerializeField]
		private LayerMask playerLayerMask = default(LayerMask);

		// Token: 0x04000020 RID: 32
		private Transform cachedTransform;
	}
}
