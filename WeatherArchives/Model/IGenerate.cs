namespace Model
{
    public interface IGenerate
    {
        string Name { get; }
        string GenerateUrl();
        string GenerateFileName();
    }
}
