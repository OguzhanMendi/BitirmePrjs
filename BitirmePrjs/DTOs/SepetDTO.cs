namespace BitirmePrjs.DTOs
{
    public class SepetDTO
    {
        public string urunAd { get; set; }
        public int urunAdet { get; set; }
        public int urunFiyat { get; set; }
        public decimal toplamTutar { get; set; }
        public string imgUrl { get; set; }
        public string siparisId { get; set; }
        public DateTime tarih { get; set; } // Ensure this is DateTime
        public int urunId { get; set; } // Ensure this is DateTime
    }
}
