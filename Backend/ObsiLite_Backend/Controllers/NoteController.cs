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
        [HttpGet("GetNotes")]
        public List<Note> GetNotes()
        {
            List<Note> result = new List<Note>();

            result = DbNote.GetNotes();

            if (result.Count > 0)
            {
                return result;
            }
            else if (result == null)
            {
                throw new Exception();
            }
            else
            {
                throw new Exception();
            }

        }

        [HttpGet("GetNotesByOwnerId")]
        public List<Note> GetNotesByOwnerId(int id)
        {
            List<Note> result = new List<Note>();

            result = DbNote.GetNotesByOwnerId(id);

            if(result.Count > 0)
            {
                return result;
            }
            else if (result == null)
            {
                throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet("GetNoteById")]
        public Note GetNoteById(int id)
        {
            if(id == 0 || id == null)
            {
                throw new Exception();
            }
            else
            {
                return DbNote.GetNoteById(id);
            }
        }

        [HttpPost("CreateNote")]
        public IActionResult CreateNote([FromBody] Note input)
        {
            int validator = 0;
            Note note = new Note
                (   input.OwnerId,
                    input.Title,
                    input.Body
                );
            try
            {
                validator = DbNote.CreateNote(note);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CreatedAtAction(nameof(GetNoteById), new {id = validator }, note);
        }

        [HttpPost("UpdateNote")]
        //update this to accept json maybe?
        public bool EditNote(Note note)
        {
            return true;
        }
    }
}
