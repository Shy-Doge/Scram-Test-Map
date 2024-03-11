using System;
using Bolt;
using UnityEngine;

namespace Scram
{
	// Token: 0x020000A0 RID: 160
	[DisallowMultipleComponent]
	public sealed class EntryDoor : EntityBehaviour<IGameState>
	{
		// Token: 0x060004E0 RID: 1248 RVA: 0x0000AD30 File Offset: 0x00008F30
		private void Awake()
		{
			this.explosionShake = base.GetComponent<ExplosionShake>();
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0003C3D8 File Offset: 0x0003A5D8
		public override void Attached()
		{
			base.state.AddCallback("HasStartedRound", new PropertyCallbackSimple(this.ToggleDoor));
			if (base.entity.isOwner)
			{
				HostGameAction instance = HostGameAction.Instance;
				instance.OnRoundStart = (Action)Delegate.Combine(instance.OnRoundStart, new Action(delegate ()
				{
					base.state.HasStartedRound = true;
				}));
				HostGameAction instance2 = HostGameAction.Instance;
				instance2.OnRoundEnd = (Action)Delegate.Combine(instance2.OnRoundEnd, new Action(delegate ()
				{
					base.state.HasStartedRound = false;
				}));
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0003C460 File Offset: 0x0003A660
		private void ToggleDoor()
		{
			this.door.SetActive(!base.state.HasStartedRound);
			this.effect.SetActive(base.state.HasStartedRound);
			/*if (base.state.HasStartedRound)
			{
				this.explosionShake.Shake();
			}*/
		}

		// Token: 0x040003E7 RID: 999
		[SerializeField]
		private GameObject door;

		// Token: 0x040003E8 RID: 1000
		[SerializeField]
		private GameObject effect;

		// Token: 0x040003E9 RID: 1001
		private ExplosionShake explosionShake;
	}
}