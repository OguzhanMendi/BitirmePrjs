namespace BitirmePrjs.Entities
{
    public class Kullanici
    {
        public int id { get; set; }

        public string email { get; set; }

        public string sifre { get; set; }

        public string? rol { get; private set; }

    }
}
