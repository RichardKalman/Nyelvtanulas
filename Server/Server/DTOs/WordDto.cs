namespace Server.DTOs
{
    public class WordDto
    {
        public int id { get; set; }
        public string EnglishWord { get; set; }
        public string HungaryWord { get; set; }

        /*public override bool Equals(object obj)
        {
            return obj is WordDto dto &&
                   EnglishWord.ToLower() == dto.EnglishWord.ToLower() &&
                   HungaryWord.ToLower() == dto.HungaryWord.ToLower();
        }*/
    }
}
