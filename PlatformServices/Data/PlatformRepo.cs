using Microsoft.AspNetCore.Http.HttpResults;
using PlatformServices.Models;

namespace PlatformServices.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _appDbContext;

        public PlatformRepo(AppDbContext appDbContext )
        {
            _appDbContext=appDbContext;
        }
        public void CreatePlatform( Platform platform )
        {
            if ( platform == null )
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _appDbContext.platforms.Add( platform );
        }

        public bool DeletePlatformById( int id )
        {
            var platform = GetPlatformById( id );
            if ( platform != null )
            {
                _appDbContext.platforms.Remove( platform );
                return true;
            }
            return false;
        }

        public IEnumerable<Platform> GetAllPlatforms( )
        {
            return (_appDbContext.platforms.ToList());
        }

        public Platform GetPlatformById( int id )
        {
            return _appDbContext.platforms.FirstOrDefault( p => p.Id == id );
        }

        public bool SaveChanges( )
        {
            return (_appDbContext.SaveChanges( )>=0);
        }
    }
}
