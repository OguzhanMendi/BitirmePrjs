using BitirmePrjs.Context;
using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Xml;

namespace BitirmePrjs.Repository.Abstract
{
    public class UrunRepository : IUrunRepository
    {
        private readonly BContext _context;

        public UrunRepository(BContext context)
        {
            _context = context;
        }

        public IEnumerable<Urun> benzerUrunList(BenzerUrunlerDTO dto)
        {
            var query = @$"Select * From Urunler  where urunMarka='{dto.urunMarka}' and urunKategori='{dto.urunKategori}'";
            using var connection = _context.CreateSqlConnection();
            var urunler = connection.Query<Urun>(query);
            return urunler.ToList();
        }

        public void create(UrunDTO dto)
        {
            try
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
            catch (Exception ex)
            {

                throw;
            }
        }

        public void sil(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int64);
            using var connection = _context.CreateSqlConnection();
            connection.Execute("sp_Urunsil", parameters, commandType: CommandType.StoredProcedure);
        }

        public void update(UrunDTO dto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", dto.id, DbType.Int64);
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
                var kullanici = connection.Execute("sp_UrunGuncelle", parameters, commandType: CommandType.StoredProcedure);
            }
            catch ( Exception ex)
            {

                throw;
            }

        }

        public Urun urunbul(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                using var connection = _context.CreateSqlConnection();
                var urun = connection.Query<Urun>("sp_UrunBul", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return urun;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Urun> urunList()
        {
            var query = "Select * From Urunler order by 1 desc";
            using var connection = _context.CreateSqlConnection();
            var urunler = connection.Query<Urun>(query);
            return urunler.ToList();
        }
    }
}
