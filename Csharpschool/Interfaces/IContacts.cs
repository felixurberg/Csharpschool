namespace Csharpschool.Models;

public interface IContacts
{
    string Address { get; set; }
    string Email { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
}