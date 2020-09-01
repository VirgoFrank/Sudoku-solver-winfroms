using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Board
    {
        public static int[,] board =
         {
                { 7, 8, 0, 4, 0, 0, 1, 2 ,0},
                { 6, 0, 0, 0, 7, 5, 0, 0, 9},
                { 0, 0, 0, 6, 0, 1, 0, 7, 8},
                { 0, 0, 7, 0, 4, 0, 2, 6, 0},
                { 0, 0, 1, 0, 5, 0, 9, 3, 0},
                { 9, 0, 4, 0, 6, 0, 0, 0, 5},
                { 0, 7, 0, 3, 0, 0, 0, 1, 2},
                { 1, 2, 0, 0, 0, 7, 4, 0, 0},
                { 0, 4, 9, 2, 0, 6, 0, 0, 7}
        };

        public bool Solve()
        {
            int[] empty = FindEmpty();
            if (empty == null)
                return true;

            for (int i = 1; i < 10; i++)
            {
                if (check(empty[1], empty[0], i))
                {
                    board[empty[0], empty[1]] = i;
                    if (Solve())
                        return true;
                    board[empty[0], empty[1]] = 0;
                }

            }
            return false;

        }

        int[] FindEmpty()
        {
            int[] EmptySpaceLocation = new int[2];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        EmptySpaceLocation[0] = i;
                        EmptySpaceLocation[1] = j;

                        return EmptySpaceLocation;
                    }

                }
            }
            return null;
        }

        public string[] ComboBoxData(int col, int row)
        {
            string[] data = new string[9];
            int counter = 0;
            for (int i = 1; i < 10; i++)
            {
                if (check(col, row, i))
                {
                    data[counter] = i.ToString();
                    counter++;
                }

            }
            string[] data2 = new string[counter];
            for (int i = 0; i < data.Length; i++)
            {
                if(data[i] != null)
                data2[i] = data[i];
            }
            return data2;

        }

        public bool check(int col, int row, int num)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[row, i] == num)
                    return false;
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[i, col] == num)
                    return false;
            }

            for (int i = row / 3 * 3; i < row / 3 * 3 + 3; i++)
            {
                for (int j = col / 3 * 3; j < col / 3 * 3 + 3; j++)
                {
                    if (board[i, j] == num)
                        return false;
                }

            }
            return true;

        }

    }
}
