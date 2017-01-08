using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace RetroBlocks.Model
{
    public class BlockArray
    {
        private Block[,] _blockArray;
        public BlockArray()
        {
            //by default create a 4x4 array
            _blockArray = new Block[4, 4];
            Fill();

        }

        public BlockArray(int row,int col)
        {
            _blockArray = new Block[row,col];
            Fill();
        }


        public Block Get(int row, int col)
        {
            return _blockArray[row, col]; 

    
        }

        private void Fill()
        {
            for (int i = 0; i < _blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < _blockArray.GetLength(1); j++)
                {
                    _blockArray[i,j] = new Block(BlockType.EMPTY, false);
                }
            }
        }

        public int RowCount()
        {
            return _blockArray.GetLength(0);
        }

        public int ColumnCount()
        {
            return _blockArray.GetLength(1);
        }

        public void Add(int x, int y, Block b)
        {
            if (b.Type != BlockType.EMPTY)
            {
                _blockArray[x, y] = b;
            }
            
        }

        public void RemoveNonPlaced()
        {
            for (int i = 0; i < _blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < _blockArray.GetLength(1); j++)
                {
                    if (_blockArray[i, j].Type != BlockType.EMPTY && _blockArray[i, j].IsPlaced == false)
                    {
                        _blockArray[i, j] = new Block(BlockType.EMPTY, false);
                    }
                }
            }
        }


        public void Transpose()
        {
            Block[,] newBlockArray = new Block[_blockArray.GetLength(0),_blockArray.GetLength(1)];
            for (int i = 0; i < _blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < _blockArray.GetLength(1); j++)
                {
                    newBlockArray[i, j] = _blockArray[j, i];
                }
            }

            _blockArray = newBlockArray;

        }

        public void ReverseAllRows()
        {
            for (int i = 0; i <= _blockArray.GetUpperBound(0) ; i++)
            {
                for (int j = 0; j <= _blockArray.GetUpperBound(1) /2 ; j++)
                {
                    Block tempBlock = _blockArray[i, j];
                    _blockArray[i, j] = _blockArray[i, _blockArray.GetUpperBound(1) - j];
                    _blockArray[i, _blockArray.GetUpperBound(1) - j] = tempBlock;



                }
            }
        }

        public void ReverseAllColums()
        {

//            for (int i = 0; i <= _blockArray.GetUpperBound(1); i++)
//            {
//                for (int j = 0; j <= _blockArray.GetUpperBound(0) / 2; j++)
//                {
//                    Block tempBlock = _blockArray[i, j];
//                    _blockArray[j, i] = _blockArray[_blockArray.GetUpperBound(1) - j, i ];
//                    _blockArray[_blockArray.GetUpperBound(1) - j, i] = tempBlock;
//
//
//
//                }
//            }

        }

        public int ColHeight(int rowNr)
        {
            int count = 0;

            for (int i = 0; i < RowCount(); i++)
            {
                if (_blockArray[rowNr, i].IsPlaced && _blockArray[rowNr, i].Type != BlockType.EMPTY)
                {
                    count++;
                }
            }
            return count;
        }

        public int RowHeight(int colNr)
        {
            int count = 0;

            for (int i = 0; i < RowCount(); i++)
            {
                if (_blockArray[i, colNr].IsPlaced)
                {
                    count++;
                }
            }
            return count;
        }


        public override String ToString()
        {
            String output = "";

            for (int i = 0; i < _blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < _blockArray.GetLength(1); j++)
                {
                    if (_blockArray[i, j].Type == BlockType.EMPTY)
                    {
                        output += ". ";
                    }
                    else
                    {
                        output += "x ";
                    }
                    //output += _blockArray[i, j] + ", ";
                }

                output += "\n";
            }

            for (int i = 0; i < _blockArray.GetLength(1); i++)
            {
                output += RowHeight(i) + " ";
            }

            output += "\n";

            return output;

        }

       


    }
}
