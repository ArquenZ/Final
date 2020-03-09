using SundayStarcraft.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.DAL
{
    public class PlayerDao : IPlayerDao
    {
        private string _connectionString = ConString.Value;
        public int Add(Player player)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertPlayer";
                SqlParameter outputParameter = new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                SqlParameter[] parameters =
                    {
                    new SqlParameter() {ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = player.Name},
                    new SqlParameter() {ParameterName = "@Race", SqlDbType = SqlDbType.Int, Value = (int)player.Race},
                    new SqlParameter() {ParameterName = "@Nickname", SqlDbType = SqlDbType.NVarChar, Value = player.Nickname}
                    };
                command.Parameters.AddRange(parameters);
                command.Parameters.Add(outputParameter);
                connection.Open();
                command.ExecuteNonQuery();
                player.PlayerID = (int)outputParameter.Value;
                return player.PlayerID;
            }
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeletePlayerById";
                SqlParameter Parameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                };
                command.Parameters.Add(Parameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Player> GetAll()
        {
            List<Player> players = new List<Player>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.SelectAllPlayer";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    players.Add(new Player
                    {
                        PlayerID = (int)reader["ID"],
                        Nickname = reader["Nickname"] as string,
                        Name = reader["Name"] as string,
                        Race = (Races)reader["Race"]
                    });
                }
            }
            return players;
        }

        //public IEnumerable<Player> GetAllByRace(Player.Races race)
        //{
        //    List<Player> players = new List<Player>();
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        var command = connection.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "dbo.SelectAllPlayer";
        //        connection.Open();
        //        var reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            players.Add(new Player
        //            {
        //                PlayerID = (int)reader["ID"],
        //                Nickname = reader["Nickname"] as string,
        //                Name = reader["Name"] as string,
        //                Race = (Player.Races)reader["Race"]
        //            });
        //        }
        //    }
        //    return players;
        //}

        public Player GetByID(int id)
        {
            Player player = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetPlayerById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@ID", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    player = new Player()
                    {
                        PlayerID = id,
                        Nickname = reader["Nickname"] as string,
                        Name = reader["Name"] as string,
                        Race = (Races)reader["Race"] 
                    };
                }
            }
            return player;
        }
    }
}
