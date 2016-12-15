using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetroBlocks.Model
{

   public enum EnumPiece
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
        private EnumPiece _kind;
        private BlockArray _blockGrid;

        public Piece(EnumPiece kind)
        {
            _kind = kind;
            _blockGrid = new BlockArray();
            createPiece();
        }

        private void createPiece()
        {
            if (_kind == EnumPiece.I)
            {
                createIPiece();
            } else if (_kind == EnumPiece.O)
            {
                createOPiece();
            }
        }
        //create an O piece
        private void createOPiece()
        {
            _blockGrid.Add(1,1,Block.YELLOW);
            _blockGrid.Add(1,2, Block.YELLOW);
            _blockGrid.Add(1,2, Block.YELLOW);
            _blockGrid.Add(2,2, Block.YELLOW);
        }


        // Create an I piece
        private void createIPiece()
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
