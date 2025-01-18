using AnimalManagmentSystem.DataManagment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnimalManagmentSystem;

public class MenuHandler : IMenuActions
{
    public void WelcomePage()
    {
        Console.Clear();
        Console.WriteLine("*********************Animal Management System*********************");
        Console.WriteLine("Please select the command you want");
        Console.WriteLine("[0] Get a list of all animals ");
        Console.WriteLine("[1] Search in animal list by name ");
        Console.WriteLine("[2] Add new animal ");
        Console.WriteLine("[3] Exit ");
        switch (command(true, 3))
        {
            case "0":
                SeeAllAnimals();
                break;
            case "1":
                SearchInAnimals();
                break;
            case "2":
                AddAnimalPage();
                break;
            case "3":
                Environment.Exit(0);
                break;
        }

    }

    public void SeeAllAnimals()
    {
        Console.Clear();
        var animals = DBManager.GetAllAnimals();
        foreach (var anim in animals)
        {
            int i = 0;
            Console.WriteLine($"[{anim.Key}] AnimalName:{anim.Value.name} AimalSpecies:{anim.Value.animalSpecie} AnimalAge:{anim.Value.age} Stock:{anim.Value.stock} ");
            foreach (var item in anim.Value.specialAttributes)
            {
                Console.WriteLine($"        SpicialAttribute[{i}] {item.Key}:{item.Value}");
                Console.WriteLine();
                Console.WriteLine();
                i++;
            }
        }
        Console.WriteLine("**********************************************************");
        Console.WriteLine("[0]Back To Main Menu");
        Console.WriteLine("[1]Edit an animal");
        Console.WriteLine("[2]Add new animal");
        Console.WriteLine("[3]Delete an animal");
        Console.WriteLine("[4]Exit");
        switch (command(true, 4))
        {
            case "0":
                WelcomePage();
                break;
            case "1":
                EditAnimalPage(animals);
                break;
            case "2":
                AddAnimalPage();
                break;
            case "3":
                DeleteAnimalPage(animals);
                break;
            case "4":
                Environment.Exit(0);
                break;
        }
    }

    public void SearchInAnimals()
    {
        Console.Clear();
        var animalList = DBManager.GetAllAnimals();

        string searchString = "";
        Console.WriteLine("Type to search(press Enter to accept) :");
        Dictionary<int, Animal> lastResult = new Dictionary<int, Animal>();
        while (true)
        {

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Enter)
            {
                if (lastResult.Count == 0)
                {
                    Console.Clear();
                    lastResult = animalList;
                    int x = 0;
                    foreach (var anim in lastResult)
                    {
                        int i = 0;
                        Console.WriteLine($"[{anim.Key}] AnimalName:{anim.Value.name} AimalSpecies:{anim.Value.animalSpecie} AnimalAge:{anim.Value.age} Stock:{anim.Value.stock} ");
                        foreach (var item in anim.Value.specialAttributes)
                        {
                            Console.WriteLine($"        SpicialAttribute[{i}] {item.Key}:{item.Value}");
                            Console.WriteLine();
                            Console.WriteLine();
                            i++;
                        }
                    }
                }
                break;
            }


            if (key.Key == ConsoleKey.Backspace)
            {
                if (searchString.Length > 0)
                {
                    searchString = searchString.Substring(0, searchString.Length - 1);
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                searchString += key.KeyChar;
            }

            Console.Clear();
            Console.WriteLine("Type to search (press Backspace to delete, and Enter to exit):");
            Console.WriteLine($"Search: {searchString}");


            var results = animalList.Where(k => k.Value.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);


            if (results.Any())
            {
                Console.WriteLine($"\n{results.Count()}Result Found :");

                lastResult.Clear();
                foreach (var anim in results)
                {
                    lastResult[anim.Key] = anim.Value;
                    int i = 0;
                    Console.WriteLine($"[{anim.Key}] AnimalName:{anim.Value.name} AimalSpecies:{anim.Value.animalSpecie} AnimalAge:{anim.Value.age} Stock:{anim.Value.stock} ");
                    foreach (var item in anim.Value.specialAttributes)
                    {
                        Console.WriteLine($"        SpicialAttribute[{i}] {item.Key}:{item.Value}");
                        Console.WriteLine();
                        Console.WriteLine();
                        i++;
                    }
                }

            }
            else
            {
                lastResult.Clear();
                Console.WriteLine("No match found!");
            }
           

        }
        Console.WriteLine("**********************************************************");
        Console.WriteLine("[0]Back To Main Menu");
        Console.WriteLine("[1]Edit an animal");
        Console.WriteLine("[2]Add new animal");
        Console.WriteLine("[3]Delete an animal");
        Console.WriteLine("[4]Exit");
        switch (command(true, 4))
        {
            case "0":
                WelcomePage();
                break;
            case "1":
                EditAnimalPage(lastResult);
                break;
            case "2":
                AddAnimalPage();
                break;
            case "3":
                DeleteAnimalPage(lastResult);
                break;
            case "4":
                Environment.Exit(0);
                break;
        }

    }

