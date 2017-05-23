using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Drobot.Nsudotnet.NumberGuesser
{
    class Program
    {
        private static int maxValue = 100;
        private static Random rand = new Random();
        private static String userName;
        private static int secretValue;
        private static int userValue;
        private static int step = 1;
        private static String[] history = new String[1000];
        private static String line;

        private static String[] forLoserMessages =
            {
                "{0} в тебе нет совершенства мысли и высоты полета сознания.",
                "{0}, умная мартышка решает эту задачу с 4 раза - смекаешь?",
                "Британские ученые утверждают, что 90% людей - идиоты. Но ты ведь не такой, правда, {0}?",
                "{0}, и тебя вылечат...", 
                "{0}, борьба без устали и пощады - это замечательно. Но лучше пойди и съешь бананчик.",
                "{0}, ты не оправдываешь моих высоких(нет) надежд."
            };


        static void Main(String[] args)
        {

            Console.WriteLine("Введите ваше имя:");
            userName = Console.ReadLine();

            secretValue = rand.Next(maxValue);

            Stopwatch time = new Stopwatch();
            time.Start();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Пришло время сделать выбор. Твое число...?", userName);
                line = Console.ReadLine();
                if (line.Equals("q"))
                {
                    Console.WriteLine("Сам ты дурацкая игра!");
                    Console.WriteLine("И ты, это, извини, если что");
                    break;
                }
                userValue = int.Parse(line);

                if (userValue == secretValue)
                {
                    time.Stop();
                    history[step] = (String.Format("{0} : Правильный ответ!", userValue));
                    Console.WriteLine("И это правильный ответ!");
                    Console.WriteLine("");
                    Console.WriteLine("{0}, ты справился с задачей! Большой путь саморазвития всегда начинается с малых шагов, но не пора ли заняться чем-то более полезным?", userName);
                    Console.WriteLine("");
                    Console.WriteLine("Число попыток : {0}", step);
                    Console.WriteLine("История твоей игры");
                    for (int i = 1; i <= step; i++)
                    {
                        Console.WriteLine(history[i]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Время твоей игры: {0} минут {1} сек", time.Elapsed.Minutes, time.Elapsed.Seconds);
                    break;

                }
                else if (userValue < secretValue)
                {
                    WriteComment("меньше");
                }
                else if (userValue > secretValue)
                {
                    WriteComment("больше");
                }


                step++;
                if (step >= 1000)
                {
                    Console.WriteLine("У меня не осталось печатных слов и желания играть с тобой. Уходи");
                    break;
                }

            }

            Console.ReadKey(false);
        }


        static void WriteComment(String s)
        {

            history[step] = (String.Format("{0} : Число {1} загаданного", userValue, s));
            if (step % 4 == 0)
            {
                Console.WriteLine(String.Format(forLoserMessages[rand.Next(6)], userName));
                Console.WriteLine("И да, твое число {0} загаданного.", s);
            }
            else
            {
                Console.WriteLine("Твое число {0} загаданного. Попробуй еще раз", s);
            }
        }
    }
}
