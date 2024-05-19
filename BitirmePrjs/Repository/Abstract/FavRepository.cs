using BitirmePrjs.Context;
using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using System.Data;

namespace BitirmePrjs.Repository.Abstract
{
    public class FavRepository:IFavRepository
    {
        private readonly BContext _context;

        public FavRepository(BContext context)
        {
            _context = context;
        }

        public void create(FavDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", dto.email, DbType.String);
            parameters.Add("@urunId", dto.urunId, DbType.Int64);
            using var connection = _context.CreateSqlConnection();
           connection.Execute("sp_FavEkle", parameters, commandType: CommandType.StoredProcedure);
         

        }

        public IEnumerable<Fav> List()
        {
            

             
            using var connection = _context.CreateSqlConnection();
            var list = connection.Query<Fav>("sp_FavList", commandType: CommandType.StoredProcedure);
            return list;
        }

        public void sil(FavDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", dto.id, DbType.Int64);
            parameters.Add("@email", dto.email, DbType.String);
            parameters.Add("@urunId", dto.urunId, DbType.Int64);
           
            using var connection = _context.CreateSqlConnection();
            connection.Execute("sp_FavSil", parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
