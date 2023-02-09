using FinalApi.DTO;
using FinalApi.Models;

namespace FinalApi.IServices.IPerson
{
    public interface IPersonService
    {
        public Task<string> createPerson(int bussinessID, string personType, bool nameType, string title, string firstName, string middleName, string lastName, string suffix, int mailPromotion, Guid rowguid);
        //public Task<List<Person>> GetEmailPromotionData(int emailPromotionID);
        //public Task<object> UpdatePerson(PersonDTO personDTO);
        public Task<object> UpdatePerson(PersonDTO personDto);
    }
}
