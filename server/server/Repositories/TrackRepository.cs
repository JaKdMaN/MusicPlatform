using server.Database;
using server.Interfaces;
using server.Models;

namespace server.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ServerDbContext _context;

        public TrackRepository(ServerDbContext context)
        {
            _context = context;
        }

        public bool CreateTrack(Track track)
        {
            _context.Add(track);

            return Save();
        }

        public Track GetTrack(int id)
        {
            return _context.Track.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Track> GetTracks() 
        {
            return _context.Track.OrderBy(p => p.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool TrackExists(int trackId)
        {
            return _context.Track.Any(p => p.Id == trackId);
        }

    }
}
