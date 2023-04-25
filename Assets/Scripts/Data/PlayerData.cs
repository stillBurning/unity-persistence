using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PlayerData //:// IComparable<PlayerData>
    {
        public string Name;

        public int Score;

        /*
        public int CompareTo(PlayerData other)
        {
            return Score - other.Score;
        }*/
    }
}
