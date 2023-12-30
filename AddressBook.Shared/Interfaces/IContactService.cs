using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(IContact contact);
    bool DeleteContactFromList(string email);
    IEnumerable<IContact> GetAllContactsFromList();
    IContact GetOneContact(string email);
    bool UpdateContactInList(string email, string updatedFirstName, string updatedLastName, string updatedAddress, string updatedCity, string updatedPhoneNumber, string updatedPostalCode, string updatedCountry);

}
