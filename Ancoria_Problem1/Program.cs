using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ancoria_Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Get_Cell_State(1, new List<int>() { 1, 0, 0, 0, 0, 1, 0, 0 });
            Get_Cell_State(2, new List<int>() { 1, 1, 1, 0, 1, 1, 1, 1 });
        }

        static private void Get_Cell_State(int Days, List<int> Cells)
        {
            var CellsList = Cells.ToList();
            var CellsNextDay = new List<int>();

            for (int i = 0; i < Days; i++)
            {
                //add zeros to begin and end of the list 
                CellsList.Insert(0, 0);
                CellsList.Insert(CellsList.Count, 0);

                //Delete the previous states from the list 
                CellsNextDay.Clear();

                //start our for loop from the first position to penultimate position 
                for (int z = 1; z < CellsList.Count-1; z++)
                {
                    //check all other cells with the adjacent cells
                    if (CellsList[z + 1] == CellsList[z - 1])
                    {
                        CellsNextDay.Insert(z - 1, 0);
                    }
                    else
                    {
                        CellsNextDay.Insert(z - 1, 1);
                    }
                }

                //clear our current list and fill it with the updated states if there is more than 1 days
                CellsList.Clear();
                CellsList = CellsNextDay.ToList();
            }

            //join the states in the array with ',' delimiter in a string 
            var cellsstateresult = string.Join(",", CellsNextDay);

            //print the states
            Console.WriteLine(cellsstateresult); 
        }
    }
}
