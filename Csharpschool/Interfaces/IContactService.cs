using Csharpschool.Models;
using Csharpschool.Models.Responses;

namespace Csharpschool.Interfaces;

public interface IContactService
{
    ServiceResult AddContactToList(IContacts contact);
    ServiceResult GetContactFromList(IContacts contact);
    ServiceResult GetContactsFromList();
    ServiceResult UpdateContactsInList(IContacts contact);
    ServiceResult DeleteContactsFromList(IContacts contact);


}
