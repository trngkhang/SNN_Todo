using server.Data;

namespace server.Repositories
{
    public interface INoteRopositorycs
    {
        public Task<List<Note>> getAllNotesAsync();
        public Task<Note> getNoteAsync(int id);
        public Task postNoteAsync(Note model);
        public Task updateNoteAsync(int id, Note model);
        public Task deleteNoteAsync(int id);

    }
}
