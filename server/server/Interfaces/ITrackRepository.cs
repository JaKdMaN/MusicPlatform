using server.Dto;
using server.Models;

namespace server.Interfaces
{
    public interface ITrackRepository
    {
        ICollection<Track> GetTracks();

        Track GetTrack(int id);

        bool TrackExists(int trackId);

        bool CreateTrack(Track track);

        bool Save();
    }
}
