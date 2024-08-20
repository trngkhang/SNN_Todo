using AutoMapper;
using server.Data;
using server.Models;

namespace server.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() { 
            CreateMap<Note, NoteModel>().ReverseMap();
        }
    }
}
