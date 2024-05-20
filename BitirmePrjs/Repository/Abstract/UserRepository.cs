using BitirmePrjs.Context;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using System.Data;

namespace BitirmePrjs.Repository.Abstract
{
    public class UserRepository : IUserRepository
    {
        private readonly BContext _context;

        public UserRepository(BContext context)
        {
            _context = context;
        }

        public IEnumerable<Kullanici> List()
        {
            try
            {
                using var connection = _context.CreateSqlConnection();
                var list = connection.Query<Kullanici>("sp_UserList", commandType: CommandType.StoredProcedure);
                return list;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void PasifeAl(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Sil(int id)
        {
            try
            {
                //sp_UserSil

                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);
                using var connection = _context.CreateSqlConnection();
                connection.Execute("sp_UserSil", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
