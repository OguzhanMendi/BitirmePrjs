using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface ILoginRepository
    {

        public Kullanici login(LoginDTO dto);

        public Kullanici create(LoginDTO dto);
    }
}
