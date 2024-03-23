using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTbeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTbeer.Models.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {
        private readonly BeersRepository repo = new BeersRepository();
        private readonly Beer grøn = new Beer
        {
            Id = 1,
            Brewery = "Tuborg",
            Name = "Grøn",
            Style = "Pilsner",
            Abv = 4.6,
            User = ""
        };
        private readonly Beer classic = new Beer
        {
            Id = 2,
            Brewery = "Tuborg",
            Name = "Classic",
            Style = "Vienna lager",
            Abv = 4.6,
            User = ""
        };
        private readonly Beer grønØko = new Beer()
        {
            Id = 3,
            Brewery = "Tuborg",
            Name = "Grøn Øko",
            Style = "Pilsner",
            Abv = 4.6,
            User = ""
        };

        [TestMethod()]
        public void UpdateTest()
        {
            repo.Add(grøn);
            repo.Add(classic);
            Beer? updated = repo.Update(1, grønØko);
            Assert.IsNotNull(updated);
            Assert.AreEqual("Grøn Øko", updated.Name);
            
        }
    }
}