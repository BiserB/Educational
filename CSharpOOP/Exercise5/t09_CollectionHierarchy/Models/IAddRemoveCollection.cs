
using System.Collections.Generic;

public interface IAddRemoveCollection : IList<string>
{
    void Add();
    void Remove();
}
