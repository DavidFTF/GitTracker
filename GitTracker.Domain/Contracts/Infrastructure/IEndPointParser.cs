using System.Threading.Tasks;

namespace GitTracker.Domain.Contracts.Infrastructure
{
    public interface IEndPointParser
    {
        Task<string> ParseEndpoint(object values, string endPoint, string parentTypeName = "");
    }
}