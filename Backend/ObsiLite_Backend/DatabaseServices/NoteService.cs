using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ObsiLite_Backend.models;
using System.Configuration;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;

namespace ObsiLite_Backend.DatabaseServices
{
    public class NoteService
    {
        private readonly SqlConnection _conn;

        public NoteService(ObsiliteDbContext dbContext)
        {
            _conn = new SqlConnection(dbContext.Database.GetDbConnection().ConnectionString);
        }


        public List<Note>? GetNotes()
        {
            _conn.Open();

            SqlCommand command = _conn.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.note";

            List<Note> result = new List<Note>();

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Note input = new Note(
                            reader.GetInt32("Id"),
                            reader.GetInt32("OwnerId"),
                            reader.GetString("Title"),
                            reader.GetString("Body"));
                        result.Add(input);
                    }
                }
            }
            catch (Exception)
            {
                result = null;
            }
            finally
            {
                _conn.Close();
            }

            return result;
        }

        public bool CreateNote(Note note)
        {
            try
            {
                _conn.Open();
            }
            catch (Exception)
            {

                throw;
            }

            SqlCommand command = _conn.CreateCommand();
            command.CommandText = "INSERT INTO dbo.note VALUES ()";


            return true;
        }
    }
}
