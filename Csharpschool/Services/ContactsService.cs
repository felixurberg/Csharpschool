using Csharpschool.Interfaces;
using Csharpschool.Models;
using Csharpschool.Models.Responses;
using System;
using System.Diagnostics;


namespace Csharpschool.Services;

public class ContactsService : IContactService
{
    private readonly FileService _fileService new FileService(@"C:Csharpschool\Contactlist");
    private static readonly List<IContacts> _contacts = new List<IContacts>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>

    public ContactsService(string filePath)
    {
        _fileService = new FileService(filePath);
    }


    public ServiceResult AddContactToList(IContacts contact)
    {
        var response = new ServiceResult();

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveToJson(_contacts);
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
            var contactToRemove = _contacts.FirstOrDefault(x => x.Email == contact.Email);
            if (contactToRemove != null) 
            {
                _contacts.Remove(contactToRemove);
                _fileService.SaveToJson(_contacts);
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
            var existingContact = _contacts.FirstOrDefault(x => x.Email == contact.Email);
            if (contact != null)
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
        var response = new ServiceResult();
        
        try
        {
            var contacts = _fileService.LoadFromJson();
            _contacts.Clear();
            _contacts.AddRange(contacts);
            response.Status = enums.ServiceResultStatus.SUCCESSED;
            response.Result = _contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

    public ServiceResult UpdateContactsInList(IContacts contact)
    {
        var response = new ServiceResult();

        try
        {
            var existingContact = _contacts.FirstOrDefault(x => x.Email == contact.Email);
            if (existingContact !=null)
            {
                _contacts.Remove(existingContact);
                _contacts.Add(contact);
                _fileService.SaveToJson(_contacts);
                
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

}