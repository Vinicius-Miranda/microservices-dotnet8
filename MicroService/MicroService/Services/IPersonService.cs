using MicroService.Model;

namespace MicroService.Services
{
    public interface IPersonService
    {
        PersonModel Creation(PersonModel personModel);
        PersonModel FindByID(long id);
        List<PersonModel> FindAll();
        PersonModel Update(PersonModel personModel);
        void Delete(long id);
    }
}
