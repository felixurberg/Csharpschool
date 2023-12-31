using Csharpschool.Models.Responses;
using static Csharpschool.Models.Responses.enums;

namespace Csharpschool.Interfaces;

public interface IServiceResult
{
    object Result { get; set; }
    ServiceResultStatus Status { get; set; }
}