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
            _blockGrid.Add(1, 1, Block.BLUE);
            _blockGrid.Add(1, 2, Block.BLUE);
            _blockGrid.Add(1, 3, Block.BLUE);
            _blockGrid.Add(2, 2, Block.BLUE);

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
            _blockGrid.Add(1, 1, Block.LGREEN);
            _blockGrid.Add(1, 2, Block.LGREEN);
            _blockGrid.Add(1, 3, Block.LGREEN);
            _blockGrid.Add(2, 1, Block.LGREEN);

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
            _blockGrid.Add(1, 1, Block.GREEN);
            _blockGrid.Add(1, 2, Block.GREEN);
            _blockGrid.Add(1, 3, Block.GREEN);
            _blockGrid.Add(2, 3, Block.GREEN);
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
            _blockGrid.Add(1, 2, Block.PINK);
            _blockGrid.Add(1, 3, Block.PINK);
            _blockGrid.Add(2, 1, Block.PINK);
            _blockGrid.Add(2, 2, Block.PINK);
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
            _blockGrid.Add(1, 1, Block.RED);
            _blockGrid.Add(1, 2, Block.RED);
            _blockGrid.Add(2, 2, Block.RED);
            _blockGrid.Add(2, 3, Block.RED);
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
            _blockGrid.Add(1,1,Block.YELLOW);
            _blockGrid.Add(1,2, Block.YELLOW);
            _blockGrid.Add(2,1, Block.YELLOW);
            _blockGrid.Add(2,2, Block.YELLOW);
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
           
                _blockGrid.Add(1, 0,Block.LBLUE);
                _blockGrid.Add(1, 1, Block.LBLUE);
                _blockGrid.Add(1, 2, Block.LBLUE);
                _blockGrid.Add(1, 3, Block.LBLUE);
        }

        public BlockArray BlockGrid
        {
            get { return _blockGrid; }
        }

        public void RotateLeft()
        {
            // transpose matrix
            // reverse each column

            
        }

        public void RotateRight()
        {
            // transpose matrix
            // reverse each row
        }
    }


}
