using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3finalraw
{
    public enum Subject
    {
        IT = 1,
        STEAM,
        Sport
    }


    public enum Coolness
    {
        Normal = 1,
        Cool,
        VeryVeryCool
    }

    public class CoolScholarshipMan : Student, IHuman, IEquatable<CoolScholarshipMan>
    {
        public Hobbies Hobbies { get; private set; }

        private Subject subj;
        private Hobbies hobby;
        private Coolness degreeOfCoolness;


        public CoolScholarshipMan(string name, int age, float averageGrad, int @class, bool scholarship,
            string specialty, Hobbies h, Coolness degreeOfCoolness, Subject subj, DateTime date, double height,
            double weight) : base(name, age,
            averageGrad, @class, scholarship, specialty, h, date, height, weight)
        {
            Subect = subj;
            Cool = degreeOfCoolness;
        }

        public override void OutInfo()
        {
            Console.WriteLine(
                $" name : {Name} , age: {Age} , Subject: {subj}");
        }

        public Subject Subect
        {
            set { subj = value; }
            get { return subj; }
        }

        public Coolness Cool
        {
            set { degreeOfCoolness = value; }
            get { return degreeOfCoolness; }
        }

        public static bool operator <(CoolScholarshipMan u1, CoolScholarshipMan u2)
        {
            return u1.degreeOfCoolness < u2.degreeOfCoolness;
        }

        public static bool operator >(CoolScholarshipMan u1, CoolScholarshipMan u2)
        {
            return u1.degreeOfCoolness < u2.degreeOfCoolness;
        }

        public override void Income()
        {
            base.Income();
            Console.WriteLine("        *Very cool scholarship");
        }

        public void OutPersonalInfo()
        {
            Console.WriteLine($"The very cool man {Name} has hobby {Hobby}");
        }
        delegate void ShowMessage(string mes);

        event ShowMessage Show;

        public new void HappyBirthday(int day, int month)
        {
            ShowMessageImplement(null, null);
            string answer;
            if (Date.Day == day && Date.Month == month)
            {
                answer = "Happy Birthday";
            }
            else
            {
                answer = "One more amazing day in your life! Congratulations! " + "\n" +
                         "Wait a second! One more interesting fact:  " + "\n";
                
                int res = base.IsLeapYear(Date.Year);
                if (res == 1)
                {
                    answer += "You were born in a leap year ! \n";
                }
                else
                {
                    answer += "You were not born in a leap year ! \n";
                }

                answer += $"You are awesome anyway, bye {Name} !";
            }

            Show(answer);
        }

        private void ShowMessageImplement(object sender, EventArgs e)
        {
            Show = (mes) => { Console.WriteLine(mes); };
        }

        public bool Equals(CoolScholarshipMan other)
        {
            if ((int) this.degreeOfCoolness == (int) other.degreeOfCoolness)
            {
                Console.WriteLine($"You {this.Name} and you {other.Name}, are both very cool. Congratulations!");
                return true;
            }
            else
            {
                Console.WriteLine($"Ops!");
                return false;
            }
        }
    }
}