using Data.Models;
using System.Threading.Tasks;

namespace Services.Data
{
    public interface IHTMLExampleService
    {
        Task<HTMLExample> AddOrUpdate(HTMLExample example);
        Task<HTMLExample> Get(int id);
    }
}
