//using Steamworks;

namespace Scram
{
    public sealed class PlayerConnection
    {
        //public CSteamID SteamID { get; set; }
        public BoltConnection BoltConnection { get; set; }
        public PlayerInfo PlayerInfo { get; set; }
        public Player Player { get; set; }
    }
}