using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Models
{
    public interface IGameMethods
    {
        public void newHoh();
        public void initialNoms();
        public void povPlayers();
        public void povCeremony();
        public void povWinner();
        public void evictionNight();
    }
}
