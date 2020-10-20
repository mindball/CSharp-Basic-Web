using System;

namespace Chronometer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (string.Equals("start", input))
            {
                IChronometer chr = new Chronometer();
                chr.Start();

                while (true)
                {
                    input = Console.ReadLine();
                    if (string.Equals("exit", input))
                    {
                        chr.Stop();
                        break;
                    }

                    switch (input)
                    {
                        case "start": chr.Start();
                            break;

                        case "lap":
                            Console.WriteLine(chr.Lap());
                            break;
                        case "laps":
                            Console.WriteLine("Laps:");
                            foreach (var lap in chr.Laps)
                            {
                                Console.WriteLine(lap);
                            }
                            break;
                        case "stop": chr.Stop();
                            break;
                        case "time":
                            Console.WriteLine(chr.GetTime);
                            break;
                        case "reset": chr.Reset();
                            break;                       
                    }

                    ;
                }
            }


        }
    }
}
