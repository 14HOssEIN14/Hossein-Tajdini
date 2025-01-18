using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AnimalManagmentSystem
{
    internal interface IMenuActions
    {
        public void WelcomePage();
        public void SeeAllAnimals();
        public void SearchInAnimals();
        public void EditAnimalPage(Dictionary<int, Animal> list);
        public void AddAnimalPage();
        public void DeleteAnimalPage(Dictionary<int, Animal> list);

    }
}
