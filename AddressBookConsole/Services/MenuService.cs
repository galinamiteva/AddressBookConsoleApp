

using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;

namespace AddressBookConsole.Services;

public class MenuService
{
    private readonly IContactService _contactService;

    public MenuService(IContactService contactService)
    {
        _contactService = contactService; 
    }


    public void ShowMainMenu()
    {
        try
        {
            while (true)
            {
                Console.WriteLine("***MENU***");
                Console.WriteLine();
                Console.WriteLine("[1] Add contact");
                Console.WriteLine("[2] Contact List");
                Console.WriteLine("[3] Update contact");
                Console.WriteLine("[4] Delete contact");
                Console.WriteLine("[5] Search contact");
                Console.WriteLine("[6] Exit");

                int.TryParse(Console.ReadLine(), out int userMenuInput);
                Console.Clear();

                switch (userMenuInput)
                {
                    case 1:
                        ShowAddMenu();
                        break;
                    case 2:
                        ShowContactList();
                        break;
                    case 3:
                        ShowContactUpdateList();
                        break;
                    case 4:
                        ShowDeleteMenu();
                        break;
                    case 5:
                        ShowSearchOneContact();
                        break;
                    case 6:
                        ShowExitMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input!");
                        break;

                }
                Console.ReadKey();
                Console.Clear();

            }



        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);    
        }
    }

    public void ShowAddMenu()
    {
        try
        {
            while (true)
            {
                IContact contact = new Contact();

                ShowText("Add contact");
                Console.WriteLine("============");
                Console.WriteLine();

                Console.Write("First name: ");
                var validatedFirstName = Console.ReadLine()!;
                validatedFirstName = ValidateText(validatedFirstName);
                if (validatedFirstName == null) { break; }
                contact.FirstName = validatedFirstName;

                Console.Write("Last name: ");
                var validatedLastName = Console.ReadLine()!;
                validatedLastName = ValidateText(validatedLastName);
                if (validatedLastName == null) { break; }
                contact.LastName = validatedLastName;

                Console.Write("Email: ");
                var validatedEmail = Console.ReadLine()!;
                validatedEmail = ValideEmail(validatedEmail);
                if (validatedEmail == null) { break; }
                contact.Email = validatedEmail;


                Console.Write("PhoneNumber: ");
                var validatedPhoneNumber = Console.ReadLine()!;
                validatedPhoneNumber = ValideNumber(validatedPhoneNumber);
                if (validatedPhoneNumber == null) { break; }
                contact.PhoneNumber = validatedPhoneNumber;

                Console.Write("Address: ");
                var validatedAddress = Console.ReadLine()!;
                validatedAddress = ValidateText(validatedAddress);
                if (validatedAddress == null) { break; }
                contact.Address = validatedAddress;

                Console.Write("PostalCode: ");
                var validatedPostalCode = Console.ReadLine()!;
                validatedPostalCode = ValideNumber(validatedPostalCode);
                if (validatedPostalCode == null) { break; }
                contact.PostalCode = validatedPostalCode;

                Console.Write("City: ");
                var validatedCity = Console.ReadLine()!;
                validatedCity = ValidateText(validatedCity);
                if (validatedCity == null) { break; }
                contact.City = validatedCity;


                Console.Write("Country: ");
                var validatedCountry = Console.ReadLine()!;
                validatedCountry = ValidateText(validatedCountry);
                if (validatedCountry == null) { break; }
                contact.Country = validatedCountry;

                var savedContact =_contactService.AddContactToList(contact);
                if(savedContact!= true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact already in list");
                    break;

                }
                Console.WriteLine();
                ShowText("Contact saved");
                Console.WriteLine("=============");
                break;
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }


    public void ShowContactList()
    {
        try
        {
            while (true)
            {
                ShowText("Contact List");
                Console.WriteLine("==================\n");

                
                var contactList = _contactService.GetAllContactsFromList();

                if (contactList != null && contactList.Any())
                {
                    foreach (var contact in contactList)
                    {
                        Console.WriteLine($"Name {contact.FirstName} {contact.LastName}\nEmail: {contact.Email}\nPhoneNumber: {contact.PhoneNumber}\nAddress: {contact.Address}\nPostalCode: {contact.PostalCode}\nCity: {contact.City}\nCountry: {contact.Country}\n " + "\n=============================================\n");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("The contact list is empty!");
                    Console.WriteLine("=============================");
                }
                break;
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }

    public void ShowContactUpdateList() 
    {
        try
        {
            while(true)
            {
                ShowText("Update contact");
                Console.WriteLine("==================\n");
                Console.Write("Update contact by email: ");
                string contactEmailInput = ValideEmail(Console.ReadLine()!);
                var contactToBeUpdated = _contactService.GetOneContact(contactEmailInput);
                Thread.Sleep(300);
                Console.Clear();

                if(contactToBeUpdated != null)
                {
                    ShowText("Contact was found");
                    Console.WriteLine("==================");
                    Console.WriteLine();
                    Console.WriteLine($"Name {contactToBeUpdated.FirstName} {contactToBeUpdated.LastName}\nEmail: {contactToBeUpdated.Email}\nPhoneNumber: {contactToBeUpdated.PhoneNumber}\nAddress: {contactToBeUpdated.Address}\nPostalCode: {contactToBeUpdated.PostalCode}\nCity: {contactToBeUpdated.City}\nCountry: {contactToBeUpdated.Country}\n " + "\n=============================================\n");
                    Console.Write("\nDo you want to update? (y/n): ");
                    string contactAnswerUpdate = ValidateText(Console.ReadLine()!);
                    Thread.Sleep(300);
                    Console.Clear();

                    if(contactAnswerUpdate == "y" || contactAnswerUpdate == "yes")
                    {
                        Console.Write("First name: ");
                        var validatedFirstName = Console.ReadLine()!;
                        validatedFirstName = ValidateText(validatedFirstName);
                        if (validatedFirstName == null) { break; }
                        contactToBeUpdated.FirstName = validatedFirstName;

                        Console.Write("Last name: ");
                        var validatedLastName = Console.ReadLine()!;
                        validatedLastName = ValidateText(validatedLastName);
                        if (validatedLastName == null) { break; }
                        contactToBeUpdated.LastName = validatedLastName;

                        Console.Write("Email: ");
                        var validatedEmail = Console.ReadLine()!;
                        validatedEmail = ValideEmail(validatedEmail);
                        if (validatedEmail == null) { break; }
                        contactToBeUpdated.Email = validatedEmail;


                        Console.Write("PhoneNumber: ");
                        var validatedPhoneNumber = Console.ReadLine()!;
                        validatedPhoneNumber = ValideNumber(validatedPhoneNumber);
                        if (validatedPhoneNumber == null) { break; }
                        contactToBeUpdated.PhoneNumber = validatedPhoneNumber;

                        Console.Write("Address: ");
                        var validatedAddress = Console.ReadLine()!;
                        validatedAddress = ValidateText(validatedAddress);
                        if (validatedAddress == null) { break; }
                        contactToBeUpdated.Address = validatedAddress;

                        Console.Write("PostalCode: ");
                        var validatedPostalCode = Console.ReadLine()!;
                        validatedPostalCode = ValideNumber(validatedPostalCode);
                        if (validatedPostalCode == null) { break; }
                        contactToBeUpdated.PostalCode = validatedPostalCode;

                        Console.Write("City: ");
                        var validatedCity = Console.ReadLine()!;
                        validatedCity = ValidateText(validatedCity);
                        if (validatedCity == null) { break; }
                        contactToBeUpdated.City = validatedCity;


                        Console.Write("Country: ");
                        var validatedCountry = Console.ReadLine()!;
                        validatedCountry = ValidateText(validatedCountry);
                        if (validatedCountry == null) { break; }
                        contactToBeUpdated.Country = validatedCountry;

                        _contactService.UpdateContactInList(contactEmailInput, validatedFirstName, validatedLastName, validatedAddress,validatedPhoneNumber, validatedPostalCode, validatedCity, validatedCountry );

                        ShowText("Contact was updated");
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    ShowText("Contact wasn't found");
                    Console.WriteLine("==================");
                    break;
                }
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }


    public void ShowDeleteMenu() 
    {
        try
        {
            while (true)
            {
                ShowText("Delete contact");
                Console.WriteLine("====================\n");

                Console.Write("Delete a contact by email");
                string contactRemoveInputEmail = ValideEmail(Console.ReadLine()!);
                var contactToBeRemoveFound = _contactService.GetOneContact(contactRemoveInputEmail);

                if (contactToBeRemoveFound != null)
                {
                    Console.WriteLine($"Name {contactToBeRemoveFound.FirstName} {contactToBeRemoveFound.LastName}\nEmail: {contactToBeRemoveFound.Email}\nPhoneNumber: {contactToBeRemoveFound.PhoneNumber}\nAddress: {contactToBeRemoveFound.Address}\nPostalCode: {contactToBeRemoveFound.PostalCode}\nCity: {contactToBeRemoveFound.City}\nCountry: {contactToBeRemoveFound.Country}\n " + "\n=============================================\n");
                    Console.WriteLine();
                    Console.WriteLine("Do you want to delete? (y/n): ");
                    string contactAnswerDelete = ValidateText(Console.ReadLine()!);
                    Thread.Sleep(300);
                    Console.Clear();

                    if (contactAnswerDelete == "y" || contactAnswerDelete == "yes")
                    {
                        var deletedContact = _contactService.DeleteContactFromList(contactRemoveInputEmail);
                        ShowText("The contact was deleted");
                        Thread.Sleep(800);
                        break;
                    }
                }

                if (contactToBeRemoveFound == null)
                {
                    Console.WriteLine();
                    ShowText("Contact wasn't found");                   
                    break;
                }
                break;
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }


    public void ShowSearchOneContact()
    {
        try
        {
            ShowText("Search contact");
            Console.WriteLine("====================\n");

            ShowText("Search a contact by email. Please, input the email: ");
            var contactFound =_contactService.GetOneContact(ValideEmail(Console.ReadLine()!));
            Thread.Sleep(500);
            Console.Clear();  
            
            if(contactFound != null)
            {
                ShowText("Contact was found");
                Console.WriteLine("==================");
                Console.WriteLine();
                Console.WriteLine($"Name {contactFound.FirstName} {contactFound.LastName}\nEmail: {contactFound.Email}\nPhoneNumber: {contactFound.PhoneNumber}\nAddress: {contactFound.Address}\nPostalCode: {contactFound.PostalCode}\nCity: {contactFound.City}\nCountry: {contactFound.Country}\n " + "\n=============================================\n");
            }
            else
            {
                ShowText("Contact wasn't found");
                Console.WriteLine("==================");

            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }


    public static void ShowExitMenu()
    {
        try 
        {
            Console.Write("Do you want to exit? (y/n): ");
            string contactExitInput = ValidateText(Console.ReadLine()!);
            if(contactExitInput =="y"|| contactExitInput == "yes") 
            { 
                Environment.Exit(0);
            }

        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }









    public static void ShowText(string text) 
    {
        Console.WriteLine($"\n{text}");
    }



    public static string ValidateText(string text) 
    {
        if(!string.IsNullOrEmpty(text)&& !text!.Any(char.IsDigit))
        {
            return text!.ToLower();    
        }
        else 
        {
            Console.WriteLine("Invalid text");
            return null!;
        }
    }



    public static string ValideNumber(string text) 
    {
        if(!string.IsNullOrEmpty(text))
        {
            return text!.ToLower();
        }
        else
        {
            Console.WriteLine("Invalid text");
            return null!;
        }
    }




    public static string ValideEmail(string text)
    {
        if (!string.IsNullOrEmpty(text) && text!.Contains("@"))
        {
            return text!.ToLower();
        }
        else
        {
            Console.WriteLine("Invalid email");
            return null!;
        }
    }
}
