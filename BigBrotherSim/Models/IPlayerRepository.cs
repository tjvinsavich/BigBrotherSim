using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Models
{
    public interface IPlayerRepository
    {
        public IEnumerable<Player> GetAllPlayers();
        public Player GetPlayer(int id);
        public void UpdatePlayer(Player player);
        public void InsertPlayer(Player player);
        public void DeletePlayer(Player player);
    }
}
