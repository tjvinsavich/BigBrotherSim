using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Models
{
    public static class GamePieces
    {
        //might change so starting amount of players is open-ended
        public static int playerCount { get; set; } = 16;
        public static Player selectedPlayer { get; set; } = new Player();
        public static int currentHoh { get; set; }
        public static int firstNom { get; set; }
        public static int secondNom { get; set; }
        //first 3 of 6 are hoh, firstNom, secondNom defaulted
        public static List<int> povPlayers { get; set; } = new List<int>();

        public static int povWinner { get; set; }
    }
}
