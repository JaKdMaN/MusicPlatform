using server.Database;
using server.Interfaces;
using server.Models;

namespace server.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ServerDbContext _context;

        public CommentRepository(ServerDbContext context)
        {
            _context = context;
        }

        public bool CreateComment(Comment comment)
        {
            _context.Add(comment);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
