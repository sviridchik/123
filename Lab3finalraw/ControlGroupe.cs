using System;
using System.Collections.Generic;

namespace Lab3finalraw
{
    public class ControlGroupe
    {
        List<Human> list;

        public ControlGroupe()
        {
            list = new List<Human>();
        }

        public void AddHuman(Human s)
        {
            list.Add(s);
            s.BmiChanged += HandleBMIChanged;
        }


        private void HandleBMIChanged(object sender, HumanEventArgs e)
        {
            Human s = (Human) sender;
            Console.WriteLine($"Received event. Human's BMI is now {e.NewBMI}");
        }
    }
}