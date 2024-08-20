using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly DbSnrTodoContext _context;
        private readonly IMapper _mapper;

        public NoteRepository(DbSnrTodoContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task deleteNoteAsync(int id)
        {
            var deleteNote = _context.Notes!.SingleOrDefault(n=>n.Id==id);
            if(deleteNote != null)
            {
                _context.Notes.Remove(deleteNote);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NoteModel>> getAllNotesAsync()
        {
            var notes = await _context.Notes!.ToListAsync();
            return _mapper.Map<List<NoteModel>>(notes);
        }

        public async Task<NoteModel> getNoteAsync(int id)
        {
            var note = await _context.Notes!.FindAsync(id);
            return _mapper.Map<NoteModel>(note);
        }

        public async Task<int> postNoteAsync(NoteModel model)
        {
            var newNote = _mapper.Map<Note>(model);
            _context.Notes!.Add(newNote);
            await _context.SaveChangesAsync();
            return newNote.Id;
        }

        public async Task updateNoteAsync(int id, NoteModel model)
        {
            if (id == model.Id)
            {
                var updateNote = _mapper.Map<Note>(model);
                _context.Notes!.Update(updateNote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
