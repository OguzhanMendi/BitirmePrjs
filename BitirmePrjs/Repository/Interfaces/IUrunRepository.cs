using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface IUrunRepository
    {
        public void create(UrunDTO dto);

        public IEnumerable<Urun> urunList();
    }
}
