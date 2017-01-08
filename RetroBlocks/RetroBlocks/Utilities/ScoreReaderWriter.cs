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
                //XML document from scratch
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
                XmlText playerHighScore = scoreDocument.CreateTextNode(p.Score + "");
                playerHighScoreElement.AppendChild(playerHighScore);
                playerElement.AppendChild(playerHighScoreElement);

                scoreDocument.Save("HighScore.xml");
            }
            

            

        }

        private void AppendHighScoreToXml(Player player)
        {
            XmlDocument scoreDocument = new XmlDocument();
            scoreDocument.Load("Highscore.xml");
            // Check if player exist in xml
            if (getPlayerFromXml(player) == null)
            {
                
                

                XmlElement playersElement = scoreDocument.CreateElement(string.Empty, "players", string.Empty);
                //scoreDocument.AppendChild(playersElement);
                

                XmlElement playerElement = scoreDocument.CreateElement(string.Empty, "player", string.Empty);
                playersElement.AppendChild(playerElement);

                XmlElement playerNameElement = scoreDocument.CreateElement(string.Empty, "name", string.Empty);
                XmlText playerName = scoreDocument.CreateTextNode(player.Name);
                playerNameElement.AppendChild(playerName);
                playerElement.AppendChild(playerNameElement);

                XmlElement playerHighScoreElement = scoreDocument.CreateElement(string.Empty, "highscore", string.Empty);
                XmlText playerHighScore;
                if (player.HighScore > player.Score)
                {
                    playerHighScore = scoreDocument.CreateTextNode(player.HighScore + "");
                }
                else
                {
                    playerHighScore = scoreDocument.CreateTextNode(player.Score + "");
                }
                
                playerHighScoreElement.AppendChild(playerHighScore);
                playerElement.AppendChild(playerHighScoreElement);

                scoreDocument.Save("HighScore.xml");
            }
            else
            {
                var playerNodes = scoreDocument.GetElementsByTagName("players");
                var playerNodesResult = new List<XmlNode>();

                foreach (XmlNode playerNode in playerNodes)
                {
                    if (playerNode.HasChildNodes)
                    {
                        foreach (XmlNode playerChildNode in playerNode.ChildNodes)
                        {
                            if (playerChildNode.Value.Equals(player))
                            {
                                if (playerChildNode.ChildNodes[1].Name.Equals("highscore"))
                                {
                                    if (Int32.Parse(playerChildNode.ChildNodes[1].Value) < player.Score)
                                    {
                                        playerChildNode.ChildNodes[1].Value = player.Score + "";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public ArrayList GetHighScoresFromXml()
        {
            ArrayList players = new ArrayList();

            return players;
        }

        public Player getPlayerFromXml(Player p)
        {
            if (File.Exists("HighScore.xml"))
            {
                XmlDocument scoreDocument = new XmlDocument();
                scoreDocument.Load("Highscore.xml");
                var playerNodes = scoreDocument.GetElementsByTagName("players");
                var playerNodesResult = new List<XmlNode>();

            }
          
                return null;
            
           

            
        }
    }
}
