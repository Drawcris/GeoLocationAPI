using GeoLocationAPI.Entities;
namespace GeoLocationAPI.Data
{
    public class DbInitializer
    {
        public static void Init(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Locations.Any())
            {
                return;
            }

            var countries = new Location[]
            {
                new Location { Adress = "Uniwersytet Bielko-Bialski" },
                
            };

            foreach (Location c in countries)
            {
                context.Locations.Add(c);
            }

            context.SaveChanges();
        }
    }
}
