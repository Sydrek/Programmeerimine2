using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data.Repositories
{
    // 28.11
    // ToDo listide repository klass
    public class TellimusRepository : BaseRepository<TellimusList>, ITellimusRepository
    {
        public TellimusRepository(ApplicationDbContext dbContext) : 
            base(dbContext)
        {
        }

        // Lisa siia spetsiifilisemad meetodid,
        // mis on seotud ToDoListidega

        // BaseRepository ei tea, et Get peab tooma kaasa ka Itemsid
        public override async Task<TellimusList> GetByIdAsync(int ID)
        {
            return await DbContext
                .Tellimused
                .Include(list => list.Items)
                .Where(list => list.ID == ID)
                .FirstOrDefaultAsync();
        }
    }
}
