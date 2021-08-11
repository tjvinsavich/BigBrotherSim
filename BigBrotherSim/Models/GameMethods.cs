using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Models
{
    public class GameMethods : IGameMethods
    {
        public void evictionNight()
        {
            //everyone but HoH and noms vote, while loop of 50% RNG for each vote
            //loser is deleted from playerList/database (or we just update the DB to note that they were evicted oooo, yeah think the wiki page, and playerCount--
        }

        public void initialNoms()
        {
            var random = new Random();
            //we start them as currentHoh to enter the loop
            GamePieces.firstNom = GamePieces.currentHoh;
            GamePieces.secondNom = GamePieces.currentHoh;

            while (GamePieces.firstNom == GamePieces.currentHoh)
            {
                GamePieces.firstNom = random.Next(1, GamePieces.playerCount + 1);
            }

            while (GamePieces.secondNom == GamePieces.currentHoh || GamePieces.secondNom == GamePieces.firstNom)
            {
                GamePieces.secondNom = random.Next(1, GamePieces.playerCount + 1);
            }
        }

        public void newHoh()
        {
            var random = new Random();
            int temp = GamePieces.currentHoh;

            while(temp == GamePieces.currentHoh)
            {
                temp = random.Next(1, GamePieces.playerCount + 1);
            }

            GamePieces.currentHoh = temp;
        }

        public void povCeremony()
        {
            //something wrong here
            var random = new Random();
            int temp = GamePieces.currentHoh;

            if (GamePieces.povPlayers[GamePieces.povWinner] == GamePieces.firstNom)
            {
                while (temp == GamePieces.currentHoh || temp == GamePieces.firstNom || temp == GamePieces.secondNom)
                {
                    temp = random.Next(1, GamePieces.playerCount + 1);
                }

                GamePieces.firstNom = temp;
            }
            else if(GamePieces.povPlayers[GamePieces.povWinner] == GamePieces.secondNom)
            {
                while (temp == GamePieces.currentHoh || temp == GamePieces.firstNom || temp == GamePieces.secondNom)
                {
                    temp = random.Next(1, GamePieces.playerCount + 1);
                }

                GamePieces.secondNom = temp;
            }
            else
            {
                //noms stay the same, can change this later
            }
        }

        public void povPlayers()
        {
            GamePieces.povPlayers.Clear();

            GamePieces.povPlayers.Add(GamePieces.currentHoh);
            GamePieces.povPlayers.Add(GamePieces.firstNom);
            GamePieces.povPlayers.Add(GamePieces.secondNom);

            var random = new Random();

            for (int i = 1; i <= 3; i++)
            {
                int temp = GamePieces.currentHoh;
                while (GamePieces.povPlayers.Contains(temp))
                {
                    temp = random.Next(1, GamePieces.playerCount + 1);
                }

                GamePieces.povPlayers.Add(temp);
            }
        }

        public void povWinner()
        {
            var random = new Random();
            var winner = random.Next(0, 6);

            GamePieces.povWinner = winner;
        }
    }
}
