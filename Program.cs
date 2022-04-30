using System;
using System.Collections.Generic;

namespace Cse210Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string firstPlayer = "x";

            while (!Gameover(board))
            {
                // Display bord 
                DisplayBoard(board);
                
                // ask for player's choice
                int choice = PlayerChoice(firstPlayer);
                
                // change int to player's mark 
                PlayerMake(board, choice, firstPlayer);

                // player take turn
                firstPlayer = SwitchPlayer(firstPlayer);
            }
            DisplayBoard(board);
            Console.WriteLine("The game is over. Thank for playing");
        }
        // Funtion for the board 
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine(board[0] + "|" + board[1] + "|" + board[2] + "\n" + "-" + "+" + "-" + "+", "\n");

            Console.WriteLine(board[3] + "|" + board[4] + "|" + board[5] + "\n" + "-" + "+" + "-" + "+", "\n");
    
            Console.WriteLine(board[6] + "|" + board[7] + "|" + board[8]);
        }
        
        // get input 
        static int PlayerChoice(string firstPlayer)
        {
           Console.Write($"{firstPlayer} 's turn to choose a square (1-9): "); 
           string Uchoice = Console.ReadLine();

           int choice = int.Parse(Uchoice);
           return choice;
        }
        
        // player's turn 
        static string SwitchPlayer(string firstPlayer)
        {
            string SecPlayer = "x";

            if (firstPlayer == "x")
            {
                SecPlayer = "o";
            }
            return SecPlayer;
        }

       
       // determine the winnner
       static bool TheWinner(List<string> board, string Player)
       {
           bool TheWinner = false;
           
           if ((board [0] == Player && board [1] == Player && board [2] == Player )
                ||(board [3] == Player && board [4] == Player && board [5] == Player )
                ||(board [6] == Player && board [7] == Player && board [8] == Player )
                ||(board [0] == Player && board [3] == Player && board [6] == Player )
                ||(board [1] == Player && board [4] == Player && board [7] == Player )
                ||(board [2] == Player && board [5] == Player && board [8] == Player )
                ||(board [0] == Player && board [4] == Player && board [8] == Player )
                ||(board [2] == Player && board [4] == Player && board [6] == Player ))
            {
                TheWinner = true;
            }
            return TheWinner;
       }

       // if it a tie 
       static bool IsTie(List<string> board)
       {
           bool space = false;
        
           foreach (string value in board)
           {
               if(char.IsDigit(value[0]))
               {
                   space = true;
                   break;
               }
           }
           return !space;
       }

       // Game is over 
       static bool Gameover(List<string> board)
       {
           bool Gameover = false;

           if (TheWinner(board, "x" ) || TheWinner(board, "o") || IsTie (board))
           {
               Gameover = true;
           }
           return Gameover;
       }

        // Put the player's make on the board 
        static void PlayerMake(List<String> board, int choice, string firstPlayer)
        {
            int index = choice - 1;
            board[index] = firstPlayer;
        }
    }
}


