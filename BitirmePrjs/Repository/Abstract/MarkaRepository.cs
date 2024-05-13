using BitirmePrjs.Context;
using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Net.Sockets;

namespace BitirmePrjs.Repository.Abstract
{
    public class MarkaRepository : IMarkaRepository
    {
        private readonly BContext _context;

        public MarkaRepository(BContext context)
        {
            _context = context;
        }

        public void create(MarkaDTO dto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@markaAd", dto.markaAd, DbType.String);
                parameters.Add("@imgUrl", dto.imgUrl, DbType.String);


                using var connection = _context.CreateSqlConnection();
                var kullanici = connection.Execute("sp_MarkaOlustur", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {


            }

        }

        public IEnumerable<Marka> MarkalariListele()
        {
            try
            {
                var query = "Select * From Marka";
                using var connection = _context.CreateSqlConnection();
                var markalar = connection.Query<Marka>(query);
                return markalar.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
