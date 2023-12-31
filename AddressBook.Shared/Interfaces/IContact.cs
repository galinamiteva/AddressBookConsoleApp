

namespace AddressBook.Shared.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string Email { get; set; }

        string PhoneNumber { get; set; }
        string Street { get; set; }
        string StreetNumber { get; set; }
        string City { get; set; }                
        
        string PostalCode { get; set; } 
        string Country { get; set; }    
       

    }
}
