using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBlocks.Model
{
    class Board
    {
        private BlockArray _gameBoardArray;
        private Player _player;
        private Piece _nextPiece;


        public Board(Player player)
        {
            this._player = player;
            _gameBoardArray = new BlockArray(24, 10);
        }

        public void Play()
        {

        }

        /*
        Drop a block starting from above.
        */
        public void DropBlock()
        {
            
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


    }
}