    public void EditAnimalPage(Dictionary<int, Animal> list)
    {
        Console.Clear();
        foreach (var anim in list)
        {
            int x = 0;
            Console.WriteLine($"[{anim.Key}] AnimalName:{anim.Value.name} AimalSpecies:{anim.Value.animalSpecie} AnimalAge:{anim.Value.age} Stock:{anim.Value.stock} ");
            foreach (var item in anim.Value.specialAttributes)
            {
                Console.WriteLine($"        SpicialAttribute[{x}] {item.Key}:{item.Value}");
                Console.WriteLine();
                Console.WriteLine();
                x++;
            }
        }
        Console.WriteLine("**********************************************************");
        Console.WriteLine("Please enter id of animal you want to edit");
        int Id = 0;
        while (true)
        {
            Id = Convert.ToInt32(command(false));
            if (list.Keys.Contains(Convert.ToInt32(Id)))
                break;
            else
                Console.WriteLine("WrongId");
        }
        Console.WriteLine($"AnimalName is:{list[Id].name} Change it to(Empty=NoChange):");
        string name = Console.ReadLine();
        if (name == "") name = list[Id].name;
        Console.WriteLine($"AnimalSpecies is:{list[Id].animalSpecie} Change it to(Empty=NoChange):");
        string animalSpecies = Console.ReadLine();
        if (animalSpecies == "") animalSpecies = list[Id].animalSpecie;
        Console.WriteLine($"AnimalAge is:{list[Id].age} Change it to(Empty=NoChange):");
        string age =getNumberCommand();
        if (age == "") age = list[Id].age.ToString();
        Console.WriteLine($"Stock is:{list[Id].stock} Change it to(Empty=NoChange):");
        string stock = getNumberCommand();
        if (stock == "") stock = list[Id].stock.ToString();

        Dictionary<string, string> SpicialAttribute = new Dictionary<string, string>();
        int i = 0;
        foreach (var item in list[Id].specialAttributes)
        {
            Console.WriteLine($"AnimalSpicialAttribute[{i}] is:{item.Key}:{item.Value} Change it to(Empty=NoChange)");
            Console.Write("Attribute Name:");
            string a = Console.ReadLine();
            Console.Write("Attribute :");
            string b = Console.ReadLine();
            if (a == "")
                a = item.Key;
            if (b == "")
                b = item.Value;
            SpicialAttribute.Add(a, b);
            i++;
        }
        Console.WriteLine("Do you want to add more attribute?(y,n)");
        if (yesno() == "y")
        {
            while (true)
            {
                Console.WriteLine("Enter AttributeName:");
                string a = Console.ReadLine();
                Console.WriteLine("Enter Attribute:");
                string b = Console.ReadLine();
                SpicialAttribute.Add(a, b);
                Console.WriteLine("Just this?(y,n)");
                if (yesno() == "y") break;
            }
        }


        Animal animal = new Animal
        {
            name = name,
            age = Convert.ToInt32(age),
            animalSpecie = animalSpecies,
            specialAttributes = SpicialAttribute,
            stock = Convert.ToInt32(stock)
        };
        DBManager.EditAnimal(animal,Id);
        Console.WriteLine("Animal Edited!");
        Console.WriteLine("***********************************************************");
        Console.WriteLine("[0]Back To Main Menu");
        Console.WriteLine("[1]Exit");
        switch (command(true, 1))
        {
            case "0":
                WelcomePage();
                break;
            case "1":
                Environment.Exit(0);
                break;
        }

    }

