using System.Text;

namespace BitirmePrjs.Helper
{
    public class RandomKeyHelper
    {
        private  readonly string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private  readonly int Length = 5;
        private  Random random = new Random();


        public  string randomKeyOlustur()
        {
            StringBuilder key = new StringBuilder(Length);
            for (int i = 0; i < Length; i++)
            {
                key.Append(Characters[random.Next(Characters.Length)]);
            }
            return key.ToString();
        }

    }
}
