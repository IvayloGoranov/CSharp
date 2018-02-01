using System.Collections.Generic;

namespace Buhtig.Interfaces
{
    public interface IEndpoint
    {
        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
