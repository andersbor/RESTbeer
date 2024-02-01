namespace RESTbeer.Models
{
    public class BeersRepository
    {
        private int nextId = 1;
        private readonly List<Beer> beers;

        public BeersRepository()
        {
            beers = [
                new() { Id=nextId++, Name="Tuborg Grøn", Style="Pilsner", Abv=4.6, User="anbo@zealand.dk", Volume=33, HowMany=1, PictureUrl="https://frugt.dk/img/p/2/4/0/2/6/24026.jpg" },
                new() { Id=nextId++, Name="Tuborg Classic", Style="Vienna lager", Abv=4.6, User="anbo@zealand.dk", Volume=33, HowMany=2},
                new() { Id=nextId++, Name="Lervig Paragon (2019)", Style="Barley Wine", Abv=13.5, User="anbo@zealand.dk", Volume=37.5, HowMany=1},
                new() { Id=nextId++, Name="Det Lille Bryggeri Big Mash Up - Barrel Aged Johnny Walker Gold Edition", Style="Imperial Stout", Abv=16.2, User="anbo@zealand.dk", Volume=50, HowMany=1},
                new() {Id=nextId++, Name="Nerdbrewing Indexoutofbounds Oak Aged Imperial Vanilla Stout", Style="Imperial Stout", Abv=11.6, User="anbo@zealand.dk", Volume=33},
                new() {Id=nextId++, Name="Newbarns 404 Error", Style="IPA", Abv=6.5, Volume=44, User="somebody@home.com"},
                new() {Id=nextId++, Name="Schwarze Rose Paranoid Android", Style="IPA", Abv=6.7, Volume=44, User="somebody@home.com", PictureUrl="https://www.alehub.de/wp-content/uploads/2021/03/schwarze-rose-paranoid-android-online-kaufen.jpg"},
                new() {Id=nextId++, Name="Velka Morava Velka Morava", Style="baltic porter", Abv=8.5, Volume=50, User="somebody@home.com"}
            ];
        }

        public IEnumerable<Beer> Get(string user)
        {
            if (user != null) // TODO null allowed?
                return beers.Where(beer => beer.User == user);
            return new List<Beer>(beers);
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
                beerToUpdate.Name = beer.Name;
                beerToUpdate.Style = beer.Style;
                beerToUpdate.Abv = beer.Abv;
                beerToUpdate.Volume = beer.Volume;
                beerToUpdate.HowMany = beer.HowMany;
            }
            return beerToUpdate;
        }
    }
}
