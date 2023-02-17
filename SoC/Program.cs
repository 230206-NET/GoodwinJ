using Pets;
using Owners;

//Separation of Concerns:
//Basic Concept: Software should be separated based on the kinds of work it performs
//Each little piece of the system should be able to complete a distinct job

Console.WriteLine("Your Name: ");
Owner user = new Owner();
string nameInput = Console.ReadLine();
user.Name = nameInput;
//Console.WriteLine("Owner: {0}", user.Name);

Console.WriteLine("Pet Name: ");
Pet animal = new Pet();
string petName = Console.ReadLine();
animal.Name = petName;
//Console.WriteLine("Pet Name: {0}", animal.Name);

Console.WriteLine("Pet Species: ");
string speciesInput = Console.ReadLine();
animal.Species = speciesInput;
//Console.WriteLine("Species: {0}", animal.Species);

Console.WriteLine(user.Name + " has a pet " + animal.Species + " named " + animal.Name);