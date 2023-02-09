using FinalApi.Models;

namespace FinalApi.DTO
{
    public class PersonDTO
    {
        public int BusinessEntityId { get; set; }

       
        public string PersonType { get; set; }

   
        public bool NameStyle { get; set; }

     
        public string Title { get; set; }

    
        public string FirstName { get; set; }

     
        public string MiddleName { get; set; }

  
        public string LastName { get; set; } = null!;

       
        public string Suffix { get; set; }

    
        public int EmailPromotion { get; set; }

     
        public string AdditionalContactInfo { get; set; }

        public string Demographics { get; set; }

     
        public Guid Rowguid { get; set; }

      
        public DateTime ModifiedDate { get; set; }


        public virtual BusinessEntity BusinessEntity { get; set; } = null!;

        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; } = new List<BusinessEntityContact>();

        public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

        public virtual ICollection<EmailAddress> EmailAddresses { get; } = new List<EmailAddress>();

        public virtual Employee? Employee { get; set; }

        public virtual Password? Password { get; set; }

        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; } = new List<PersonCreditCard>();

        public virtual ICollection<PersonPhone> PersonPhones { get; } = new List<PersonPhone>();
    }
}
