using Csharpschool.Interfaces;
using Csharpschool.Models;
using Csharpschool.Models.Responses;
using System;
using System.Diagnostics;


namespace Csharpschool.Services;

public class ContactsService : IContactService
{
    private readonly FileService _fileService = new FileService(@"C:Csharpschool"); 
    private static readonly List<IContacts> _contacts = new List<IContacts>();

    

    public ServiceResult AddContactToList(IContacts contact)
    {
        var response = new ServiceResult();

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                response.Status = enums.ServiceResultStatus.SUCCESSED;

            }
            else
            {
                response.Status = enums.ServiceResultStatus.ALREADY_EXIST;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;

        }
        return response;

    }
    public ServiceResult DeleteContactsFromList(IContacts contact)
    {
        var response = new ServiceResult();

        try
        {
            if (_contacts.Contains(contact)) 
            {
                _contacts.Remove(contact);
                response.Status = enums.ServiceResultStatus.SUCCESSED;
            }
            else
            {
                response.Status = enums.ServiceResultStatus.NOT_FOUND;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

    public ServiceResult GetContactFromList(IContacts contact)
    {
        var response = new ServiceResult();

        try
        {
            if (_contacts.Contains(contact))
            {
                response.Status = enums.ServiceResultStatus.SUCCESSED;
                response.Result = contact;
            }
            else
            {
                response.Status = enums.ServiceResultStatus.NOT_FOUND;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

    public ServiceResult GetContactsFromList()
    {
        return null!;
    }

    public ServiceResult UpdateContactsInList(IContacts contact)
    {
        return null!;
    }

}