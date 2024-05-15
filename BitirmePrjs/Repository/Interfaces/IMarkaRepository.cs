using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using System.Net.Sockets;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface IMarkaRepository
    {
        public void create(MarkaDTO dto);

        public IEnumerable<Marka> MarkalariListele();



    }
}
