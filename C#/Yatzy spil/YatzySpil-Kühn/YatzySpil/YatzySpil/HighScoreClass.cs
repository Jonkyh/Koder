using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzySpil
{
    public class HighScoreClass
    {
        public string PartName;
        public int PartScore;

        public HighScoreClass(string navn, int score)
        {
            PartName = navn;
            PartScore = score;
        }

        public string Navn()
        {
            return PartName;
        }

        public int Score()
        {
            return PartScore;
        }

        public int CompareTo(HighScoreClass comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.PartScore.CompareTo(comparePart.PartScore);
        }
        public override int GetHashCode()
        {
            return PartScore;
        }
    }
}
