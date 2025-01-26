using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformServices.Data;
using PlatformServices.Dtos;
using PlatformServices.Models;

namespace PlatformServices.Controllers
{
    [Route( "api/[Controller]" )]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository,IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllPlatforms" )]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms() 
        {
            Console.WriteLine("Getting all Platforms" );

            var platform = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platform));
        }

        [HttpGet ("{id}",Name = "GetPlatformById" )]
        public ActionResult<PlatformReadDto> GetPlatformById( int id)
        {
            Console.WriteLine($"Platform with {id} found" );
            var platform = _repository.GetPlatformById(id );
            if ( platform == null )
            {
                Console.WriteLine( "Platform not found" );
                return NoContent( );
            }
            return Ok( _mapper.Map<PlatformReadDto>( platform ) );
        }


        [HttpPost( Name = "CreatePlatform" )]
        public ActionResult<PlatformReadDto> CreatePlatform( PlatformCreateDto platform )
        {
            Console.WriteLine( "Creating platform" );
           
                var platformModel = _mapper.Map<Platform>( platform );
                _repository.CreatePlatform( platformModel );
                _repository.SaveChanges();
            var platformReadDto = _mapper.Map<PlatformReadDto>( platformModel );
            return CreatedAtRoute( nameof( GetPlatformById ), new { platformReadDto.Id }, platformReadDto );
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlatformById( int id )
        {
            bool deleteSuccessfull = _repository.DeletePlatformById( id );
            if ( deleteSuccessfull )
            {
                Console.WriteLine( $"{id} Found ,Deleting" );
                _repository.SaveChanges( );
                return Ok( new { message = $"{id}Deleted" } );

            }
            else
                return NotFound( new { message = $"{id} NotFound found"});
        }         
    }
}
