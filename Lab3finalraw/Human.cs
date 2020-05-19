using System;
using System.Collections.Generic;

namespace Lab3finalraw
{
    class IntegerException : ArgumentException
    {
        public int Value { get; }

        public IntegerException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }

    class NameException : Exception
    {
        public string Value { get; }

        public NameException(string message, string val)
            : base(message)
        {
            Value = val;
        }
    }

    public abstract class Human
    {
        private string name;
        private int age;
        private DateTime dateOfBirth;

        protected double bmi;


        public Human()
        {
        }

        public Human(string name, int age, DateTime dateOfBirth)
        {
            try
            {
                this.Age = age;
            }
            catch (IntegerException e)
            {
                Console.WriteLine($"Age exception was caught, problem: {e.Message} with value : {e.Value}");
            }

            try
            {
                this.Name = name;
            }
            catch (NameException e)
            {
                Console.WriteLine($"Name exception was caught, problem: {e.Message} with value : {e.Value}");
            }

            Date = dateOfBirth;
        }

        public DateTime Date
        {
            set { dateOfBirth = value; }
            get { return dateOfBirth; }
        }


        public string Name
        {
            set
            {
                if (value == "" || value == " ")
                {
                    throw new NameException("Enter your name, please.", value);
                    //Console.WriteLine("Enter your name, please.");
                }
                else
                {
                    name = value;
                }
            }
            get { return name; }
        }

        public int Age
        {
            set
            {
                if (value < 0)
                {
                    throw new IntegerException("Should be positive !", value);
                    //Console.WriteLine("Should be positive !");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }


        public abstract void OutInfo();

        public virtual void Income()
        {
            Console.WriteLine("My income is :");
        }
        //Body mass index 

        public double Bmi
        {
            get { return bmi; }
            set { bmi = value; }
        }

        public event EventHandler<HumanEventArgs> BmiChanged;

        protected virtual void OnBMIChanged(HumanEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<HumanEventArgs> handler = BmiChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}