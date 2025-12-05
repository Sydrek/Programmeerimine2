using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    // 28.11
    // ToDo listide repository interface (Program.cs failis
    // tuleb see ka ära regada)
    public interface IArveRepository
    {
        Task<ArveList> GetByIdAsync(int ID);
        Task SaveAsync(ArveList list);
        Task DeleteAsync(ArveList entity);
    }
}
