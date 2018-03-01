
using System.Collections.Generic;

public interface IMyList : IList<string>
{
    void Add();
    void Remove();
    void Used();
}
