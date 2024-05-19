using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface IFavRepository
    {
        public void create(FavDTO dto);

        public void sil(FavDTO dto);

        public IEnumerable<Fav> List();
    }
}
