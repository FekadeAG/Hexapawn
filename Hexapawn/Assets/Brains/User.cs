using System;
using System.Collections.Generic;
using System.Text;
using Hexapawn.Assets.Pieces;

namespace Hexapawn.Assets.Brains
{
    public class User : IBrain
    {
        private GameState gameState { get; set; }
        private Player player { get; set; }

        public User(Player player)
        {
            gameState = GameState.GetInstance();
            this.player = player;
        }

        public void Run()
        {
            string piece = "", move = "";
            int pieceX = 0, pieceY = 0;

            Display.Board();

            bool inputValid = false, inputExist = false, inputApproved = false;
            while (!inputApproved)
            {
                // Select piece
                while (!inputValid)
                {
                    Console.Write($"\nSelect a piece i.e. '{player.Color[0]}1': ");
                    string input = Console.ReadLine().ToUpper();
                    try
                    {
                        //is first character of input the correct color
                        bool isCorrectColor = false;
                        if (input[0] == player.Color[0])
                        {
                            isCorrectColor = true;
                            piece = input;
                        }

                        //are following charcters a number
                        bool hasPieceNumber = int.TryParse(input.Substring(1), out int n);

                        if (!isCorrectColor && !hasPieceNumber)
                            Console.WriteLine($"INVALID INPUT: Please select the correct color ('{player.Color[0]}') and a valid piece number");
                        else if (!isCorrectColor)
                            Console.WriteLine($"INVALID INPUT: Please select the correct color ('{player.Color[0]}')");
                        else if (!hasPieceNumber)
                            Console.WriteLine("INVALID INPUT: Please select a valid piece number");
                        else
                            inputValid = true;
                    }
                    catch (IndexOutOfRangeException) { }
                }

                //Checking if piece exsists
                if (inputValid)
                {
                    GameState state = GameState.GetInstance();
                    for (int row = 0; row < state.Board.Size; row++)
                    {
                        for (int col = 0; col < state.Board.Size; col++)
                        {
                            if (state.Board.Content[col, row].ToString() == piece)
                            {
                                inputExist = true;
                                pieceX = col;
                                pieceY = row;
                                break;
                            }
                        }
                        if (inputExist)
                            break;
                    }
                    if (!inputExist)
                        Console.WriteLine("\nINVALID INPUT: Pawn selected is not on the board.");
                }

                if (inputValid && inputExist)
                    inputApproved = true;
            }

            bool moveCompleted = false;
            while (!moveCompleted)
            {
                int updown = 1;
                if (player.Color == ConsoleColor.Black.ToString())
                    updown = -1;

                Console.Write("'Push' or 'Capture': ");
                move = Console.ReadLine().ToLower();
                if ((move != "push") && (move != "capture"))
                    Console.WriteLine("\nINVALID INPUT: Please select 'Push' or 'Capture'.");
                else if (move == "push")
                {
                    if (gameState.Board.Content[pieceX, pieceY + updown].Type == PieceType.NullPiece)
                    {
                        gameState.Board.Content[pieceX, pieceY + updown] = gameState.Board.Content[pieceX, pieceY];
                        gameState.Board.Content[pieceX, pieceY] = new NullPiece();
                        moveCompleted = true;
                    }
                    else
                        Console.WriteLine("\nINVALID MOVE: A pawn is in that position.");
                }
                else if (move == "capture")
                {
                    bool pieceToTheLeft = false;
                    bool pieceToTheRight = false;
                    try
                    {
                        Piece hold = gameState.Board.Content[pieceX - 1, pieceY + updown];
                        if (hold.Type != PieceType.NullPiece && !player.MyPawns.Contains(hold))
                            pieceToTheLeft = true;
                    }
                    catch(IndexOutOfRangeException) { }
                    try
                    {
                        Piece hold = gameState.Board.Content[pieceX + 1, pieceY + updown];
                        if (hold.Type != PieceType.NullPiece && !player.MyPawns.Contains(hold))
                            pieceToTheRight = true;
                    }
                    catch (IndexOutOfRangeException) { }

                    if (pieceToTheLeft || pieceToTheRight)
                    {
                        int x = -1; //left
                        if (pieceToTheLeft && pieceToTheRight)
                        {
                            string captureLR = "";
                            inputApproved = false;
                            while (inputApproved == false)
                            {
                                Console.Write("Capture left or right: ");
                                captureLR = Console.ReadLine().ToLower();
                                if ((captureLR == "left") || (captureLR == "right"))
                                    inputApproved = true;
                                else
                                    Console.WriteLine("\nINVALID INPUT: Please select left or right.");
                            }
                            if (captureLR == "right")
                                x = 1;
                        }
                        else if (pieceToTheRight)
                            x = 1;
                        gameState.Board.Content[pieceX + x, pieceY + updown].IsCaptured = true;
                        gameState.Board.Content[pieceX + x, pieceY + updown] = gameState.Board.Content[pieceX, pieceY];
                        gameState.Board.Content[pieceX, pieceY] = new NullPiece();
                        moveCompleted = true;
                    }
                    else
                        Console.WriteLine("\nINVALID MOVE: No pawns to capture.");
                }
            }
        }
    }
}
