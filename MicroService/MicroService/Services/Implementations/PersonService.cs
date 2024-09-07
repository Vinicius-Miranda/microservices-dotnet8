using Bogus;
using MicroService.Model;

namespace MicroService.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> people = [];
        public PersonService()
        {
           
        }

        public PersonModel Creation(PersonModel personModel)
        {
            personModel.Id = new Random().Next(1, 100);
            people.Add(personModel);

            return personModel;
        }

        public void Delete(long id)
        {
            PersonModel person = people.Find(x => x.Id == id);
            people.Remove(person);
        }

        public List<PersonModel> FindAll() 
        {
            if(people.Count == 0)
               CreatePeople();

            return people;
        }

        public PersonModel Update(PersonModel personModel)
        {
            var indexOf = people.IndexOf(people.Find(x => x.Id == personModel.Id));
            people[indexOf] = personModel;

            return personModel;
        }

        public PersonModel? FindByID(long id)   =>
            people.Find(x => x.Id == id);

        private static void CreatePeople()
        {
            for(int i = 0; i < 10; i++)
            {
                PersonModel personModel = FakePersonModel();
                people.Add(personModel);
            }
        }

        private static PersonModel FakePersonModel() =>
            new Faker<PersonModel>()
                .RuleFor(x => x.Id, f => f.Random.Number(1, 100))
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .RuleFor(x => x.Gender, f => f.Person.Gender.ToString());
    }
}