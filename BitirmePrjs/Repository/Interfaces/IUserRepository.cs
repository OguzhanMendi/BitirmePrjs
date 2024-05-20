using BitirmePrjs.Entities;

namespace BitirmePrjs.Repository.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<Kullanici> List();

        public void PasifeAl(int id);

        public void Sil(int id);


    }
}
