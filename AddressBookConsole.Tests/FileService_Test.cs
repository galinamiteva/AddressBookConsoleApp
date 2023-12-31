

using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using Newtonsoft.Json;

namespace AddressBookConsole.Tests;

public class FileService_Test
{
    [Fact]

    public void SaveToFileShould_ReturnFalse_IfFilePathDoNotExists()
    {
        //Arrange

        IContact contact = new Contact
        {
            FirstName = "Alexandra",
            LastName = "Miteva",
            Email = "aaa@com",
            PhoneNumber = "123456",
            Street = "Furutorpsgatan",
            StreetNumber = "52",
            PostalCode = "25255",
            City = "Helsingborg",
            Country = "Sverige"
        };
        IContactService contactService = new ContactService();
        FileService fileService = new();     


        //Act

        contactService.AddContactToList(contact);
        var contactList = contactService.GetAllContactsFromList();
        string json = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings { TypeNameHandling=TypeNameHandling.All});
        var result = fileService.SaveContentToFile(json);

        //Assert

        Assert.True(result);
    }

    [Fact]  
    public void GetContentFromFile_ShouldGetContentFromFile_ReturnContent() 
    {
        //Arrange
        IContact contact = new Contact
        {
            FirstName = "Alexandra",
            LastName = "Miteva",
            Email = "aaa@com",
            PhoneNumber = "123456",
            Street = "Furutorpsgatan",
            StreetNumber = "52",
            PostalCode = "25255",
            City = "Helsingborg",
            Country = "Sverige"
        }; 
        IContactService contactService = new ContactService(); 
        FileService fileService = new();


        //Act

        contactService.AddContactToList(contact);
        var contactList = contactService.GetAllContactsFromList();
        string json = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        var result= fileService.SaveContentToFile(json);

        var content = fileService.GetContentFromFile();
        contactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling= TypeNameHandling.All});


        //Assert
        Assert.Equal(json, content);
        

    }
}
