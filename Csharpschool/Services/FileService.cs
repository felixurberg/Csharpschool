using Csharpschool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace Csharpschool.Services;



public class FileService 
{
    private readonly string _filePath;

    

    public FileService(string filePath)
    {
        _filePath = filePath;
    }


    public void SaveToJson(List<IContacts> contacts)
    {
        var json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
    
    public List<IContacts> LoadFromJson()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<IContacts>>(json) ?? new List<IContacts>();
        }

        return new List<IContacts>();
    }

     
        
        


}   
