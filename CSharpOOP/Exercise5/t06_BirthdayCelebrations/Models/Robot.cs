using System;
using System.Collections.Generic;
using System.Text;


public class Robot : IPopulation
{
    private string id;
    private string model;

    public Robot(string id, string model)
    {
        Id = id;
        Model = model;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

}
