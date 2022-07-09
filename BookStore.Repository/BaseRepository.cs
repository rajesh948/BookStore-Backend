using BookStore.Models.ViewModels;

namespace BookStore.Repository
{
    public class BaseRepository
    {
        protected bookstoreContext _context = new bookstoreContext();
    }
}
