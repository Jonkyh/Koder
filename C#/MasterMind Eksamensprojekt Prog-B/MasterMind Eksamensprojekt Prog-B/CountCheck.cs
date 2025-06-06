using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Eksamensprojekt_Prog_B
{
    class CountCheck
    {
        //defining variables
        public int correctlocation;
        public int correctColor;
        public int noCorrect;

        //Class CountCheck being made
        public CountCheck(int[,] arr, int rownums)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[rownums, j] == 2)
                {
                    //black
                    correctlocation++;
                }
                if (arr[rownums, j] == 1)
                {
                    //White
                    correctColor++;
                }
                if (arr[rownums, j] == 0)
                {
                    //Pen squares
                    noCorrect++;
                }
            }
        }
        //Create a method for black
        public int Black()
        {
            return correctlocation;
        }
        //Create a method for white
        public int White()
        {
            return correctColor;
        }
        //Create a method for nothing
        public int Nothing()
        {
            return noCorrect;
        }
    }
}
