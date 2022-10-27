using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets.Brains
{
    public class User : IBrain
    {
        public void Run()
        {
            string piece = "", type = "";
            char lr = ' ';
            int pieceX = 0, pieceY = 0;
            bool inputApproved = false;

            ////determines whether a piece moves up or down on the y co-ordinate in  the calculations
            //int updown;
            //if (GV.PVC == 1)
            //    updown = 1;
            //else if (player == "WHITE")
            //    updown = 1;
            //else
            //    updown = -1;

            while (!inputApproved)
            {
                // Select piece
                while (!inputApproved)
                {
                    Console.Write("\nSelect a piece: ");
                    piece = Console.ReadLine().ToUpper();
                    if ((piece.Length > 0) && (piece[0] == player[0]))
                        inputApproved = true;
                    else
                        Console.WriteLine("\nINVALID INPUT: Please select your pawn.");
                }
                inputApproved = false;

                //Checking if piece exsists
                for (int row = 0; row < GV.boardSize; row++)
                {
                    for (int col = 1; col <= GV.boardSize; col++)
                    {
                        if (GV.board[col, row] == piece)
                        {
                            inputApproved = true;
                            //Get position on board
                            pieceX = col;
                            pieceY = row;
                        }
                        if (inputApproved)
                            break;
                    }
                    if (inputApproved)
                        break;
                }
                if (inputApproved == false)
                    Console.WriteLine("\nINVALID INPUT: Pawn selected does not exist.");
            }
            inputApproved = false;

            while (inputApproved == false)
            {
                Console.Write("'Push' or 'Capture': ");
                type = Console.ReadLine().ToLower();

                if ((type != "push") && (type != "capture"))
                    Console.WriteLine("\nINVALID INPUT: Please select 'Push' or 'Capture'.");

                if (type == "push")
                {
                    if (GV.board[pieceX, pieceY + updown] == "--")
                    {
                        inputApproved = true;
                        GV.board[pieceX, pieceY + updown] = GV.board[pieceX, pieceY];
                        GV.board[pieceX, pieceY] = "--";
                    }
                    else
                        Console.WriteLine("\nINVALID MOVE: A pawn is in that position.");
                }
                else if (type == "capture")
                {
                    string pieceToTheLeft, pieceToTheRight;
                    pieceToTheLeft = GV.board[pieceX - 1, pieceY + updown];
                    pieceToTheRight = GV.board[pieceX + 1, pieceY + updown];


                    if ((pieceToTheLeft[0] == opposition[0]) && (pieceToTheRight[0] == opposition[0]))
                    {
                        string LR = "";
                        inputApproved = false;
                        while (inputApproved == false)
                        {
                            Console.Write("Capture left or right: ");
                            LR = Console.ReadLine().ToLower();
                            if ((LR == "left") || (LR == "right"))
                                inputApproved = true;
                            else
                                Console.WriteLine("\nINVALID INPUT: Please select left or right.");
                        }
                        if (LR == "left")
                        {
                            GV.board[pieceX - 1, pieceY + updown] = GV.board[pieceX, pieceY];
                            GV.board[pieceX, pieceY] = "--";
                        }
                        if (LR == "right")
                        {
                            GV.board[pieceX + 1, pieceY + updown] = GV.board[pieceX, pieceY];
                            GV.board[pieceX, pieceY] = "--";
                        }
                        lr = LR.ToUpper()[0];

                        if (opposition == "WHITE")
                            GV.whitePiecesOnBoard--;
                        else if (opposition == "BLACK")
                            GV.blackPiecesOnBoard--;
                    }
                    else if (pieceToTheLeft[0] == opposition[0])
                    {
                        inputApproved = true;
                        GV.board[pieceX - 1, pieceY + updown] = GV.board[pieceX, pieceY];
                        GV.board[pieceX, pieceY] = "--";

                        if (opposition == "WHITE")
                            GV.whitePiecesOnBoard--;
                        else if (opposition == "BLACK")
                            GV.blackPiecesOnBoard--;
                    }
                    else if (pieceToTheRight[0] == opposition[0])
                    {
                        inputApproved = true;
                        GV.board[pieceX + 1, pieceY + updown] = GV.board[pieceX, pieceY];
                        GV.board[pieceX, pieceY] = "--";

                        if (opposition == "WHITE")
                            GV.whitePiecesOnBoard--;
                        else if (opposition == "BLACK")
                            GV.blackPiecesOnBoard--;
                    }
                    else
                        Console.WriteLine("\nINVALID MOVE: No pawn to capture.");
                }

                //CHEATS
                if (type == "stale")
                {
                    inputApproved = true;
                    CheatStalemate();
                }


            }
            Experienced.AddMove(piece, type, lr);
            if (player == "WHITE") Experienced.whiteMoveNum++;
            else if (player == "BLACK") Experienced.blackMoveNum++;
        }
    }
}
