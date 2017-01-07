using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.IO;
using System.Xml;
using RetroBlocks.Model;

namespace RetroBlocks.Utilities
{
    class ScoreReaderWriter
    {
        public void WriteHighScoreToXml(Player p)
        {
            if (File.Exists("HighScore.xml"))
            {
                AppendHighScoreToXml(p);
            }
            else
            {
                XmlDocument scoreDocument = new XmlDocument();
                XmlDeclaration declaration = scoreDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement rootNode = scoreDocument.DocumentElement;
                scoreDocument.InsertBefore(declaration, rootNode);

                XmlElement playersElement = scoreDocument.CreateElement(string.Empty, "players", string.Empty);
                scoreDocument.AppendChild(playersElement);

                XmlElement playerElement = scoreDocument.CreateElement(string.Empty, "player", string.Empty);
                playersElement.AppendChild(playerElement);

                XmlElement playerNameElement = scoreDocument.CreateElement(string.Empty, "name", string.Empty);
                XmlText playerName = scoreDocument.CreateTextNode(p.Name);
                playerNameElement.AppendChild(playerName);
                playerElement.AppendChild(playerNameElement);

                XmlElement playerHighScoreElement = scoreDocument.CreateElement(string.Empty, "highscore", string.Empty);
                XmlText playerHighScore = scoreDocument.CreateTextNode(p.HighScore + "");
                playerNameElement.AppendChild(playerHighScore);
                playerElement.AppendChild(playerHighScoreElement);

                scoreDocument.Save("HighScore.xml");
            }
            

            

        }

        private void AppendHighScoreToXml(Player player)
        {
            
        }

        private ArrayList GetHighScoresFromXml()
        {
            ArrayList players = new ArrayList();

            return players;
        } 
    }
}
