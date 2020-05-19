using System;
using System.Collections.Generic;

namespace Lab3finalraw
{
    public class HumanEventArgs : EventArgs
    {
        private double newBMI;

        public HumanEventArgs(double v)
        {
            newBMI = v;
        }

        public double NewBMI
        {
            get { return newBMI; }
        }
    }
}