
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;

namespace AddressBookConsole.Tests;

public class ContactService_Test
{
    [Fact]  
    public void AddToListShould_AddOneContactToContactList_ThenReturnTrue()
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
       
        //Act
        bool result = contactService.AddContactToList(contact);

        //Assert
        Assert.True(result);
    }



    [Fact]

    public void GetAllFromListShould_GetAllContactsInContactList_ThenReturnListOfContact()
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

        //Act
        contactService.AddContactToList(contact);
        var contactList = contactService.GetAllContactsFromList();  

        //Assert
        Assert.NotNull(contactList);

    }

    [Fact]  

    public void GetOneContactByEmail_ShouldGetOneContactFromList_ThenReturnOneContact()
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

        //Act

        contactService.AddContactToList(contact);   
        var oneContactFromList = contactService.GetOneContact(contact.Email);   

        //Assert
        Assert.NotNull(oneContactFromList); 
    }



    [Fact]  
    public void DeleteOneContactByEmail_ShouldDeleteOneContactFromList_AndReturnTrue() 
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

        //Act

        contactService.AddContactToList(contact);
        var deleteOneContactByEmail = contactService.DeleteContactFromList(contact.Email);
        var updatedContactList= contactService.GetAllContactsFromList();

        //Assert
        Assert.True(deleteOneContactByEmail);
        Assert.DoesNotContain(updatedContactList, x=>x.Email==contact.Email);
    }

    [Fact]
    public void UpdateOneContactInList_ShouldUpdateContact_ReturnTrue() 
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



        //Act

        contactService.AddContactToList(contact);
        var updatedContact = contactService.UpdateContactInList(contact.Email, "Dobbe", "Mitev", "777777", "Furutorpsgatan", "52", "22222", "Malmo", "Sverige");
        var updatedContactList = contactService.GetAllContactsFromList();
        
        //Assert
        Assert.True(updatedContact);
        Assert.Contains(updatedContactList, x => x.Email == contact.Email);
        Assert.Contains(updatedContactList, x => x.Email == "aaa@com");





    }


}



