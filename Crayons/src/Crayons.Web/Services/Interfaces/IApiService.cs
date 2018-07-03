using System.Threading.Tasks;

namespace Crayons.Web.Services.Interfaces
{
    public interface IApiService
    {
        Task<T> Get<T>(string url) where T : class;

        Task Post<T>(T entity, string url, string token = "");
    }
}