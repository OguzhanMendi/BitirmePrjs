using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface ISepetRepository
    {
        public void Create(SepetDTO dto);

        public IEnumerable<Sepet> SepetList(indirimDTO dto);

        public void sepetAdetDegistir(SepetAdetDTO dto);

        public void sepetOnayla(SepetOnaylaDTO dto);


        public IEnumerable<Sepet> gecmisSiparisler(string email);

        public IEnumerable<Sepet> siparisIdList(string siparisId);


    }
}
