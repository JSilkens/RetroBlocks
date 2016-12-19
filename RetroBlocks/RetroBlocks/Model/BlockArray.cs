using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace RetroBlocks.Model
{
    class BlockArray
    {
        private Block[,] _blockArray;
        public BlockArray()
        {
            //by default create a 4x4 array
            _blockArray = new Block[4, 4];

        }

        public BlockArray(int height,int width)
        {
            _blockArray = new Block[width,height];
        }


        public Block Get(int x, int y)
        {
            return _blockArray[x, y];

    
        }

        public void Add(int x, int y, Block b)
        {
            _blockArray[x, y] = b;
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

            for (int i = 0; i <= _blockArray.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= _blockArray.GetUpperBound(0) / 2; j++)
                {
                    Block tempBlock = _blockArray[i, j];
                    _blockArray[j, i] = _blockArray[_blockArray.GetUpperBound(1) - j, i ];
                    _blockArray[_blockArray.GetUpperBound(1) - j, i] = tempBlock;



                }
            }

        }


        public override String ToString()
        {
            String output = "";

            for (int i = 0; i < _blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < _blockArray.GetLength(1); j++)
                {
                    output += _blockArray[i, j] + ", ";
                }

                output += "\n";
            }

            return output;

        }

       


    }
}
