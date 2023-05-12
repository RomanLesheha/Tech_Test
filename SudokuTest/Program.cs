using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Grid = new int[9, 9]{
            { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
            { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
            { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
            { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
            { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
            { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
            { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
            { 3, 4, 5, 2, 8, 6, 1, 7, 8 } 
            };

        Console.WriteLine(Sudoku(Grid));
        }
        static bool IfContainAllNumber(List<int> list)
        {
            bool Contain = Enumerable.Range(1, 9).All(x => list.Contains(x));
            return Contain;
        }
        static bool CheckGrid3x3(int[,] Grid) 
        {
            for (int i = 0; i < Grid.GetLength(0); i+=3)
            {
                for (int j = 0; j < Grid.GetLength(1); j+=3)
                {
                    List<int> SubGrid = new List<int>();
                    for (int k = i; k < i+3; k++)
                    {
                        for (int m = j; m < j+3; m++)
                        {
                            SubGrid.Add(Grid[k, m]);
                        }
                    }
                    if (!IfContainAllNumber(SubGrid))
                    {
                        return false;
                    }
                    SubGrid.Clear();
                }
            }
            return true;
        }
        static bool CheckRowsColumns(int[,] Grid)
        {
            List<int> temp_columns = new List<int>();
            List<int> temp_rows = new List<int>();
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    temp_rows.Add(Grid[i, j]);
                    temp_columns.Add(Grid[j, i]);
                }
                if (!IfContainAllNumber(temp_rows) && !IfContainAllNumber(temp_columns))
                {
                    return false;
                }
                temp_rows.Clear();
                temp_columns.Clear();
            }
            return true;
        }
        
        static bool Sudoku(int[,]Grid)
        {
            if (CheckRowsColumns(Grid) || CheckGrid3x3(Grid))
                return true;
            return false;
        }
    }
}
