using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Eksamensprojekt_Prog_B
{
    class NumberInArrayClass
    {
        public int[,] UpdateArr(int[,] arr, int num, int rownum)
        {
            //Makes one for loops looking for a 0 number and
            //replaces this number with the selected number (num)
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[rownum, j] == 0)
                {
                    //We replace 0 with the number (num)
                    arr[rownum, j] = num;
                    //break for a change has been made
                    break;
                }
            }
            //Return the array
            return arr;
        }
    }
}
