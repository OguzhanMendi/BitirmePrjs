namespace BitirmePrjs.DTOs
{
    public class UrunDTO
    {
        public int id { get; set; }
        public string urunAd { get; set; }
        public string urunAciklama { get; set; }
        public string urunMarka { get; set; }
        public string urunKategori { get; set; }
        public string urunozellik { get; set; }
        public int urunAdet { get; set; }
        public int urunFiyat { get; set; }
        public int urunKdv { get; set; }
        public string imgUrl { get; set; }
        public IFormFile? image { get; set; }

        public bool aktif { get; set; }
    }
}
