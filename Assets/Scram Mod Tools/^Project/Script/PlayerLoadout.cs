using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scram
{
    public class PlayerLoadout : MonoBehaviour
    {

        public void PickUpGadget(string asdasd, int ass, int monk, int fuck, bool yeah) { }
        public void DropGadget(int yeah, bool ok, bool boomer) { }
    }

    public static class ScramGame
    {
        public sealed class PlayerConnection
        {
            public CSteamID SteamID { get; set; }
            public BoltConnection BoltConnection { get; set; }
            public PlayerInfo PlayerInfo { get; set; }
            public Player Player { get; set; }
        }

        public class CSteamID
        {
            public ulong m_SteamID;
        }


        public static PlayerConnection GetPlayerConnection(this BoltConnection boltConnection)
        {
            return null;
        }
    }
}