using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDbConnection conn;
        public PlayerRepository(IDbConnection conn)
        {
            this.conn = conn;
        }

        public void DeletePlayer(Player player)
        {
            conn.Execute("DELETE FROM players WHERE id = @id;",
                                      new { id = player.id });
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return conn.Query<Player>("SELECT * FROM players;");
        }

        public Player GetPlayer(int id)
        {
            return conn.QuerySingle<Player>("SELECT * FROM players WHERE id = @id",
                new { id = id });
        }

        public void InsertPlayer(Player player)
        {
            conn.Execute("INSERT INTO players (firstName, lastName) VALUES (@firstName, @lastName);",
                new { firstName = player.firstName, lastName = player.lastName});


        }

        public void UpdatePlayer(Player player)
        {
            conn.Execute("UPDATE players SET firstName = @firstName, lastName = @lastName WHERE id = @id;",
                new { firstName = player.firstName, lastName = player.lastName, id = player.id });
        }
    }
}
