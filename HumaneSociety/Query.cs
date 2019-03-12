using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {

        internal static List<USState> GetStates()
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            List<USState> allStates = db.USStates.ToList();       

            return allStates;
        }

        internal static Client GetClient(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.AddressLine2 = null;
                newAddress.Zipcode = zipCode;
                newAddress.USStateId = stateId;

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            return null;
        }

        internal static void UpdateClient(Client clientWithUpdates)
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            // find corresponding Client from Db
            Client clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();

            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if(updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.AddressLine2 = null;
                newAddress.Zipcode = clientAddress.Zipcode;
                newAddress.USStateId = clientAddress.USStateId;

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;
            
            // submit changes
            db.SubmitChanges();
        }

        internal static Animal GetAnimalByID(int iD)
        {
            throw new NotImplementedException();
        }

        internal static void Adopt(object animal, Client client)
        {
            throw new NotImplementedException();
        }

        internal static void RunEmployeeQueries(Employee employee, string v)
        {
            throw new NotImplementedException();
        }

        internal static Room GetRoom(int animalId)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateAdoption(bool v, Adoption adoption)
        {
            throw new NotImplementedException();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if(employeeFromDb == null)
            {
                throw new NullReferenceException();            
            }
            else
            {
                return employeeFromDb;
            }            
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName == null;
        }

        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            HumaneSocietyDataContext  db = new HumaneSocietyDataContext();

            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }

        internal static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static int? GetCategoryId()
        {
            //search if categoryid exists 

            //if it doesn't, make a new one


            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            string getCat = UserInterface.GetStringData("the animal", "species");

            

            // look for existing category in Db (null will be returned if the category isn't already in the Db
            Category updatedCategory = db.Categories.Where(a => a.Name == getCat).FirstOrDefault();

            // if category isn't found in the Db, create and insert it
            if (updatedCategory == null)
            {
                Category newCategory = new Category();
                newCategory.Name = getCat;
                

                db.Categories.InsertOnSubmit(newCategory);
                db.SubmitChanges();

                updatedCategory = newCategory;
            }

            // attach category to clientFromDb.AddressId
            updatedCategory.Name = getCat;

            // submit changes
            db.SubmitChanges();
            return null;
        }

        internal static int? GetDietPlanId()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            string getDiet = UserInterface.GetStringData("diet", "the animal's");
            string getFoodType = UserInterface.GetStringData("food type", "the animal's");
            string getAmountString = UserInterface.GetStringData("amount", "food");
            int getAmount = int.Parse(getAmountString);


            // look for existing category in Db (null will be returned if the category isn't already in the Db
            DietPlan updatedDiet = db.DietPlans.Where(a => a.Name == getDiet).FirstOrDefault();

            // if category isn't found in the Db, create and insert it
            if (updatedDiet == null)
            {
                DietPlan newDiet = new DietPlan();
                newDiet.Name = getDiet;
                newDiet.FoodType = getFoodType;
                newDiet.FoodAmountInCups = getAmount;

                db.DietPlans.InsertOnSubmit(newDiet);
                db.SubmitChanges();

                updatedDiet = newDiet;
                return null;
            }

            // attach category to clientFromDb.AddressId
            updatedDiet.Name = getDiet;
            updatedDiet.FoodType = getFoodType;
            updatedDiet.FoodAmountInCups = getAmount;

            // submit changes
            db.SubmitChanges();
            return null;
        }

        internal static void AddAnimal(Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();
        }

        internal static void EnterAnimalUpdate(Animal animal, Dictionary<int, string> updates)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

           
            Animal animalFromDb = db.Animals.Where(a => a.AnimalId == animal.AnimalId).Single();

            if (updates.ContainsKey(1))
            {
                //animal.Category = updates[1];
            }
            if (updates.ContainsKey(2))
            {
                animal.Name = updates[2];
            }
            if (updates.ContainsKey(3))
            {
                animal.Age = int.Parse(updates[3]);
            }
            if (updates.ContainsKey(4))
            {
                animal.Demeanor = updates[4];
            }
            if (updates.ContainsKey(5))
            {
                animal.KidFriendly = bool.Parse(updates[5]);
            }
            if (updates.ContainsKey(6))
            {
                animal.PetFriendly = bool.Parse(updates[6]);
            }
            if (updates.ContainsKey(7))
            {
                animal.Weight = int.Parse(updates[7]);
            }
            
            
        }

        



        internal static void RemoveAnimal(object animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            db.Log = Console.Out;

            Console.WriteLine("Which Animal ID would you like to delete?");
            Console.ReadLine();
            int deleteAnimal = int.Parse(Console.ReadLine());


            var ordDetailQuery =
                from odq in db.Animals
                where odq.AnimalId == deleteAnimal
                select odq;

            foreach (var entry in ordDetailQuery)
            {
                
                db.Animals.DeleteOnSubmit(entry);
            }

           
            Console.WriteLine("Deleted.");
            
        }

        internal static IQueryable<Animal> SearchForAnimalByMultipleTraits()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            var animalSearch = UserInterface.GetAnimalCriteria();

            
            
            

            List<Animal> foundAnimals;

            if (animalSearch.ContainsKey(1))
            {
                foundAnimals = db.Categories.Where(a => a.Name == animalSearch[1]).FirstOrDefault()).ToList();
            }
            if (animalSearch.ContainsKey(2))
            {
                foundAnimals = db.Animals.Where(a => a.Name == animalSearch.Values.FirstOrDefault()).ToList();
            }
            if (animalSearch.ContainsKey(3))
            {
                foundAnimals = db.Animals.Where(a => a.Age == int.Parse(animalSearch.Values.FirstOrDefault())).ToList();

            }
            if (animalSearch.ContainsKey(4))
            {
                foundAnimals = db.Animals.Where(a => a.Demeanor == animalSearch.Values.FirstOrDefault()).ToList();
            }
            if (animalSearch.ContainsKey(5))
            {
                foundAnimals = db.Animals.Where(a => a.KidFriendly == bool.Parse(animalSearch.Values.FirstOrDefault())).ToList();
            }
            if (animalSearch.ContainsKey(6))
            {
                foundAnimals = db.Animals.Where(a => a.PetFriendly == bool.Parse(animalSearch.Values.FirstOrDefault())).ToList();
            }
            if (animalSearch.ContainsKey(7))
            {
                foundAnimals = db.Animals.Where(a => a.Weight == int.Parse(animalSearch.Values.FirstOrDefault())).ToList();
            }






            foundAnimals = db.Animals.Where(
                m =>
                
                (m.Category == animal.category) &&
                (m.KidFriendly == animal.KidFriendly)
                ).OrderBy(m => m.AnimalID).ToList();

            UserInterface.DisplayAnimals(foundAnimals);
            return foundAnimals;


            //select animal from db where searchSpecies = db.category OR searchAge = db.age OR searchDemeanor = db. demeanor OR searchKid = db.kidfriendly 

        }
    }
}