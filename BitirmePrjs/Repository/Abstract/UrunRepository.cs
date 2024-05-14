using BitirmePrjs.Context;
using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using System.Data;

namespace BitirmePrjs.Repository.Abstract
{
    public class UrunRepository : IUrunRepository
    {
        private readonly BContext _context;

        public UrunRepository(BContext context)
        {
            _context = context;
        }

        public void create(UrunDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@urunAd", dto.urunAd, DbType.String);
            parameters.Add("@urunAciklama", dto.urunAciklama, DbType.String);
            parameters.Add("@urunMarka", dto.urunMarka, DbType.String);
            parameters.Add("@urunKategori", dto.urunKategori, DbType.String);
            parameters.Add("@urunozellik", dto.urunozellik, DbType.String);
            parameters.Add("@urunAdet", dto.urunAdet, DbType.Int64);
            parameters.Add("@urunFiyat", dto.urunFiyat, DbType.Int64);
            parameters.Add("@urunKdv", dto.urunKdv, DbType.Int64);
            parameters.Add("@imgUrl", dto.imgUrl, DbType.String);
            parameters.Add("@aktif", dto.aktif, DbType.Boolean);
           
            using var connection = _context.CreateSqlConnection();
            var kullanici = connection.Execute("sp_UrunOlustur", parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Urun> urunList()
        {
            var query = "Select * From Urunler";
            using var connection = _context.CreateSqlConnection();
            var urunler = connection.Query<Urun>(query);
            return urunler.ToList();
        }
    }
}
