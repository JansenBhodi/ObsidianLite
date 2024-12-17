using Microsoft.AspNetCore.Mvc;
using ObsiLite_Backend.models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using ObsiLite_Backend.DatabaseServices;
using Microsoft.EntityFrameworkCore;

namespace ObsiLite_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private NoteService DbNote;

        public NoteController(ObsiliteDbContext dbContext)
        {
            DbNote = new NoteService(dbContext);
        }



        //update later to use user credentials
        [HttpGet(Name = "GetNotes")]
        public List<Note> GetNotes()
        {
            List<Note> result = new List<Note>();

            result = DbNote.GetNotes();

            if(result.Count > 0)
            {
                return result;
            }
            else if(result == null)
            {
                throw new Exception();
            }
            else
            {
                throw new Exception();
            }

        }

        [HttpPost(Name = "CreateNote")]
        public bool CreateNote(Note note)
        {
            try
            {

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [HttpPost(Name = "UpdateNote")]
        //update this to accept json maybe?
        public bool EditNote(Note note)
        {
            return true;
        }
    }
}
