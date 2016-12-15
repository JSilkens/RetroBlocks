using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBlocks.Model
{
    class Player
    {
        private int _score;
        private int _highScore;
        private String _name;

        public Player(string name)
        {
            Name = name;
            _score = 0;
        }

        public int Score
        {
            get { return _score; }
            set
            {
                if (Score < 0 )
                {
                    throw new ArgumentException("Score cannot be lower than zero.");
                }
                else
                {
                    _score = value;
                }
                
            }
        }

        public int HighScore
        {
            get { return _highScore; }
            set { _highScore = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(Name))
                {
                    throw new ArgumentException("Player name cannot be empty");
                }
                _name = value;
            }
        }
    }
}
