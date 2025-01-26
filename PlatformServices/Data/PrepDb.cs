using PlatformServices.Models;

namespace PlatformServices.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation( IApplicationBuilder app )
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope( ) )
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext> ());
            }
        }
        public static void SeedData( AppDbContext context )
        {
            if ( !context.platforms.Any( ) )
            {
                Console.WriteLine("Seeding data" );
                context.platforms.AddRange(
                    new Platform { Name = "dotnet", Cost = "free", Publisher = "microsoft" },
                    new Platform { Name="Docker", Publisher = "dockerguys", Cost ="free"},
                    new Platform { Name = "software", Cost="Money", Publisher ="Meany"}
                    );
                context.SaveChanges( );

            }
            else
            {
                Console.WriteLine( "We have data" );
            }
        }
    }
}
