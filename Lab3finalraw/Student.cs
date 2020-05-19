using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace Lab3finalraw
{
    public class Student : Human, IHuman
    {
       
        List<Deciplines> deciplines = new List<Deciplines>();

        private float averageGrade;
        private int @class;
        private bool scholarship;
        private string specialty;

        private int[] journal = new int[10];
        private Hobbies hobby;
        private double height;
        private double weight;

        public string Specialty
        {
            set
            {
                if (specialty == "" || specialty == " ")
                {
                    throw new SpecialtyException("Check info about your studying year", value);
                }

                specialty = value;
            }
            get => specialty;
        }

        public Hobbies Hobby
        {
            get => hobby;
            set => hobby = value;
        }

        private int Class
        {
            set
            {
                if (value <= 0)
                {
                    throw new IntegerException("Check info about your studying year!", value);
                }
                else
                {
                    @class = value;
                }
            }
            get { return @class; }
        }

        public double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new WeightException("Should be positive height!", value);
                }
                else
                {
                    height = value;
                }
            }
            get { return height; }
        }

        public double Weight
        {
            set
            {
                if (value <= 0)
                {
                    throw new WeightException("Should be positive weight!", value);
                }
                else
                {
                    weight = value;
                }
            }
            get { return weight; }
        }

        private float AverageGrade
        {
            set
            {
                if (value <= 0 || value > 11)
                {
                    throw new WeightException("Check info about student's average grade!", value);
                }
                else
                {
                    averageGrade = value;
                }
            }
            get { return averageGrade; }
        }

        private int IsIn(string elem)
        {
            int ii = -1;
            for (int i = 0; i < deciplines.Count; i++)
            {
                if (deciplines[i].nameOfDecipline == elem)
                {
                    ii = i;
                    break;
                }
            }

            return ii;
        }


        public Deciplines this[string decip]
        {
            get
            {
                int ii = IsIn(decip);
                return deciplines[ii];
            }

            set
            {
                int ii = IsIn(decip);

                if (ii == -1)
                {
                    deciplines.Add(value);
                }
                else
                {
                    deciplines.RemoveAt(ii);
                    deciplines.Insert(ii, value);
                }
            }
        }

        public int this[int index]
        {
            get
            {
                if ((index > 0) && (index < 11)) return journal[index - 1];
                else
                {
                    Console.WriteLine("Journal error");
                    return 0;
                }
            }

            set
            {
                if (((index > 0) && (index < 11)) && (value < 11 && value >= 0))
                    journal[index - 1] = value;
            }
        }


        public Student(string name, int age, float averageGrad, int @class, bool scholarship, string specialty,
            Hobbies h, DateTime date, double height, double weight
            /*params Deciplines[] deciplines*/) : base(name: name, age: age, date)
        {
            try
            {
                AverageGrade = averageGrad;
            }
            catch (WeightException e)
            {
                Console.WriteLine($"AverageGradeException: {e.Message} , value: {e.Value}");
            }

            this.scholarship = scholarship;
            try
            {
                Specialty = specialty;
            }
            catch (SpecialtyException e)
            {
                Console.WriteLine($"SpecialtyException: {e.Message} , value: {e.Value}");
            }

            try
            {
                Class = @class;
            }
            catch (IntegerException e)
            {
                Console.WriteLine($"ClassException: {e.Message} , value: {e.Value}");
            }

            this.hobby = h;
            try
            {
                Height = height;
                Weight = weight;
            }
            catch (WeightException e)
            {
                Console.WriteLine($"SpecialtyException: {e.Message} , value: {e.Value}");
            }

            Bmi = Weight / (Height * Height);
        }
     

        public void Update(double h, double w)
        {
            Height = h;
            Weight = w;
            bmi = weight / (height * height);
            OnBMIChanged(new HumanEventArgs(bmi));
        }

        protected override void OnBMIChanged(HumanEventArgs e)
        {
            base.OnBMIChanged(e);
        }

        public override void OutInfo()
        {
            Console.WriteLine(
                $" name : {base.Name} , age: {Age} ,average grad:  {AverageGrade},class:  {Class},scholarship:  {true},specialty:  {specialty}");
        }

        public void OutPersonalInfo()
        {
            Console.WriteLine($"Thi student {Name} has hobby {this.hobby}");
        }

        public static void Koeff()
        {
            Console.WriteLine("You have not passed a exams yet! your multiplying factor is 1");
        }

        public static void Koeff(float ball)
        {
            if (ball < 0)
            {
                Console.WriteLine("Invalid data!");
                return;
            }
            else
            {
                double res = 0;
                if (ball >= 9 && ball <= 10)
                {
                    res = 1.8;
                }
                else if (ball >= 8 && ball < 9)
                {
                    res = 1.1;
                }
                else if (ball > 4 && ball < 8)
                {
                    res = 1;
                }
                else if (ball >= 0 && ball <= 4)
                {
                    res = 0;
                }

                Console.WriteLine($"If you get {ball}, multiplying factor will be {res}");
            }
        }

//overload

        public static bool operator <(Student s1, Student s2)
        {
            return s1.averageGrade < s2.averageGrade;
        }

        public static bool operator >(Student s1, Student s2)
        {
            return s1.averageGrade > s2.averageGrade;
        }

        public override void Income()
        {
            base.Income();
            if (this.scholarship is true)
            {
                Console.WriteLine("        *Scolarship ");
            }

            Console.WriteLine("        *Parents' money");
        }

        public int IsLeapYear(int year)
        {
            if (year % 4 == 9 && year % 10 != 0 || year % 400 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static void IsLeapYear(int year, DelOut callback)
        {
            if (year % 4 == 9 && year % 10 != 0 || year % 400 == 0)
            {
                callback(1);
            }
            else
            {
                callback(0);
            }
        }

        public delegate void Del();

        public delegate void DelOut(int res);

        private DelOut handler = Leap;
        private Del call;

        private static void Cogratulation()
        {
            Console.WriteLine("Happy Birthday");
        }

        private static void AdvertisingInfo()
        {
            Console.WriteLine("One more amazing day in your life! Congratulations! ");
            Console.WriteLine("Wait a second! One more interesting fact:  ");
        }

        private static void Leap(int res)
        {
            if (res == 1)
            {
                Console.WriteLine("You were born in a leap year , did you know that?!");
            }
            else
            {
                Console.WriteLine("You were not born in a leap year , did you know that?!");
            }
        }

        public void HappyBirthday(int day, int month)
        {
            if (Date.Day == day && Date.Month == month)
            {
                call = Cogratulation;
            }
            else
            {
                call = AdvertisingInfo;
            }

            call();
            IsLeapYear(Date.Year, handler);
        }
    }
}