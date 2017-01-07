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
        private BlockArray _gameBoardArray;
        private Player _player;
        bool _stopDrop = false;
        int rowLoc;
        int colLoc;


        public Board(Player player)
        {
            _player = player;
            _gameBoardArray = new BlockArray(24, 10);
            Droplocation = new Vector2(0,3);
        }

        public void Play()
        {

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
            
           
            int rowCount = _gameBoardArray.RowCount();
            int colCount = _gameBoardArray.ColumnCount();
            //Remove all non placed blocks
            _gameBoardArray.RemoveNonPlaced();

            
            //Draw piece in board
            if (_stopDrop == false)
            {
                for (int i = 0; i < CurrentPiece.BlockGrid.RowCount(); i++)
                {
                    for (int j = 0; j < CurrentPiece.BlockGrid.ColumnCount(); j++)
                    {
                        rowLoc = (int)Droplocation.X + i;
                        colLoc = (int)Droplocation.Y + j;
                        if (rowCount > rowLoc)
                        {
                            if (_gameBoardArray.Get(rowLoc, colLoc).Type == BlockType.EMPTY)
                            {
                                _gameBoardArray.Add(rowLoc, colLoc, CurrentPiece.BlockGrid.Get(i, j));
                            }
                            else
                            {
                                _stopDrop = true;
                            }
                            


                        }
                        else
                        {
                            _stopDrop = true;
                        }

                    }
                }
            }
            

            //Drop the piece further down until the end of the board or when it reached an placed block
            if (_stopDrop)
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
            for (int i = 0; i <_gameBoardArray.RowCount(); i++)
            {
                for (int j = 0; j < _gameBoardArray.ColumnCount(); j++)
                {
                    if (_gameBoardArray.Get(i,j).Type != BlockType.EMPTY)
                    {
                        _gameBoardArray.Get(i,j).IsPlaced = true;
                    }
                }
            }
        }

        public bool NonPlacedBlocksInBoard()
        {
            
            for (int i = 0; i < _gameBoardArray.RowCount(); i++)
            {
                for (int j = 0; j < _gameBoardArray.ColumnCount(); j++)
                {
                    if (_gameBoardArray.Get(i,j).IsPlaced == false && _gameBoardArray.Get(i,j).Type != BlockType.EMPTY)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public bool IsEmpty()
        {
            for (int i = 0; i < _gameBoardArray.RowCount(); i++)
            {
                for (int j = 0; j < _gameBoardArray.ColumnCount(); j++)
                {
                    if (_gameBoardArray.Get(i, j).Type != BlockType.EMPTY)
                    {
                        return false;
                    }
                }
            }


            return true;
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
            Debug.WriteLine(_gameBoardArray.ToString());
            Debug.WriteLine(" == End of board ==");
        }

        public Vector2 Droplocation { get; set; }

        public Piece NextPiece { get; set; }

        public Piece CurrentPiece { get; set; }

        public override string ToString()
        {
           return _gameBoardArray.ToString();
        }
    }
}
