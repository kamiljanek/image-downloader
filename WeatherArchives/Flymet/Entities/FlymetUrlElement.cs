namespace Flymet.Entities
{
    public class FlymetUrlElement
    {
        public FlymetUrlElement(string id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public string Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
    }
}
