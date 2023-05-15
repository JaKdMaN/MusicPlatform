using server.Models;

namespace server.Interfaces
{
    public interface ICommentRepository
    {
        bool CreateComment(Comment comment);

        bool Save();
    }
}
