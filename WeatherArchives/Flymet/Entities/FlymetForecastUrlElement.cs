namespace Flymet
{
    public class FlymetForecastUrlElement
    {
        public FlymetForecastUrlElement(string id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
