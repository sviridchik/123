using System;

namespace Lab3finalraw
{
    public class SpecialtyException : Exception
    {
        public string Value { get; }

        public SpecialtyException(string message, string val)
            : base(message)
        {
            Value = val;
        }
    }

    public class WeightException : ArgumentException
    {
        public double Value { get; }

        public WeightException(string message, double val)
            : base(message)
        {
            Value = val;
        }
    }
}