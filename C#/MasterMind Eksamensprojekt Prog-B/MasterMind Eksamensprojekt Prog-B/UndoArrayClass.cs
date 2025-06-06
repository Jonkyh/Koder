using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Eksamensprojekt_Prog_B
{
    class UndoArrayClass
    {
        public int[,] UndoArr(int[,] arr, int rownum)
        {
            //Creates a bool variable that checks if you have
            //been through a course without a change
            bool dims = true;

            //Checking if it is not the first index in the row.
            //This ensures that you can only remove numbers
            //within the range you are working on
            if (arr[rownum, 0] != 0)
            {
                //makes forloop that looks for a 0-number
                //GetLenght (1) is the number of columns
                //the forloop starts already at the 1st index,
                //since i is 1
                for (int i = 1; i < arr.GetLength(1); i++)
                {
                    //if there is a 0, then we go back an index
                    //and replace the number with 0
                    if (arr[rownum, i] == 0)
                    {
                        //We replace the previous index with 0
                        arr[rownum, i - 1] = 0;
                        //bool is false now, for forloop has been used
                        dims = false;
                        //breaker the course,
                        //for we have finished our task
                        break;
                    }
                }
                //if dims is true, then we remove we automatically
                //convert the last index(3) to 0
                if (dims)
                {
                    arr[rownum, arr.GetLength(1) - 1] = 0;
                }
            }
            //Return array
            return arr;
        }
    }
}