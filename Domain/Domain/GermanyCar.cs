namespace Domain.Domain
{
    public class GermanyCar : Car
    {
        //public GermanyCar(string make) : base(make)
        //{
        public GermanyCar(string name, int engineVol, int tankVol, string bodyType)
            : base(name, engineVol, tankVol, bodyType)
        {
        }
    }
}