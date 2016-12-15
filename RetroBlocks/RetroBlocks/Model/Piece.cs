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
        private MultiList blockGrid;

        public Piece(EnumPiece kind)
        {
            _kind = kind;
            this.blockGrid = new MultiList(4,4);
            createPiece();
        }


        // Create a new piece based on it's enum type
        private void createPiece()
        {
            if ((_kind = EnumPiece.I) != EnumPiece.O)
            {
                
            }
        }
    }


}
