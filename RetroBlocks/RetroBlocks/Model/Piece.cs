using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetroBlocks.Model
{

   public enum KindPiece
    {
        O,
        I,
        S,
        Z,
        L,
        J,
        T
    }
   
   
    class Piece
    {
        private KindPiece _kind;
        private BlockArray _blockGrid;

        public Piece(KindPiece kind)
        {
            _kind = kind;
            _blockGrid = new BlockArray();
            CreatePiece();
        }

        private void CreatePiece()
        {
            switch (_kind)
            {
                    case KindPiece.I:
                    CreateIPiece();
                    break;
                    case KindPiece.O:
                    CreateOPiece();
                    break;
                    case KindPiece.Z:
                    CreateZPiece();
                    break;
                    case KindPiece.S:
                    CreateSPiece();
                    break;
                    case KindPiece.J:
                    CreateJPiece();
                    break;
                    case KindPiece.L:
                    CreateLPiece();
                    break;
                    case KindPiece.T:
                    CreateTPiece();
                    break;


            }
        }

        /*
       0  1  2  3
   0   -  -  -  -
   1   -  X  X  X
   2   -  -  X  -
   3   -  -  -  -
      */

        private void CreateTPiece()
        {
            _blockGrid.Add(1, 1, new Block(BlockType.BLUE, false));
            _blockGrid.Add(1, 2, new Block(BlockType.BLUE, false));
            _blockGrid.Add(1, 3, new Block(BlockType.BLUE, false));
            _blockGrid.Add(2, 2, new Block(BlockType.BLUE, false));

        }

        /*
      0   1  2  3
  0    -  -  -  -
  1    -  X  X  X
  2    -  X  -  -
  3    -  -  -  -
      */

        private void CreateLPiece()
        {
            _blockGrid.Add(1, 1, new Block(BlockType.LGREEN, false));
            _blockGrid.Add(1, 2, new Block(BlockType.LGREEN, false));
            _blockGrid.Add(1, 3, new Block(BlockType.LGREEN, false));
            _blockGrid.Add(2, 1, new Block(BlockType.LGREEN, false));

        }

        /*
       0  1  2  3
  0    -  -  -  -
  1    -  X  X  X
  2    -  -  -  X
  3    -  -  -  -
      */

        private void CreateJPiece()
        {
            _blockGrid.Add(1, 1, new Block(BlockType.GREEN, false));
            _blockGrid.Add(1, 2, new Block(BlockType.GREEN, false));
            _blockGrid.Add(1, 3, new Block(BlockType.GREEN, false));
            _blockGrid.Add(2, 3, new Block(BlockType.GREEN, false));
        }

        /*
        0  1  2  3
  0     -  -  -  -
  1     -  -  X  X
  2     -  X  X  -
  3     -  -  -  -
       */

        private void CreateSPiece()
        {
            _blockGrid.Add(1, 2, new Block(BlockType.PINK, false));
            _blockGrid.Add(1, 3, new Block(BlockType.PINK, false));
            _blockGrid.Add(2, 1, new Block(BlockType.PINK, false));
            _blockGrid.Add(2, 2, new Block(BlockType.PINK, false));
        }


        /*
         0  1  2  3
      0  -  -  -  -
      1  -  X  X  -
      2  -  -  X  X
      3  -  -  -  -
        */
        private void CreateZPiece()
        {
            _blockGrid.Add(1, 1, new Block(BlockType.RED, false));
            _blockGrid.Add(1, 2, new Block(BlockType.RED, false));
            _blockGrid.Add(2, 2, new Block(BlockType.RED, false));
            _blockGrid.Add(2, 3, new Block(BlockType.RED, false));
        }

        /*
         0  1  2  3
  0      -  -  -  -
  1      -  X  X  -
  2      -  X  X  -
  3      -  -  -  -
        */
        private void CreateOPiece()
        {
            _blockGrid.Add(1,1, new Block(BlockType.YELLOW, false));
            _blockGrid.Add(1,2, new Block(BlockType.YELLOW, false));
            _blockGrid.Add(2,1, new Block(BlockType.YELLOW, false));
            _blockGrid.Add(2,2, new Block(BlockType.YELLOW, false));
        }


        /*
        0  1  2  3
    0   -  -  -  -
    1   X  X  X  X
    2   -  -  -  -
    3   -  -  -  -
        */
        private void CreateIPiece()
        {
           
                _blockGrid.Add(1, 0, new Block(BlockType.LBLUE, false));
                _blockGrid.Add(1, 1, new Block(BlockType.LBLUE, false));
                _blockGrid.Add(1, 2, new Block(BlockType.LBLUE, false));
                _blockGrid.Add(1, 3, new Block(BlockType.LBLUE, false));
        }

        public BlockArray BlockGrid
        {
            get { return _blockGrid; }
        }

        public void RotateLeft()
        {
            // transpose matrix
            _blockGrid.Transpose();
            // reverse each column
            _blockGrid.ReverseAllColums();

            
        }

        public void RotateRight()
        {
            // transpose matrix
            _blockGrid.Transpose();
            // reverse each row
            _blockGrid.ReverseAllRows();
        }
    }


}
