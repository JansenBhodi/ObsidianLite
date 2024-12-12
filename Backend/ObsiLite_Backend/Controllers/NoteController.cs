using Microsoft.AspNetCore.Mvc;
using ObsiLite_Backend.models;
using System.Text.Json;

namespace ObsiLite_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {

        //update later to use user credentials
        [HttpGet(Name = "GetNotes")]
        public List<Note> GetNotes()
        {
            return new List<Note> 
            { 
                new Note(1, 1, "First Note", "This is the first note I have made"),
                new Note(2, 1, "Second Note", "This is my second note I have made"),
                new Note(3, 2, "Different Owner", "This note is owned  by a different person")
            };


        }
        
        

        [HttpPost(Name = "UpdateNote")]
        //update this to accept json maybe?
        public bool EditNote(Note note)
        {
            return true;
        }
    }
}
