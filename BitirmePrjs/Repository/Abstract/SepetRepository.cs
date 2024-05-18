using BitirmePrjs.Context;
using BitirmePrjs.DTOs;
using BitirmePrjs.Entities;
using BitirmePrjs.Repository.Interfaces;
using Dapper;
using Microsoft.JSInterop.Infrastructure;
using System.Data;
namespace BitirmePrjs.Repository.Abstract
{
    public class SepetRepository : ISepetRepository
    {
        private readonly BContext _context;
        public SepetRepository(BContext context)
        {
            _context = context;
        }
        public void Create(SepetDTO dto)
        {
            try
            {
                decimal toplamtutar = 0;
                if (dto.toplamTutar == 0)
                {
                    toplamtutar = dto.urunAdet * dto.urunFiyat;
                }
                else
                {
                    toplamtutar = dto.toplamTutar;
                }
                var parameters = new DynamicParameters();
                parameters.Add("@urunAd", dto.urunAd, DbType.String);
                parameters.Add("@urunAdet", dto.urunAdet, DbType.Int32); // Changed from DbType.Int64 to DbType.Int32
                parameters.Add("@urunFiyat", dto.urunFiyat, DbType.Int32); // Changed from DbType.Int64 to DbType.Int32
                parameters.Add("@toplamTutar", toplamtutar, DbType.Decimal);
                parameters.Add("@imgUrl", dto.imgUrl, DbType.String);
                parameters.Add("@siparisId", dto.siparisId, DbType.String); // Changed from DbType.DateTime2 to DbType.String
                parameters.Add("@tarih", dto.tarih, DbType.DateTime2);
                parameters.Add("@urunId", dto.urunId, DbType.Int64);
                using var connection = _context.CreateSqlConnection();
                var kullanici = connection.Execute("sp_SepetEkle", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<Sepet> gecmisSiparisler(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@useremail", email, DbType.String); 
            using var connection = _context.CreateSqlConnection();
            var sepet = connection.Query<Sepet>("sp_gecmisSiparisler", parameters, commandType: CommandType.StoredProcedure);
            return sepet;
        }

        public void sepetAdetDegistir(SepetAdetDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", dto.id, DbType.Int32); // Changed from DbType.Int64 to DbType.Int32
            parameters.Add("@urunAdet", dto.urunAdet, DbType.Int32); // Changed from DbType.Int64 to DbType.Int32
            parameters.Add("@toplamTutar", dto.toplamTutar, DbType.Decimal);
            using var connection = _context.CreateSqlConnection();
            var kullanici = connection.Execute("sp_SepetAdetDegistir", parameters, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Sepet> SepetList(indirimDTO dto)
        {
            try
            {
                using var connection = _context.CreateSqlConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@indKod ", dto.indKod, DbType.String);
                var sepet = connection.Query<Sepet>("sp_SepetList", parameters, commandType: CommandType.StoredProcedure);
                return sepet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void sepetOnayla(SepetOnaylaDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", dto.id, DbType.Int32); // Changed from DbType.Int64 to DbType.Int32
            parameters.Add("@siparisId", dto.siparisId, DbType.String); // Changed from DbType.Int64 to DbType.Int32
            parameters.Add("@useremail", dto.useremail, DbType.String);
            parameters.Add("@aktifmi", dto.aktifmi, DbType.Boolean);
            using var connection = _context.CreateSqlConnection();
            var kullanici = connection.Execute("sp_SepetOnayla", parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Sepet> siparisIdList(string siparisId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@siparisId", siparisId, DbType.String);
            using var connection = _context.CreateSqlConnection();
            var sepet = connection.Query<Sepet>("sp_siparisIddetay", parameters, commandType: CommandType.StoredProcedure);
            return sepet;
        }
    }
}
