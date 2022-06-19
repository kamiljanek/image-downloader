using System;

namespace Helper
{
    public interface IGenerate
    {
        string Name { get; }
        string GenerateUrl();
        string GenerateFileName();
    }
}
