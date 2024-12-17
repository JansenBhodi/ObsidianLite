using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ObsiLite_Backend.models;
using System.Configuration;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

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


        public List<Note>? GetNotesByOwnerId(int id)
        {
            _conn.Open();

            SqlCommand command = _conn.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.note " +
                                  "WHERE OwnerId = @ownerId";
            command.Parameters.AddWithValue("@ownerId", id);

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

        public Note? GetNoteById(int id)
        {
            _conn.Open();

            SqlCommand command = _conn.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.note " +
                                  "WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            Note result = null;

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Note(
                            reader.GetInt32("Id"),
                            reader.GetInt32("OwnerId"),
                            reader.GetString("Title"),
                            reader.GetString("Body"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conn.Close();
            }

            return result;
        }

        public int CreateNote(Note note)
        {
            List<Note> existingMembers = GetNotesByOwnerId(note.OwnerId);
            int output = 0;
            try
            {
                _conn.Open();
            }
            catch (Exception)
            {

                throw;
            }


            SqlCommand command = _conn.CreateCommand();
            command.CommandText = "INSERT INTO dbo.note (OwnerId, Title, Body) VALUES (@ownerId, @title, @body)";
            command.Parameters.AddWithValue("@ownerId", note.OwnerId);
            command.Parameters.AddWithValue("@title", note.Title);
            command.Parameters.AddWithValue("@body", note.Body);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                _conn.Close();
                return 0;
            }
            finally
            {
                _conn.Close();
            }

            List<Note> NewMemberAdded = GetNotesByOwnerId(note.OwnerId);
            foreach(Note member in NewMemberAdded)
            {
                int validator = 0;
                foreach(Note check in existingMembers)
                {
                    if(member.Id == check.Id)
                    {
                        validator++;
                    }
                }
                if(validator == 0)
                {
                    output = member.Id;
                }
            }

            return output;
        }
    }
}
