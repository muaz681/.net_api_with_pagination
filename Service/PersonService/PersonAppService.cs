using FinalApi.Data;
using FinalApi.DTO;
using FinalApi.Helper;
using FinalApi.IServices.IPerson;
using FinalApi.Models;
using Grpc.Core;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalApi.Service.PersonService
{
    [Serializable]
    public class PersonAppService: IPersonService
    {
        private readonly AdventureWorks2019Context _dbAdvenContext;
        public PersonAppService(AdventureWorks2019Context dbAdvenContext)
        {
            _dbAdvenContext = dbAdvenContext;
        }

        public async Task<string> createPerson(int bussinessID, string personType, bool nameType, string title, string firstName, string middleName, string lastName, string suffix, int mailPromotion, Guid rowguid)
        {
            string Messege;
            try
            {
                var newPerson = new Person
                {
                    BusinessEntityId = bussinessID,
                    PersonType = personType,
                    NameStyle = nameType,
                    Title = title,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Suffix = suffix,
                    EmailPromotion = mailPromotion,
                    Rowguid = rowguid,
                    ModifiedDate = DateTime.Now,

                };
                await _dbAdvenContext.People.AddAsync(newPerson);
                _dbAdvenContext.SaveChanges();
                Messege = "Successful";

            }
            catch(Exception ex)
            {
                Messege = "Failed";
            }
            return Messege;
        }

        public async Task<string> UpdatePerson(int bussinessID, string personType, bool nameType, string title, string firstName, string middleName, string lastName, string suffix, Guid rowguid)
        {
            string Message;
            try
            {

                Person data = _dbAdvenContext.People.First(x => x.BusinessEntityId == bussinessID);
                data.BusinessEntityId = bussinessID;
                data.PersonType = personType;
                data.NameStyle = nameType;
                data.Title = title;
                data.FirstName = firstName;
                data.MiddleName = middleName;
                data.LastName = lastName;
                data.Suffix = suffix;
                data.ModifiedDate = DateTime.Now;
                data.Rowguid = rowguid;
                _dbAdvenContext.People.Update(data);
                await _dbAdvenContext.SaveChangesAsync();
                Message = "Updated Successfully";



            }
            catch (Exception ex)
            {
                Message = "Failed";
            }
            return Message;
        }

        //public async Task<object> UpdatePerson(PersonDTO personDto)
        //{
        //    try
        //    {
        //        Person data = _dbAdvenContext.People.FirstOrDefault(x => x.BusinessEntityId == personDto.BusinessEntityId);
        //        var successMessage = new MessageStatus();
        //        if (data == null)
        //        {
        //            successMessage = new MessageStatus
        //            {
        //                Status = true,
        //                Message = "Person Not Found For Update!",
        //                Data = null
        //            };
        //        }
        //        else
        //        {
        //            data.BusinessEntityId = personDto.BusinessEntityId;
        //            data.PersonType = personDto.PersonType;
        //            data.NameStyle = personDto.NameStyle;
        //            data.Title = personDto.Title;
        //            data.FirstName = personDto.FirstName;
        //            data.MiddleName = personDto.MiddleName;
        //            data.LastName = personDto.LastName;
        //            data.Suffix = personDto.Suffix;
        //            data.EmailPromotion = personDto.EmailPromotion;
        //            data.Rowguid = personDto.Rowguid;
        //            data.ModifiedDate = DateTime.Now;

        //            _dbAdvenContext.People.Update(data);
        //            await _dbAdvenContext.SaveChangesAsync();

        //            var details = from a in _dbAdvenContext.People
        //                          where a.BusinessEntityId == personDto.BusinessEntityId
        //                          select new Person()
        //                          {
        //                              BusinessEntityId = personDto.BusinessEntityId,
        //                              PersonType = personDto.PersonType,
        //                              NameStyle = personDto.NameStyle,
        //                              Title = personDto.Title,
        //                              FirstName = personDto.FirstName,
        //                              MiddleName = personDto.MiddleName,
        //                              LastName = personDto.LastName,
        //                              Suffix = personDto.Suffix,
        //                              EmailPromotion = personDto.EmailPromotion,
        //                              Rowguid = personDto.Rowguid,
        //                              ModifiedDate = DateTime.Now,
        //                          };
        //            successMessage = new MessageStatus
        //            {
        //                Status = true,
        //                Message = "Person Edited Successfully.",
        //                Data = details
        //            };

        //        }
        //        return successMessage;
        //    }
        //    catch (Exception ex)
        //    {
        //        var errormsg = new MessageStatus
        //        {
        //            Status = false,
        //            Message = "The given data was invalid.",

        //        };
        //        return errormsg;
        //    }
        //}

        //public async Task<List<Person>> GetEmailPromotionData(int emailPromotionID)
        //{
        //    string Messege;
        //    List<Person> people = new List<Person>();
        //    try
        //    {
        //        people = await Task.FromResult((from p in _dbAdvenContext.People
        //                                        where p.EmailPromotion == emailPromotionID
        //                                        select new Person()
        //                                        {
        //                                            BusinessEntity = p.BusinessEntity,
        //                                            FirstName = p.FirstName,
        //                                            MiddleName = p.MiddleName,
        //                                            LastName = p.LastName,
        //                                        }).ToList());
        //        Messege = "Successful";
        //    }
        //    catch (Exception ex)
        //    {
        //        Messege = "Failed";
        //    }
        //    return people;
        //}
    }
}
