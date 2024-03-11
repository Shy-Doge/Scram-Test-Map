using System;
using System.Collections.Generic;
using Bolt;
using UnityEngine;
using Scram;

namespace Scram
{
	// Token: 0x020000A6 RID: 166
	[DisallowMultipleComponent]
	public sealed class ExterminationGameMode : GameMode
	{

		// Token: 0x0600050F RID: 1295 RVA: 0x0000AE8F File Offset: 0x0000908F
		public override void OnDisconnect(PlayerConnection connection)
		{
			if (BoltNetwork.isServer)
			{
				this.RemovePlayerFromTeam(connection);
			}
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0000AEA2 File Offset: 0x000090A2
		public override void ConnectedDuringPlay(PlayerConnection connection)
		{
			connection.PlayerInfo.state.Team = "Default";
			//HostSpectate.Instance.Spectate(connection, 0);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0003D09C File Offset: 0x0003B29C
		public override void PreStartRound()
		{
			base.PreStartRound();
			this.civilianTeam.PlayerSpawner.ResetSpawns();
			this.exterminatorTeam.PlayerSpawner.ResetSpawns();
			this.SpawnPlayerAndSendObjective("The government is coming! Quick, hide your peanuts!", "Alert", this.civilianTeam);
			this.SpawnPlayerAndSendObjective("The civilians are exposed to radiation. Prepare to breach.", "Alert", this.exterminatorTeam);
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000AEC5 File Offset: 0x000090C5
		public override void StartRound()
		{
			base.StartRound();
			this.SendObjective("They're here! Keep your small butts hidden as long as you can!", "Alert", this.civilianTeam);
			this.SendObjective("They are all exposed! Destroy them!", "Alert", this.exterminatorTeam);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0003D0FC File Offset: 0x0003B2FC
		protected override void ApplyWinner()
		{
			string text = string.Empty;
			for (int i = 0; i < HostPlayerRegistry.Instance.PlayerConnections.Count; i++)
			{
				PlayerConnection playerConnection = HostPlayerRegistry.Instance.PlayerConnections[i];
				IPlayerInfoState state = playerConnection.PlayerInfo.state;
				if (state.Team == text)
				{
					state.Score += this.data.WinScore;
				}
				else
				{
					state.Score += this.data.LoseScore;
				}
			}
			if (this.civilianTeam.Players.Count > 0)
			{
				BoltGlobalEvent.SendObjectiveEvent("The civilians have successfully seduced the government!", "Game Complete", this.civilianTeam.Data.Color);
				text = this.civilianTeam.Data.ID;
			}
			else
			{
				BoltGlobalEvent.SendObjectiveEvent("The civilians were too big to hide properly!", "Game Over", this.exterminatorTeam.Data.Color);
				text = this.exterminatorTeam.Data.ID;
			}
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0003D210 File Offset: 0x0003B410
		public override void SetNewPlayerTeam(PlayerConnection connection)
		{
			int count = HostPlayerRegistry.Instance.PlayerConnections.Count;
			int num = Mathf.CeilToInt(this.exterminatorTeam.Data.Chance * (float)count);
			this.SetPlayerTeam(connection, num);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0003D250 File Offset: 0x0003B450
		public override void ApplyAllPlayerTeams()
		{
			this.civilianTeam.Players.Clear();
			this.exterminatorTeam.Players.Clear();
			List<PlayerConnection> playerConnections = HostPlayerRegistry.Instance.PlayerConnections;
			this.leftOverPlayers.AddRange(playerConnections);
			for (int i = 0; i < playerConnections.Count; i++)
			{
				int num = UnityEngine.Random.Range(0, this.leftOverPlayers.Count);
				this.SetPlayerTeam(this.leftOverPlayers[num], Mathf.CeilToInt(this.exterminatorTeam.Data.Chance * (float)playerConnections.Count));
				this.leftOverPlayers.Remove(this.leftOverPlayers[num]);
			}
			this.leftOverPlayers.Clear();
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000AEF9 File Offset: 0x000090F9
		protected override void OnPlayerDeath(PlayerConnection connection, Vector3 position, float yaw)
		{
			if (BoltNetwork.isClient)
			{
				return;
			}
			this.RemovePlayerFromTeam(connection);
			//Timing.RunCoroutine(HostSpectate.Instance.SpectateWithDelay(connection, 0), "Respawn");
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0003D310 File Offset: 0x0003B510
		private void SetPlayerTeam(PlayerConnection connection, int maxPlayers)
		{
			IPlayerInfoState state = connection.PlayerInfo.state;
			if (this.exterminatorTeam.Players.Count < maxPlayers)
			{
				this.exterminatorTeam.Players.Add(connection);
				state.Color = this.exterminatorTeam.Data.Color;
				state.Team = this.exterminatorTeam.Data.ID;
				BoltGlobalEvent.SendCue(this.exterminatorTeam.Data.Cue, this.exterminatorTeam.Data.Color, connection.BoltConnection);
			}
			else
			{
				this.civilianTeam.Players.Add(connection);
				state.Color = this.civilianTeam.Data.Color;
				state.Team = this.civilianTeam.Data.ID;
				BoltGlobalEvent.SendCue(this.civilianTeam.Data.Cue, this.civilianTeam.Data.Color, connection.BoltConnection);
			}
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0003D414 File Offset: 0x0003B614
		private void RemovePlayerFromTeam(PlayerConnection connection)
		{
			if (this.civilianTeam.Players.Contains(connection))
			{
				this.civilianTeam.Players.Remove(connection);
			}
			else if (this.exterminatorTeam.Players.Contains(connection))
			{
				this.exterminatorTeam.Players.Remove(connection);
			}
			if (connection != null && connection.PlayerInfo != null)
			{
				connection.PlayerInfo.state.Color = this.defaultTeamData.Color;
				connection.PlayerInfo.state.Team = this.defaultTeamData.ID;
			}
			if (this.civilianTeam.Players.Count <= 0 || this.exterminatorTeam.Players.Count <= 0)
			{
				if (Game.Instance.MatchStatus == Game.MatchState.PreStart || Game.Instance.MatchStatus == Game.MatchState.MidRound || Game.Instance.MatchStatus == Game.MatchState.PreEnd)
				{
					this.PreEndRound();
				}
				else if (Game.Instance.MatchStatus == Game.MatchState.Intermission && HostPlayerRegistry.Instance.PlayerConnections.Count >= this.data.MinimumPlayerCount)
				{
					this.ApplyAllPlayerTeams();
				}
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0003D560 File Offset: 0x0003B760
		protected override void SpawnPlayerByTeam(PlayerConnection connection)
		{
			if (connection.PlayerInfo.state.Team == this.civilianTeam.Data.ID)
			{
				this.civilianTeam.PlayerSpawner.Spawn(connection, default(Vector3), 0f);
			}
			else
			{
				this.exterminatorTeam.PlayerSpawner.Spawn(connection, default(Vector3), 0f);
			}
		}

		// Token: 0x040003FE RID: 1022
		[SerializeField]
		private TeamData defaultTeamData;

		// Token: 0x040003FF RID: 1023
		[SerializeField]
		private GameMode.Team civilianTeam;

		// Token: 0x04000400 RID: 1024
		[SerializeField]
		private GameMode.Team exterminatorTeam;

		// Token: 0x04000401 RID: 1025
		private List<PlayerConnection> leftOverPlayers = new List<PlayerConnection>(64);
	}
}
