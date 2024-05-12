using BitirmePrjs.Context;
using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace BitirmePrjs.Repository.Abstract
{
    public class LoginRepository : ILoginRepository
    {
        private readonly BContext _context;

        public LoginRepository(BContext context)
        {
            _context = context;
        }

        public Kullanici create(LoginDTO dto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", dto.email, DbType.String);
                parameters.Add("@sifre", dto.sifre, DbType.String);
                parameters.Add("@rol", "u", DbType.String);

                using var connection = _context.CreateSqlConnection();
                var kullanici = connection.Query<Kullanici>("sp_KullaniciOlustur", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return kullanici;
            }
            catch (Exception ex)
            {
                return null;


            }
        }

        public Kullanici login(LoginDTO dto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", dto.email, DbType.String);
                parameters.Add("@sifre", dto.sifre, DbType.String);
                using var connection = _context.CreateSqlConnection();
                var kullanici = connection.Query<Kullanici>("sp_KullaniciLogin", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return kullanici;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


    }
}
