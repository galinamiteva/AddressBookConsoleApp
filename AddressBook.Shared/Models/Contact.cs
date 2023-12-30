

using AddressBook.Shared.Interfaces;

namespace AddressBook.Shared.Models
{
    

    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        

        public override string ToString()
        {
            return $"Name {FirstName} {LastName}\nEmail: {Email}\nPhoneNumber: {PhoneNumber}\nAddress: {Address}\nPostalCode: {PostalCode}\nCity: {City}\nCountry: {Country}\n ";
        }

    }
}
