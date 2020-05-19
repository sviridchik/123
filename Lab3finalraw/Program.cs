using System;
using System.Collections.Generic;

namespace Lab3finalraw
{
    class Program
    {
        static void Main(string[] args)
        {
            Student feda = new Student("feda", 19, 9, 9, true,
                "cs", Hobbies.programming, new DateTime(2000, 05, 25),
                100, 1);
            Student tosha = new Student("tosha", 18, 10, 1, true,
                "cs", Hobbies.camping, new DateTime(2000, 05, 25), 198, 89);
            // Student alice = new Student("alice", -9, 10, 1, true, "cs", Hobbies.camping);

            tosha.Income();
            //tosha.Hobbies == Hobbies.camping;
            tosha["mma"] = new Deciplines("mma", 56, "ekzam");
            tosha["mma"] = new Deciplines("mgia", 80, "eksam");
            tosha["mma"] = new Deciplines("mma", 96, "zack");
            tosha["proga"] = new Deciplines("proga", 96, "zack");
            tosha.OutInfo();
            //tosha.HappyBirthday(29,5);
            tosha.OutPersonalInfo();
            Console.WriteLine(tosha["proga"].hours);
            Console.WriteLine("******************************************************************************");

            
            //(string name, int age,string _job,string _position,int _experience,Rank rank,Hobbies hobby, float _average_grad, int _class, bool scholarship, string specialty,Hobbies h)
            Worker sam = new Worker("samir", 28, "programmer", "dev", 6, Rank.senior,
                Hobbies.travelling, 9, 1, true, "asd", Hobbies.camping,
                new DateTime(2001, 01, 25), 175, 67);
            sam.OutInfo();
            sam.HappyBirthday(23, 5);
            Worker siar = new Worker("siar", 23, "programmer", "dev", 2, Rank.middle,
                Hobbies.music, 9, 1, true, "asd", Hobbies.camping,
                new DateTime(2001, 01, 25), 180, 56);
            Worker bysia = new Worker("bysia", 73, "doctor", "ych", 46, Rank.senior,
                Hobbies.reading, 9, 1, true, "asd", Hobbies.camping,
                new DateTime(1998, 03, 25), 123, 43);

            List<Worker> team = new List<Worker>();
            team.Add(sam);
            team.Add(siar);
            team.Add(bysia);
            Console.WriteLine("Initial working team: \n");
            foreach (Worker a in team)
                Console.WriteLine(a.Name);

            Console.WriteLine("\n:Sorted working team \n");
            team.Sort();
            foreach (Worker a in team)
                Console.WriteLine(a.Name);

            Console.WriteLine("******************************************************************************");

            Unemploed ulia = new Unemploed("Ulia", 19, 13, 9, 1,
                true, "info", Hobbies.reading, new DateTime(2002, 07, 25),
                145, 65);
            ulia.Income();
            Unemploed uliaClone = (Unemploed) ulia.Clone();
            ulia.OutInfo();
            ulia.OutPersonalInfo();
            uliaClone.OutInfo();
            ulia.HappyBirthday(12, 7);
            Console.WriteLine("******************************************************************************");
            CoolScholarshipMan daniel = new CoolScholarshipMan("daniel", 18, 9, 1,
                true, "info", Hobbies.camping, Coolness.VeryVeryCool, Subject.IT,
                new DateTime(2001, 10, 1), 167, 56);
            CoolScholarshipMan igor = new CoolScholarshipMan("igor", 18, 9, 1,
                true, "info", Hobbies.programming, Coolness.Normal, Subject.IT,
                new DateTime(2001, 9, 1), 189, 87);
            daniel.OutInfo();
            daniel.OutPersonalInfo();
            if (daniel.Equals(igor))
            {
                Console.WriteLine("You can work together");
            }
            else
            {
                Console.WriteLine("Find another partner");
            }

            igor.OutPersonalInfo();


            feda.HappyBirthday(25, 5);
            feda.Age = 67;
            feda.OutInfo();

            ControlGroupe gr = new ControlGroupe();
            gr.AddHuman(feda);
            gr.AddHuman(tosha);

            feda.Update(100, 45);


            Console.WriteLine(feda.Bmi);


            igor.HappyBirthday(2, 9);


            try
            {
                Student alice = new Student("alice", 9, 9, 1, true,
                    "cs", Hobbies.camping, new DateTime(2000, 05, 25), 100, 1);
                Worker asd = new Worker("siar", 23, "", "dev", 2, Rank.middle,
                    Hobbies.music, 9, 1, true, "asd", Hobbies.camping,
                    new DateTime(2001, 01, 25), 180, 56);


                Student gosha = new Student("gosha", -19, 9, 9, false,
                    "cs", Hobbies.programming, new DateTime(2000, 05, 25),
                    100, 1);
                gosha.Income();


                ulia.Income();

                Student.Koeff(10);
            }
            catch (IntegerException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

