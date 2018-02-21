using System;
using System.Collections.Generic;
using System.Text;


public class Master
{
    public string Name { get; set; }
    public int MinionId { get; set; }
    public Master(string name, int minionId)
    {
        this.Name = name;
        this.MinionId = minionId;
    }
}
