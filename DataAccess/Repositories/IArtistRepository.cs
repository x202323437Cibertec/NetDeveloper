using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IArtistRepository: IRepository<Artist>
    {
        IEnumerable<Artist> GetArtistsByStore();

        Artist GetByName(string pName);

        IEnumerable<Artist> GetArtistPage(int pPageIndex, int pPageSize);

        int count();
    }
}
