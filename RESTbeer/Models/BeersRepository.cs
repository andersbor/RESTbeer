namespace RESTbeer.Models
{
    public class BeersRepository
    {
        private int nextId = 1;
        private readonly List<Beer> beers;

        public BeersRepository()
        {
            beers = [
                new() { Id = nextId++, Brewery = "Tuborg", Name = "Grøn", Style = "Pilsner", Abv = 4.6, User = "anbo@zealand.dk", Volume = 33, HowMany = 1, PictureUrl = "https://frugt.dk/img/p/2/4/0/2/6/24026.jpg" },
                new() { Id = nextId++, Brewery = "Tuborg", Name = "Classic", Style = "Vienna lager", Abv = 4.6, User = "anbo@zealand.dk", Volume = 33, HowMany = 2 },
                new() { Id = nextId++, Brewery = "Lervig", Name = "Paragon (2019)", Style = "Barley Wine", Abv = 13.5, User = "anbo@zealand.dk", Volume = 37.5, HowMany = 1 },
                new() { Id = nextId++, Brewery = "Det Lille Bryggeri", Name = "Big Mash Up Barrel Aged Johnny Walker", Style = "Imperial Stout", Abv = 16.2, User = "anbo@zealand.dk", Volume = 50, HowMany = 1 },
                new() { Id = nextId++, Brewery = "Nerdbrewing", Name = "Indexoutofbounds", Style = "Imperial Stout", Abv = 11.6, User = "anbo@zealand.dk", Volume = 33, HowMany=4 },
                new() { Id = nextId++, Brewery = "Newbarns", Name = "404 Error", Style = "IPA", Abv = 6.5, Volume = 44, User = "somebody@home.com", HowMany = 1 },
                new() { Id = nextId++, Brewery = "Schwarze Rose", Name = "Paranoid Android", Style = "IPA", Abv = 6.7, Volume = 44, User = "somebody@home.com", HowMany=1, PictureUrl = "https://www.alehub.de/wp-content/uploads/2021/03/schwarze-rose-paranoid-android-online-kaufen.jpg" },
                new() { Id = nextId++, Brewery = "Velka Morava", Name = "Kotlin", Style = "Baltic Porter", Abv = 8.5, Volume = 50, User = "somebody@home.com", HowMany=1 },
                new() { Id = nextId++, Brewery = "Binary Brewing", Name = "HTTPale", Style = "American Pale Ale", Abv = 6, User = "somebody@home.com", Volume = 35.5, HowMany=1 },
                new() { Id = nextId++, Brewery = "Burnt City", Name = "Retrofit Radler", Style = "Radler", Abv = 3.7, User = "somebody@home.com", Volume = 44, HowMany=1 }
                ];
        }

        public IEnumerable<Beer> Get(string? user = null, string? orderBy = null)
        {
            IEnumerable<Beer> result =
                (user == null) ? new List<Beer>(beers) :
                beers.Where(beer => beer.User == user);
            if (orderBy != null)
            {
                switch (orderBy.ToLower())
                {
                    case "name":
                        result = result.OrderBy(beer => beer.Name);
                        break;
                    case "style":
                        result = result.OrderBy(beer => beer.Style);
                        break;
                    case "abv":
                        result = result.OrderBy(beer => beer.Abv);
                        break;
                    case "volume":
                        result = result.OrderBy(beer => beer.Volume);
                        break;
                    case "howmany":
                        result = result.OrderBy(beer => beer.HowMany);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public Beer Add(Beer beer)
        {
            beer.Id = nextId++;
            beers.Add(beer);
            return beer;
        }

        public Beer? Delete(int id)
        {
            Beer? beer = beers.FirstOrDefault(beer => beer.Id == id);
            if (beer != null)
                beers.Remove(beer);
            return beer;
        }

        public Beer? Update(int id, Beer beer)
        {
            Beer? beerToUpdate = beers.FirstOrDefault(beer => beer.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Brewery = beer.Brewery;
                beerToUpdate.Name = beer.Name;
                beerToUpdate.Style = beer.Style;
                beerToUpdate.Abv = beer.Abv;
                beerToUpdate.Volume = beer.Volume;
                beerToUpdate.HowMany = beer.HowMany;
                beerToUpdate.PictureUrl = beer.PictureUrl;
            }
            return beerToUpdate;
        }
    }
}
