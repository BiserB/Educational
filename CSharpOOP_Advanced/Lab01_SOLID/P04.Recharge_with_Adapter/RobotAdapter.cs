﻿using System;
using System.Collections.Generic;
using System.Text;


public class RobotAdapter : IRechargeable
{
    private Robot robot;

    public RobotAdapter(string id, int capacity)
    {
        this.robot = new Robot(id, capacity);
    }
    

    public void Recharge()
    {
        this.robot.Recharge();
    }
}
