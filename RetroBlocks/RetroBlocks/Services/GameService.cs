using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroBlocks.Model;

namespace RetroBlocks.Services
{
    public abstract class GameService
    {
        BlockManager _blockManager;
        public bool InGame = false;

        public GameService(Player playerOne,int level)
        {
            PlayerOne = playerOne;
            _blockManager = new BlockManager();
        }

        public GameService(Player playerOne, Player playerTwo , int level)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            _blockManager = new BlockManager();
        }

        public GameService()
        {
            _blockManager = new BlockManager();
        }

        public Player PlayerOne { get; set; }

        public Player PlayerTwo { get; set; }

        public int Level { get; set; }

        public void StartGame()
        {
            InGame = true;
        }

        public Player WonGame()
        {
            InGame = false;
            return null;
        }

        public Player LostGame()
        {
            InGame = false;
            return null;
        }

        public abstract void InitializeGame();
       

    }
}
