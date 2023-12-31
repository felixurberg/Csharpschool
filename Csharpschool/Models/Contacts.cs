

namespace Csharpschool.Models;



/// <summary>
/// Data model for concact information
/// </summary>

public class Contacts : IContacts

{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
