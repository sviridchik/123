using System;
namespace Lab3finalraw
{
    public class Unemploed : Student, IHuman, ICloneable
    {
      
        private Hobbies Hobbies { get; set; }
        private int yearsOfUnemploement;
        

        
        public int YearsOfUnemploement
        {
            set
            {
                if (value <= 0 || value >= Age)
                {
                    throw new IntegerException("Check info about YearsOfUnemploement!",value);
                }
                else
                {
                    yearsOfUnemploement = value;
                }
            }
            get { return yearsOfUnemploement; }
        }

        
        public Unemploed(string name, int age, int yearsOfUnemploement,float averageGrad, int @class,
            bool scholarship, string specialty,Hobbies hobby, DateTime date, double height, double weight)
            : base( name, age, averageGrad, @class, scholarship, specialty, hobby,date, height, weight)
        {
            try
            {
                YearsOfUnemploement = yearsOfUnemploement;
            }
            catch (IntegerException e)
            {
                Console.WriteLine($"YearsOfUnemployement exception was caught, problem: {e.Message} with value : {e.Value}");
            }
           
        }

        public override void OutInfo()
        {
            Console.WriteLine(
                $" name : {base.Name} , age: {Age} ,YearsOfUnemploement: {YearsOfUnemploement}");
            //Notify?.Invoke($" Unemployed information was requested about  {base.Name}");
        }
        
        public static bool operator <(Unemploed u1, Unemploed u2)
        {
            return u1.yearsOfUnemploement < u2.yearsOfUnemploement;
        }
       
        public static bool operator >(Unemploed u1, Unemploed u2)
        {
            return u1.yearsOfUnemploement < u2.yearsOfUnemploement;
        }
 
        public override void Income()
        {
            base.Income();
            Console.WriteLine("        *goverments help");
            Console.WriteLine("        *personal savings");
           
        }
 
        public new void OutPersonalInfo()
        {
         Console.WriteLine($"The uneployed {Name} has hobby {Hobby}");
        }

        delegate void MessageHandler(string message);

        static void ShowMessage(string mes, MessageHandler handler)
        {
            handler(mes);
        }
        
        delegate string DayDel(int day, int month);
        event DayDel HD;

        public new void  HappyBirthday(int day, int month)
        {
            string answer;
            DayDelImplement(null, null);
            answer = HD?.Invoke(day,month);
            
            ShowMessage(answer, delegate(string mes)
            {
                Console.WriteLine(mes);
            });
        }
        
        private void DayDelImplement(object sender, EventArgs e)
        {
            HD += delegate(int day, int month)
            {
                string answer;
                if (Date.Day == day && Date.Month == month)
                {
                    answer = "Happy Birthday";
                   
                }
                else
                {
                    int year = DateTime.Now.Year;
                    answer = $" {Name} you are {year - Date.Year} years old. May be it is time to find a job?! !";
                }

                return answer;
            };
            
        }
        
 

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}