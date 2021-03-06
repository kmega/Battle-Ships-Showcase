﻿using System;
using System.Collections.Generic;

namespace BattleShips
{
    internal class UI
    {
        internal static void BoardStatus(CellStatus[,] board, ConsoleColor playerColor, List<List<int[]>> enemyShips, int playerNumber)
        {
            string player;
            string enemyShipsStatus = "";

            if (playerNumber == 1)
            {
                playerColor = ConsoleColor.Green;
                player = "One";
            }
            else
            {
                playerColor = ConsoleColor.Cyan;
                player = "Two";
            }

            if (enemyShips.Count != 0)
            {
                for (int i = 0; i < enemyShips.Count; i++)
                {
                    if (i == enemyShips.Count - 1)
                    {
                        enemyShipsStatus += enemyShips[i].Count.ToString();
                    }
                    else
                    {
                        enemyShipsStatus += enemyShips[i].Count.ToString() + ", ";
                    }

                }
            }
            else
            {
                enemyShipsStatus = "0";
            }

            Console.Write("\n [ ");
            Console.ForegroundColor = playerColor;
            Console.Write("Player " + player);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ] --- Opponent ships remaining: " + enemyShipsStatus + "\n\n     ");
            Console.ForegroundColor = playerColor;
            Console.Write("1 2 3 4 5 6 7 8 9 10\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ------------------------");

            for (int column = 0; column < 10; column++)
            {
                WriteLetter(column, playerColor);

                for (int row = 0; row < 10; row++)
                {
                    WriteRowOfCells(board, column, row);
                }

                WriteInstructions(column);

                Console.Write(Environment.NewLine);
            }
        }

        private static void WriteLetter(int column, ConsoleColor playerColor)
        {
            Console.ForegroundColor = playerColor;
            switch (column)
            {
                case 0:
                    Console.Write(" A ");
                    break;
                case 1:
                    Console.Write(" B ");
                    break;
                case 2:
                    Console.Write(" C ");
                    break;
                case 3:
                    Console.Write(" D ");
                    break;
                case 4:
                    Console.Write(" E ");
                    break;
                case 5:
                    Console.Write(" F ");
                    break;
                case 6:
                    Console.Write(" G ");
                    break;
                case 7:
                    Console.Write(" H ");
                    break;
                case 8:
                    Console.Write(" I ");
                    break;
                case 9:
                    Console.Write(" J ");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("| ");
        }

        private static void WriteRowOfCells(CellStatus[,] board, int column, int row)
        {
            switch (board[column, row])
            {
                case CellStatus.Empty:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("  ");
                    break;
                case CellStatus.Occupied:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("  ");
                    break;
                case CellStatus.Blocked:
                    Console.Write("  ");
                    break;
                case CellStatus.Hit:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  ");
                    break;
                case CellStatus.Fired:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("  ");
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void WriteInstructions(int column)
        {
            switch (column)
            {
                case 0:
                    Console.Write("\t");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" - Cell is empty.");
                    break;
                case 1:
                    Console.Write("\t");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" - Cell is occupied by a ship.");
                    break;
                case 2:
                    Console.Write("\t   - Cell is blocked.");
                    break;
                case 3:
                    Console.Write("\t");
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" - Cell was hit / Enemy ship was hit.");
                    break;
                case 4:
                    Console.Write("\t");
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" - Cell was fired upon.");
                    break;
            }
        }
    }
}