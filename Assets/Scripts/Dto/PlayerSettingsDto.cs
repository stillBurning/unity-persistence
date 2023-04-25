using Assets.Scripts.Data;
using System;

namespace Assets.Scripts.Dto
{
    [Serializable]
    public class PlayerSettingsDto
    {
        public PlayerData CurrentPlayer;

        public PlayerData[] HighScores;
    }
}
