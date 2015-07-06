using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StructuresAndLINQ
{
    class Program
    {
        #region Questions
        
        static List<Question> _questions = new List<Question>
        {
            new Question
            {
                QustionCategory = Category.Net,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.Net,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.JS,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.JS,
                QustionText = ""
            },  
            new Question
            {
                QustionCategory = Category.PHP,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.PHP,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.OOP,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.OOP,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.DB,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.DB,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.English,
                QustionText = ""
            },
            new Question
            {
                QustionCategory = Category.English,
                QustionText = ""
            }

        }; 
        
        #endregion

        #region Tests

        private static List<Test> _tests = new List<Test>
        {
            new Test
            {
                TestName = "BSA NET",
                TestCategory = Category.Net,
                MaxTime = 25,
                passingScore = 4.5,
                QuestionList = _questions.Where(q=>q.QustionCategory==Category.Net).ToList()
            },
            new Test
            {
                TestName   = "BSA JS",
                TestCategory = Category.JS,
                MaxTime = 25,
                passingScore = 4.5,
                QuestionList = _questions.Where(q=>q.QustionCategory==Category.JS).ToList()
            },
            new Test
            {
                TestName = "BSA PHP",
                TestCategory = Category.PHP,
                MaxTime = 27,
                passingScore = 4.3,
                QuestionList = _questions.Where(q=>q.QustionCategory==Category.PHP).ToList()
            },
            new Test
            {
                TestName = "BSA OOP",
                TestCategory = Category.OOP,
                MaxTime = 15,
                passingScore = 4.3,
                QuestionList = _questions.Where(q=>q.QustionCategory==Category.OOP).ToList()
            }
        };

        #endregion
        
        #region Users

        private static List<User> _users = new List<User>
        {
            new User
            {
                UserName = "Олег",
                Age = 29,
                Email = "oleg@mail.ru",
                City = "Харьков",
                University = "НТУ ХПИ",
                UserCategory = Category.Net
            },
            new User
            {
                UserName = "Петр",
                Age = 35,
                Email = "petr@mail.com",
                City = "Киев",
                University = "КПИ",
                UserCategory = Category.Net
            },
            new User
            {
                UserName = "Евгений",
                Age = 20,
                Email = "evgen@mail.com",
                City = "Львов",
                University = "Националный университет",
                UserCategory = Category.JS
            },
            new User
            {
                UserName = "Вова",
                Age = 21,
                Email = "vova@mail.com",
                City = "Львов",
                University = "Националный университет",
                UserCategory = Category.JS
            },
            new User
            {
                UserName = "Егор",
                Age = 21,
                Email = "egor@mail.com",
                City = "Киев",
                University = "КПИ",
                UserCategory = Category.PHP
            },
            new User
            {
                UserName = "Елена",
                Age = 23,
                Email = "lena@mail.com",
                City = "Харько",
                University = "ХНУРЭ",
                UserCategory = Category.OOP
            },
            new User
            {
                UserName   = "Сергей",
                Age = 22,
                Email = "serg@mail.com",
                City = "Киев",
                University = "КПИ",
                UserCategory = Category.JS
            }
        };

        #endregion
        
        #region Test Works

        private static List<TestWork> _testWorks = new List<TestWork>
        {
            new TestWork
            {
                Test = _tests.FirstOrDefault(test => test.TestCategory == Category.Net),
                User = _users.FirstOrDefault(user => user.UserName == "Олег"),
                Mark = 4.7,
                Time = 23
            },
            new TestWork
            {
                Test = _tests.FirstOrDefault(test => test.TestCategory == Category.Net),
                User = _users.FirstOrDefault(user => user.UserName == "Петр"),
                Mark = 5,
                Time = 20
            },
            new TestWork
            {
                Test = _tests.FirstOrDefault(test => test.TestCategory == Category.JS),
                User = _users.FirstOrDefault(user => user.UserName == "Евгений"),
                Mark = 4.5,
                Time = 40
            },
            new TestWork
            {
                Test = _tests.FirstOrDefault(test => test.TestCategory == Category.PHP),
                User = _users.FirstOrDefault(user => user.UserName == "Егор"),
                Mark = 3.4,
                Time = 25
            },
            new TestWork
            {
                Test = _tests.FirstOrDefault(test=>test.TestCategory==Category.JS),
                User = _users.FirstOrDefault(user=>user.UserName=="Сергей"),
                Mark = 4,
                Time = 25
            },
            new TestWork
            {
                Test = _tests.FirstOrDefault(test=>test.TestCategory==Category.OOP),
                User = _users.FirstOrDefault(user=>user.UserName=="Елена"),
                Mark = 3.7,
                Time = 23
            }
        };

        #endregion
        
        static void Main(string[] args)
        {
            Console.WriteLine("Список людей, которые прошли тесты.");
            var userlist = _testWorks.Select(tw => tw.User);

            #region Printin to console

            foreach (var user in userlist)
            {
                Console.WriteLine(user.UserName);
            }

            #endregion


            Console.WriteLine("\nСписок тех, кто прошли тесты успешно и уложилися во время.");
            var userSuccessPass = _testWorks
                .Where(tw => tw.Mark >= tw.Test.passingScore && tw.Time<=tw.Test.MaxTime)
                .Select(tw => tw.User);

            #region Printin to console

            foreach (var user in userSuccessPass)
            {
                Console.WriteLine(user.UserName);
            }

            #endregion


            Console.WriteLine("\nСписок людей, которые прошли тесты успешно и не уложились во время");
            var userLate = _testWorks
                .Where(tw => tw.Mark >= tw.Test.passingScore && tw.Time > tw.Test.MaxTime)
                .Select(tw => tw.User);

            #region Printin to console

            foreach (var user in userLate)
            {
                Console.WriteLine(user.UserName);
            }

            #endregion


            Console.WriteLine("\nСписок студентов по городам. (Из Львова: 10 студентов, из Киева: 20)");
            var userByCities = _users
                .Where(u => u.City.Equals("Львов"))
                .Take(10)
                .Union(_users.Where(u=>u.City.Equals("Киев"))
                .Take(20))
                .OrderBy(user=>user.City);

            #region Prnting to console

            foreach (var user in userByCities)
            {
                Console.WriteLine(user.City + ": " + user.UserName);
            }

            #endregion

            Console.WriteLine("\nСписок успешных студентов по городам.");
            var userSuccessPassOrderedByCity = _testWorks
                .Where(tw => tw.Mark >= tw.Test.passingScore && tw.Time <= tw.Test.MaxTime)
                .OrderBy(tw=>tw.User.City)
                .Select(tw => tw.User);

            #region Printin to console

            foreach (var user in userSuccessPassOrderedByCity)
            {
                Console.WriteLine(user.City + ": " + user.UserName);
            }

            #endregion

            
            Console.WriteLine("\nРезультат для каждого студента - его баллы, время, баллы в процентах для каждой категории.");

            var formateResults =
                _testWorks.Select(
                    tw => new {Name = tw.User.UserName, Mark = tw.Mark, Time = tw.Time, MarcProc = 100/5*tw.Mark});

            #region Printin to console

            foreach (var item in formateResults)
            {
                Console.WriteLine(item);
            }

            #endregion


            Console.ReadLine();
        }

    }
}
