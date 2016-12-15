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
            _blockGrid.Add(1, 1, Block.YELLOW);
            _blockGrid.Add(1, 2, Block.YELLOW);
            _blockGrid.Add(1, 3, Block.YELLOW);
            _blockGrid.Add(2, 1, Block.YELLOW);

        }

        /*
       -  -  -  -
       -  X  X  X
       -  -  -  X
       -  -  -  -
      */

        private void CreateJPiece()
        {
            _blockGrid.Add(1, 1, Block.YELLOW);
            _blockGrid.Add(1, 2, Block.YELLOW);
            _blockGrid.Add(1, 2, Block.YELLOW);
            _blockGrid.Add(2, 2, Block.YELLOW);
        }

        /*
        -  -  -  -
        -  -  X  X
        -  X  X  -
        -  -  -  -
       */

        private void CreateSPiece()
        {
            _blockGrid.Add(1, 1, Block.YELLOW);
            _blockGrid.Add(1, 2, Block.YELLOW);
            _blockGrid.Add(1, 2, Block.YELLOW);
            _blockGrid.Add(2, 2, Block.YELLOW);
        }


        /*
         -  -  -  -
         -  X  X  -
         -  -  X  X
         -  -  -  -
        */
        private void CreateZPiece()
        {
            throw new NotImplementedException();
        }

        /*
         -  -  -  -
         -  X  X  -
         -  X  X  -
         -  -  -  -
        */
        private void CreateOPiece()
        {
            _blockGrid.Add(1,1,Block.YELLOW);
            _blockGrid.Add(1,2, Block.YELLOW);
            _blockGrid.Add(1,2, Block.YELLOW);
            _blockGrid.Add(2,2, Block.YELLOW);
        }


        /*
        -  -  -  -
        X  X  X  X
        -  -  -  -
        -  -  -  -
        */
        private void CreateIPiece()
        {
           
                _blockGrid.Add(1, 0,Block.BLUE);
                _blockGrid.Add(1, 1, Block.BLUE);
                _blockGrid.Add(1, 2, Block.BLUE);
                _blockGrid.Add(1, 3, Block.BLUE);
        }

        public BlockArray BlockGrid
        {
            get { return _blockGrid; }
        }

        public void RotateLeft()
        {
            
        }

        public void RotateRight()
        {
            
        }
    }


}
