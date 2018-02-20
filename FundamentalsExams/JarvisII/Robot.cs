using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisII
{
    class Robot
    {
        public long Energy { get; set; }
        public Head RoboHead { get; set; }
        public Torso RoboTorso { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Leg> Legs { get; set; }

        public void AddHead(Head newHead)
        {
            if (newHead.EnergyConsumption < RoboHead.EnergyConsumption)
            {
                RoboHead = newHead;
            }
        }
        public void AddTorso(Torso newTorso)
        {
            if (newTorso.EnergyConsumption < RoboTorso.EnergyConsumption)
            {
                RoboTorso = newTorso;
            }
        }
        public void AddArm(Arm newArm)
        {
            if (Arms == null)
            {
                Arms = new List<Arm>();
            }
            if (Arms.Count < 2)
            {
                Arms.Add(newArm);
            }
            else
            {
                Arms = Arms.OrderBy(p => p.EnergyConsumption).ToList();
                for (int i = 0; i < Arms.Count; i++)
                {
                    if (Arms[i].EnergyConsumption < newArm.EnergyConsumption)
                    {
                        Arms[i] = newArm;
                        break;
                    }
                }
            }
        }
        public void AddLeg(Leg newLeg)
        {
            if (Legs == null)
            {
                Legs = new List<Leg>();
            }
            if (Legs.Count < 2)
            {
                Legs.Add(newLeg);
            }
            else
            {
                Legs = Legs.OrderBy(p => p.EnergyConsumption).ToList();
                for (int i = 0; i < Legs.Count; i++)
                {
                    if (Legs[i].EnergyConsumption < newLeg.EnergyConsumption)
                    {
                        Legs[i] = newLeg;
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            
            if (RoboHead == null || RoboTorso == null || Arms.Count < 2 || Legs.Count < 2)
            {
                return "We need more parts!";
            }            
            long TotalEnergy = 0L;
            TotalEnergy = RoboHead.EnergyConsumption + RoboTorso.EnergyConsumption;
            TotalEnergy += Arms.Select(p => p.EnergyConsumption).Sum();
            TotalEnergy += Legs.Select(p => p.EnergyConsumption).Sum();
            if (Energy < TotalEnergy)
            {
                return "We need more power!";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Jarvis:\n\r");
            sb.Append(RoboHead.ToString());
            sb.Append(RoboTorso.ToString());
            sb.Append(Arms[0].ToString());
            sb.Append(Arms[1].ToString());
            sb.Append(Legs[0].ToString());
            sb.Append(Legs[1].ToString());
            return sb.ToString();
        }

    }
}
