using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPro.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int WorldRanking { get; set; }

        #region Overrides
        public override bool Equals(object obj)
        {
            var player = obj as Player;

            if (player == null)
            {
                return false;
            }

            return string.Compare(Name , player.Name, true) == 0;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
