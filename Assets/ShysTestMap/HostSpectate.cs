using System;
using System.Collections.Generic;
using Bolt;
//using MEC;
using UnityEngine;

namespace Scram
{
	// Token: 0x02000140 RID: 320
	[DisallowMultipleComponent]
	public sealed class HostSpectate : GlobalEventListener
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0000C9CB File Offset: 0x0000ABCB
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x0000C9D2 File Offset: 0x0000ABD2
		public static HostSpectate Instance { get; private set; }

		// Token: 0x0600084F RID: 2127 RVA: 0x0000C9DA File Offset: 0x0000ABDA
		private void Awake()
		{
			HostSpectate.Instance = this;
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0000C9E2 File Offset: 0x0000ABE2
		private void OnDestroy()
		{
			HostSpectate.Instance = null;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0004ACC0 File Offset: 0x00048EC0
		public override void OnEvent(SpectateRequestEvent evnt)
		{
			this.CheckForAlivePlayers();
			int num = ++evnt.PlayerIndex;
			int num2 = ((num < 0 || num > this.alivePlayers.Count - 1) ? 0 : num);
			if (evnt.HasDelay)
			{
				//this.SpectateWithDelay(evnt.RaisedBy.GetPlayerConnection(), num2);
			}
			else
			{
				//this.Spectate(evnt.RaisedBy.GetPlayerConnection(), num2);
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0004AD3C File Offset: 0x00048F3C
		public void Spectate(PlayerConnection spectator, int index = 0)
		{
			if (Game.Instance.MatchStatus != Game.MatchState.PreStart && Game.Instance.MatchStatus != Game.MatchState.MidRound && Game.Instance.MatchStatus != Game.MatchState.PreEnd)
			{
				return;
			}
			this.CheckForAlivePlayers();
			if (HostPlayerRegistry.Instance.PlayerConnections.Count > 0)
			{
				int num = ((index < 0 || index > this.alivePlayers.Count - 1) ? 0 : index);
				Player player = this.alivePlayers[num];
				BoltGlobalEvent.SendSpectate(index, player.entity.networkId, spectator.BoltConnection);
				BoltGlobalEvent.SendCue("Spectating: " + player.state.PenName, Color.white, spectator.BoltConnection);
			}
			else
			{
				BoltGlobalEvent.SendSpectate(-1, default(NetworkId), spectator.BoltConnection);
				BoltGlobalEvent.SendCue("Spectating: The World", Color.white, spectator.BoltConnection);
			}
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0004AE3C File Offset: 0x0004903C
		private void CheckForAlivePlayers()
		{
			this.alivePlayers.Clear();
			List<PlayerConnection> playerConnections = HostPlayerRegistry.Instance.PlayerConnections;
			for (int i = 0; i < playerConnections.Count; i++)
			{
				if (playerConnections[i].Player != null)
				{
					this.alivePlayers.Add(playerConnections[i].Player);
				}
			}
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0004AEA4 File Offset: 0x000490A4
		public IEnumerator<float> SpectateWithDelay(PlayerConnection connection, int playerIndex = 0)
		{
			double currentTime = TimeController.GetTime();
			//yield return Timing.WaitUntilTrue(() => TimeController.GetTime(currentTime) >= (double)this.gameModeData.SpectateDelayTime);
			if (this == null || connection == null)
			{
				yield break;
			}
			this.Spectate(connection, playerIndex);
			yield break;
		}

		// Token: 0x04000701 RID: 1793
		[SerializeField]
		private GameModeData gameModeData;

		// Token: 0x04000702 RID: 1794
		private List<Player> alivePlayers = new List<Player>();
	}
}
