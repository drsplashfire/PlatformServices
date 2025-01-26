using PlatformServices.Models;

namespace PlatformServices.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges( );
        IEnumerable<Platform> GetAllPlatforms( );
        Platform GetPlatformById(int Id );
        void CreatePlatform( Platform platform );
        bool DeletePlatformById( int id );
    }
}
