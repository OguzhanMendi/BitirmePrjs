using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface IUrunRepository
    {
        public void create(UrunDTO dto);

        public IEnumerable<Urun> urunList();

        public void update(UrunDTO dto);

        public Urun urunbul(int id);

        public void sil(int id);


        public IEnumerable<Urun> benzerUrunList(BenzerUrunlerDTO dto);

    }
}