    public void AddAnimalPage()
    {
        Console.Clear();
        string Name = "";
        while (true)
        {
            Console.WriteLine("Enter your new animal name:");
            Name = Console.ReadLine();
            if (Name == "")
                Console.WriteLine("Name cannot be empty ");
            else
                break;
        }
        Console.WriteLine("Enter animalSpecie:");
        string AnimalSpecies = Console.ReadLine();

        Console.WriteLine("Enter animalAge:");
        string Age = getNumberCommand();

        Dictionary<string, string> animalAttributes = new Dictionary<string, string>();
        Console.WriteLine("Does your animal have a spicialAttribute?(y,n)");
        if (yesno() == "y")
        {
            while (true)
            {
                Console.WriteLine("Enter AttributeName:");
                string a = Console.ReadLine();
                Console.WriteLine("Enter Attribute:");
                string b = Console.ReadLine();
                animalAttributes.Add(a, b);
                Console.WriteLine("Just this?(y,n)");
                if (yesno() == "y") break;
            }
        }

        Animal animal = new Animal
        {
            name = Name,
            animalSpecie = AnimalSpecies,
            age = Convert.ToInt32(Age),
            stock = 1,
            specialAttributes = animalAttributes
        };

        DBManager.AddAnimal(animal);

        Console.WriteLine("Animal Added!");
        Console.WriteLine("***********************************************************");
        Console.WriteLine("[0]Back To Main Menu");
        Console.WriteLine("[1]Exit");
        switch (command(true, 1))
        {
            case "0":
                WelcomePage();
                break;
            case "1":
                Environment.Exit(0);
                break;
        }

    }
    public void DeleteAnimalPage(Dictionary<int, Animal> list)
    {
        Console.Clear();
        foreach (var anim in list)
        {
            int x = 0;
            Console.WriteLine($"[{anim.Key}] AnimalName:{anim.Value.name} AimalSpecies:{anim.Value.animalSpecie} AnimalAge:{anim.Value.age} Stock:{anim.Value.stock} ");
            foreach (var item in anim.Value.specialAttributes)
            {
                Console.WriteLine($"        SpicialAttribute[{x}] {item.Key}:{item.Value}");
                Console.WriteLine();
                Console.WriteLine();
                x++;
            }
        }
        Console.WriteLine("**********************************************************");
        Console.WriteLine("Please enter id of animal you want to delete");
        int Id = 0;
        while (true)
        {
            Id = Convert.ToInt32(command(false));
            if (list.Keys.Contains(Convert.ToInt32(Id)))
                break;
            else
                Console.WriteLine("WrongId");
        }
        DBManager.DeleteAnimal(Id);

        Console.WriteLine("Animal Deleted!");
        Console.WriteLine("***********************************************************");
        Console.WriteLine("[0]Back To Main Menu");
        Console.WriteLine("[1]Exit");
        switch (command(true, 1))
        {
            case "0":
                WelcomePage();
                break;
            case "1":
                Environment.Exit(0);
                break;

        }
    }
    public string command(bool iskey, int i = 0)
    {
        if (iskey)
            while (true)
            {
                string s = Console.ReadKey(true).KeyChar.ToString();

                if (Regex.IsMatch(s, $"^[0-9]+$") && int.TryParse(s, out int num) && num <= i)
                {
                    return s;
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                }
            }
        else
            while (true)
            {
                string s = Console.ReadLine();

                if (Regex.IsMatch(s, $"^[0-9]+$"))
                {
                    return s;
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                }
            }

    }
    public string yesno()
    {
        while (true)
        {
            char i = Console.ReadKey(true).KeyChar;
            if (i == 'y')
            {
                Console.WriteLine("y");
                return "y";
            }
            else if (i == 'n')
            {
                Console.WriteLine("n");
                return "n";
            }
            else
                Console.WriteLine("WrongInput");

        }
    }

    public string getNumberCommand()
    {
        while (true)
        {
            string x = Console.ReadLine();
            if (Regex.IsMatch(x, @"^(\d*)?$"))
            {
                return x;
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }


        }
    }
}
