

using Csharpschool.Interfaces;
using static Csharpschool.Models.Responses.enums;
namespace Csharpschool.Models.Responses;





public class ServiceResult : IServiceResult
{
   
    public ServiceResultStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
