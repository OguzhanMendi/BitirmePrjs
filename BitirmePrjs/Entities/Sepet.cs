namespace BitirmePrjs.Entities
{
    public class Sepet
    {
        public int id { get; set; }
        public string urunAd { get; set; }
        public int urunAdet { get; set; }
        public string siparisId { get; set; }

        public decimal toplamTutar { get; set; }
        public DateTime tarih { get; set; }

        public string imgUrl { get; set; }

        public int urunId { get; set; }


        public int urunFiyat { get; set; }

    }
}
