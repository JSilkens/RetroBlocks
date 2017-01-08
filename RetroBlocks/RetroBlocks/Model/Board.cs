using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OpenTK.Graphics.ES10;
using OpenTK.Platform.Windows;

namespace RetroBlocks.Model
{
    class Board
    {
        private Player _player;
        int rowLoc;
        int colLoc;


        public Board(Player player)
        {
            _player = player;
            GameBoardArray = new BlockArray(24, 10);
            Droplocation = new Vector2(0,3);
        }

      

        public void CreateRandomPiece()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 7);

            switch (randomNumber)
            {
                case 1:
                    CurrentPiece = new Piece(KindPiece.L);
                    break;

                case 2:
                    CurrentPiece = new Piece(KindPiece.S);
                    break;

                case 3:
                    CurrentPiece = new Piece(KindPiece.J);
                    break;
                case 4:
                    CurrentPiece = new Piece(KindPiece.O);
                    break;

                case 5:
                    CurrentPiece = new Piece(KindPiece.I);
                    break;
                case 6:
                    CurrentPiece = new Piece(KindPiece.T);
                    break;
                case 7:
                    CurrentPiece = new Piece(KindPiece.Z);
                    break;


            }
        }

        /*
        Drop a block starting from above.
        */
        public void DropBlock()
        {
            
           
            int rowCount = GameBoardArray.RowCount();
            int colCount = GameBoardArray.ColumnCount();
            //Remove all non placed blocks
            GameBoardArray.RemoveNonPlaced();

            
            //Draw piece in board
            if (StopDrop == false)
            {
                for (int i = 0; i < CurrentPiece.BlockGrid.RowCount(); i++)
                {
                    for (int j = 0; j < CurrentPiece.BlockGrid.ColumnCount(); j++)
                    {
                        rowLoc = (int)Droplocation.X + i;
                        colLoc = (int)Droplocation.Y + j;
                        if (rowCount > rowLoc)
                        {
                            if (GameBoardArray.Get(rowLoc, colLoc).Type == BlockType.EMPTY)
                            {
                                GameBoardArray.Add(rowLoc, colLoc, CurrentPiece.BlockGrid.Get(i, j));
                            }
                            else
                            {
                                StopDrop = true;
                            }
                            


                        }
                        else
                        {
                            StopDrop = true;
                        }

                    }
                }
            }
            

            //Drop the piece further down until the end of the board or when it reached an placed block
            if (StopDrop)
            {
                //Set the blocks as placed
                SetBlocksAsPlaced();
            }
            else
            {
                Droplocation = new Vector2(Droplocation.X + 1, Droplocation.Y);
            }
            
            

        }

        private void SetBlocksAsPlaced()
        {
            for (int i = 0; i <GameBoardArray.RowCount(); i++)
            {
                for (int j = 0; j < GameBoardArray.ColumnCount(); j++)
                {
                    if (GameBoardArray.Get(i,j).Type != BlockType.EMPTY)
                    {
                        GameBoardArray.Get(i,j).IsPlaced = true;
                    }
                }
            }
        }

        public bool NonPlacedBlocksInBoard()
        {
            
            for (int i = 0; i < GameBoardArray.RowCount(); i++)
            {
                for (int j = 0; j < GameBoardArray.ColumnCount(); j++)
                {
                    if (GameBoardArray.Get(i,j).IsPlaced == false && GameBoardArray.Get(i,j).Type != BlockType.EMPTY)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public bool IsEmpty()
        {
            for (int i = 0; i < GameBoardArray.RowCount(); i++)
            {
                for (int j = 0; j < GameBoardArray.ColumnCount(); j++)
                {
                    if (GameBoardArray.Get(i, j).Type != BlockType.EMPTY)
                    {
                        return false;
                    }
                }
            }


            return true;
        }

        public int RowHeight(int colNr)
        {
            return GameBoardArray.RowHeight(colNr);
        }

        public int ColHeight(int rowNr)
        {
            return GameBoardArray.ColHeight(rowNr);
        }

       


        /* 
          Function to verify if there are any lines to clear
        */
        public void ClearLine()
        {
            
        }


        /*
        Drop all placed blocks after a line clear 

        */

        public void DropPlacedBlocks()
        {
            
        }

        public void PrintBoard()
        {
            Debug.WriteLine(GameBoardArray.ToString());
            Debug.WriteLine(" == End of board ==");
        }

        public int Height()
        {
            return GameBoardArray.RowCount();
        }

        public int Width()
        {
            return GameBoardArray.ColumnCount();
        }

        public Vector2 Droplocation { get; set; }

        public Piece NextPiece { get; set; }

        public Piece CurrentPiece { get; set; }

        public bool StopDrop { get; set; } = false;

        public BlockArray GameBoardArray { get; set; }

        public override string ToString()
        {
           return GameBoardArray.ToString();
        }
    }
}
