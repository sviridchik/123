using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3finalraw
{
    class StringException : Exception
    {
        public string Value { get; }

        public StringException(string message, string val)
            : base(message)
        {
            Value = val;
        }
    }

    enum Rank
    {
        junior = 1,
        middle,
        senior
    }

    class Worker : Student, IHuman, IComparable<Worker>
    {
        private Hobbies Hobbies { get;  set; }
        private Rank Rank { get;  set; }

        private Rank rank;
        private string _job;
        private string _position;
        private int _experience;
        public Hobbies hobby;
        static string[] divination = {"cool", "productive", "happy", "interesting", "amazing"};

        public Worker(string name, int age, string _job, string _position, int _experience, Rank rank, Hobbies hobby,
            float _average_grad, int _class, bool scholarship, string specialty, Hobbies h, DateTime date,
            double height,
            double weight) : base(name, age, _average_grad, _class, scholarship, specialty, h, date, height, weight)
        {
            try
            {
                Job = _job;
                Position = _position;
            }
            catch (StringException e)
            {
                if (e.Value == "" || e.Value == " ")
                {
                    Console.WriteLine($"JobOrPositionGradeException: {e.Message} , value: empty");
                }
                else
                {
                    Console.WriteLine($"JobOrPositionGradeException: {e.Message} , value: {e.Value}");
                }
            }

            try
            {
                Experience = _experience;
            }
            catch (IntegerException e)
            {
                Console.WriteLine($"ExperienceGradeException: {e.Message} , value: {e.Value}");
            }

         
        }


        private string Job
        {
            set
            {
                int i = 0;
                if (value == "" || value == " ")
                {
                    throw new StringException("Invalid data job!", value);
                }

                while (i < value.Length)
                {
                    if ((value[i] < 'a' || value[i] > 'z') && (value[i] < 'A' || value[i] > 'Z'))
                    {
                        throw new StringException("Invalid data job!", value);
                      
                    }

                    i++;
                }

                _job = value;
            }
            get { return _job; }
        }

        private string Position
        {
            set
            {
                if (value == "" || value == " ")
                {
                    throw new StringException("Invalid data position!", value);
                }

                int i = 0;
                while (i < value.Length)
                {
                    if ((value[i] < 'a' || value[i] > 'z') && (value[i] < 'A' || value[i] > 'Z'))
                    {
                        throw new StringException("Invalid data position!", value);
                     
                    }

                    i++;
                }

                _position = value;
            }
            get { return _position; }
        }

        private int Experience
        {
            set
            {
                if (value < 0 || value > this.Age)
                {
                    throw new IntegerException("Invalid data experience!", value);
                   
                }

                _experience = value;
            }
            get { return _experience; }
        }

        //polymorfism
        public override void OutInfo()
        {
            Console.WriteLine(
                $"This human {Name} is working in job : {_job} , in position: {_position} , for {_experience} years");
        }

        public override void Income()
        {
            base.Income();
            Console.WriteLine("        *Salary");
        }


        public void OutPersonalInfo()
        {
            Console.WriteLine($"This worker {Name} has hobby {Hobbies}");
        }


        public new void HappyBirthday(int day, int month)
        {
            if (Date.Day == day && Date.Month == month)
            {
                Console.WriteLine("Happy Birthday");
            }
            else
            {
                Random rnd = new Random();
                int index = rnd.Next(0, 5);
                Console.WriteLine($"Tomorrow {Name} will have a(an) {divination[index]} day !");
            }
        }

        public int CompareTo(Worker other)
        {
            if (this != null && other != null)
            {
                if (this.Experience > other.Experience)
                    return 1;
                else if (this.Experience < other.Experience)
                    return -1;
                else
                    return 0;
            }
            else
            {
                Console.WriteLine("Can't compare!");
                return -9;
            }
        }
    }
}