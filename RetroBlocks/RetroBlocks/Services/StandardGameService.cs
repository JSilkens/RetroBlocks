using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using RetroBlocks.Model;

namespace RetroBlocks.Services
{
    class StandardGameService : GameService
    {
        private double elapsedTime;
        private double duration = 1000; // 1 second in milliseconds
        public StandardGameService(Player playerOne , int level) : base(playerOne ,level)
        {
            
        }

        public StandardGameService(Player playerOne, Player playerTwo , int level) : base(playerOne, playerTwo , level)
        {
        }

        public StandardGameService()
        {
        }

        public void Play(GameTime gameTime)
        {
            elapsedTime +=  gameTime.ElapsedGameTime.TotalMilliseconds;
            //Debug.Print(elapsedTime + "");
            if (elapsedTime >= duration)
            {
                if (Board.IsEmpty())
                {
                    Board.CreateRandomPiece();
                    Board.DropBlock();
                }

                else if (Board.NonPlacedBlocksInBoard())
                {
                    Board.DropBlock();
                }
                else
                {
                    Board.Droplocation = new Vector2(0, 3);
                    Board.CreateRandomPiece();
                    Board.DropBlock();
                }
                Board.PrintBoard();
                elapsedTime = 0;
            }
           
            
                    
        }


        public override void InitializeGame()
        {
            Board = new Board(PlayerOne);
        }

        public Board Board { get; set; }
    }
}
