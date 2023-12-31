

using Csharpschool.Interfaces;
using Csharpschool.Models;
using System.Net.Mail;
using Csharpschool.Models.Responses;

namespace Csharpschool.Services;



public interface IMenuService
{
    void ShowMainMenu();
    void ShowAddContactsOption();
    void ShowViewContactsListOption();
    void ShowContacsDetailOption();
    void ShowDeleteContactsOption();
    void ShowUpdateContactsOption();

} 


internal class MenuService : IMenuService
{

    private readonly IContactService _contactService = new ContactsService();

    public void ShowMainMenu()
    {
        while(true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine($"{"1.",-3} Add Contact");
            Console.WriteLine($"{"2.",-3} View Contact List");
            Console.WriteLine($"{"3.",-3} View Contact Detalis");
            Console.WriteLine($"{"4.",-3} Delete Contact");
            Console.WriteLine($"{"0.",-3} Exit Application");
            Console.WriteLine();
            Console.Write("Enter Menu Option: ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    ShowAddContactsOption();
                    break;
                case "2":
                    ShowViewContactsListOption();
                    break;
                case "3":
                    ShowContacsDetailOption();
                    break;
                case "4":
                    ShowDeleteContactsOption();
                    break;
                case "0":
                    ShowExitApplicationOption();
                    break;
                default:
                    Console.WriteLine("Invalid Option Selected. Please try again.");
                    break;

            }

            Console.ReadKey();

        }
    }

    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to exit this application? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }

    }


    /// <summary>
    /// Menu for Contacts
    /// </summary>

    private void ShowAddContactsOption()
    {
        IContacts contact = new Contacts();

        DisplayMenuTitle("Add New Concact");

        Console.Write("First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("E-mail: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        contact.PhoneNumber = Console.ReadLine()!;



        var result = _contactService.AddContactToList(contact);

        switch(result.Status)
        {
            case enums.ServiceResultStatus.SUCCESSED:
                Console.WriteLine("The concact was added successfully");
                break;
            case enums.ServiceResultStatus.ALREADY_EXIST:
                Console.WriteLine("The concact already exists.");
                break;
            case enums.ServiceResultStatus.FAILED:
                Console.WriteLine("Failed when to trying to add new concact to contact list.");
                Console.WriteLine("See error message :: " + result.ToString());
                break;


        }

        DisplayPressAnyKey();
    }

    public void ShowContacsDetailOption()
    {
        
    }

    public void ShowDeleteContactsOption()
    {
        
    }

   
    public void ShowUpdateContactsOption()
    {
        
    }

    public void ShowViewContactsListOption()
    {
        DisplayMenuTitle("Contact List");
        var res = _contactService.GetContactsFromList();

        if (res.Status == enums.ServiceResultStatus.SUCCESSED)
        {
            if (res.Result is List<IContacts> contactList)

                if (!contactList.Any())
                {
                    Console.WriteLine("No contacts found"); 
                }
                else
                {
                    foreach (var contact in contactList)
                    {
                        Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
                    }
                }
        }

        DisplayPressAnyKey();
            
                
        
    }


    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"## {title} ##");
        Console.WriteLine();
    }

    void IMenuService.ShowAddContactsOption()
    {
        throw new NotImplementedException();
    }

    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

    }
}
