using server.Data;
using server.Models;

namespace server.Repositories
{
    public interface INoteRepository
    {
        public Task<List<NoteModel>> getAllNotesAsync();
        public Task<NoteModel> getNoteAsync(int id);
        public Task<int> postNoteAsync(NoteModel model);
        public Task updateNoteAsync(int id, NoteModel model);
        public Task deleteNoteAsync(int id);

    }
}
