

using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using Newtonsoft.Json;
using System.Data.Common;
using System.Diagnostics;

namespace AddressBook.Shared.Services;



public class ContactService : IContactService
{

    public List<IContact> ContactList { get; set; } = [];
    private readonly FileService _fileService = new();


    /// <summary>
    /// Add a contact to the list if it does not already exist based on the email address.
    /// </summary>
    /// <param name="contact">An item of the IContact representing the contact to add.</param>
    /// <returns>Returns true if the contact was added and false otherwise.</returns>

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!ContactList.Any(x => x.Email == contact.Email))
            {
                ContactList.Add((Contact)contact);

                string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                var result = _fileService.SaveContentToFile(json);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    /// <summary>
    /// Gets all contacts  in the list.
    /// </summary>
    /// <returns>Returns the list if it's not null.</returns>

    public IEnumerable<IContact> GetAllContactsFromList()
    {
        try
        {

            if (ContactList != null)
            {

                var content = _fileService.GetContentFromFile();
                ContactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;


                return ContactList!;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }



    /// <summary>
    /// Get one contact based on email.
    /// </summary>
    /// <param name="email">Email used to used to search efter contact.</param>
    /// <returns>If found send back contact else send back null.</returns>
    public IContact GetOneContact(string email)
    {
        try
        {
            if (!string.IsNullOrEmpty(email))
                foreach (var contact in ContactList)
                {
                    if (contact.Email == email)
                    {
                        var content = _fileService.GetContentFromFile();
                        ContactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                        return contact;
                    }
                }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    /// <summary>
    /// Delete one contact from list based on email.
    /// </summary>
    /// <param name="email">The email address of the contact to be removed</param>
    /// <returns>Returns true if contact is removed from list and list is updated</returns>
    public bool DeleteContactFromList(string email)
    {
        try
        {
            if (!string.IsNullOrEmpty(email))
            {
                foreach (var contact in ContactList)
                {
                    if (contact.Email == email)
                    {
                        ContactList.Remove(contact);
                        string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                        var result = _fileService.SaveContentToFile(json);
                        return result;
                    }
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    /// <summary>
    /// Updates contact in list with new information.
    /// </summary>
    /// <param name="email">Email to current contact.</param>
    /// <param name="updatedFirstName">updatedFirstName.</param>
    /// <param name="updatedLastName">updatedLastName.</param>
    /// <param name="Street">updatedStreet.</param>
    /// <param name="updatedStreetNumber">updatedStreetNumber.</param>
    /// <param name="updatedCity">updatedCity.</param>
    /// <param name="updatedPhoneNumber">updatedPhoneNumber.</param>
    /// <param name="updatedPostalCode">updatedPostalCode.</param>
    /// <param name="updatedCountry">updatedCountry.</param>
    /// <returns>Returns true if contact is updated and saved to file. Else returns false.</returns>
    public bool UpdateContactInList(string email, string updatedFirstName, string updatedLastName, string updatedStreet, string updatedStreetNumber, string updatedPhoneNumber, string updatedPostalCode, string updatedCity, string updatedCountry)

    //void UpdateContactInList(string contactEmailInput, string validatedFirstName, string validatedLastName, string validatedStreet, string validatedStreetNumber, string validatedPhoneNumber, string validatedPostalCode, string validatedCity, string validatedCountry);
    {
        try
        {
            foreach (var contact in ContactList)
            {
                if (contact.Email == email)
                {
                    contact.FirstName = updatedFirstName;
                    contact.LastName = updatedLastName;
                    contact.Street = updatedStreet;
                    contact.StreetNumber = updatedStreetNumber;
                    contact.City = updatedCity;
                    contact.PhoneNumber = updatedPhoneNumber;
                    contact.PostalCode = updatedPostalCode;
                    contact.Country = updatedCountry;


                    string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                    var result = _fileService.SaveContentToFile(json);
                    return result;

                }
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


}
