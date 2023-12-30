

using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using System.Diagnostics;

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
                Console.WriteLine("==================");
                Console.WriteLine();

                Console.WriteLine("First name: ");
                var validatedFirstName = Console.ReadLine()!;
                validatedFirstName = ValidateText(validatedFirstName);
                if (validatedFirstName != null) { break; }
                contact.FirstName = validatedFirstName!;

                Console.WriteLine("Last name: ");
                var validatedLastName = Console.ReadLine()!;
                validatedLastName = ValidateText(validatedLastName);
                if (validatedLastName != null) { break; }
                contact.LastName = validatedLastName!;

                Console.WriteLine("Email: ");
                var validatedLastEmail = Console.ReadLine()!;
                validatedLastEmail = ValideEmail(validatedLastEmail);
                if (validatedLastEmail != null) { break; }
                contact.Email = validatedLastEmail!;


                Console.WriteLine("PhoneNumber: ");
                var validatedLastPhoneNumber = Console.ReadLine()!;
                validatedLastPhoneNumber = ValideNum(validatedLastPhoneNumber);
                if (validatedLastPhoneNumber != null) { break; }
                contact.PhoneNumber = validatedLastPhoneNumber!;

                Console.WriteLine("Address: ");
                var validatedLastAddress = Console.ReadLine()!;
                validatedLastAddress = ValidateText(validatedLastAddress);
                if (validatedLastAddress != null) { break; }
                contact.Address = validatedLastAddress!;

                Console.WriteLine("PostalCode: ");
                var validatedLastPostalCode = Console.ReadLine()!;
                validatedLastPostalCode = ValideNum(validatedLastPostalCode);
                if (validatedLastPostalCode != null) { break; }
                contact.PostalCode = validatedLastPostalCode!;

                Console.WriteLine("City: ");
                var validatedCity = Console.ReadLine()!;
                validatedCity = ValidateText(validatedCity);
                if (validatedCity != null) { break; }
                contact.City = validatedCity!;


                Console.WriteLine("Country: ");
                var validatedCountry = Console.ReadLine()!;
                validatedCountry = ValidateText(validatedCountry);
                if (validatedCountry != null) { break; }
                contact.Country = validatedCountry!;
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
    }


    public void ShowContactList()
    {

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



    public static string ValideNum(string text) 
    {
        if(string.IsNullOrEmpty(text))
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
        if (string.IsNullOrEmpty(text) && text!.Contains("@"))
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
