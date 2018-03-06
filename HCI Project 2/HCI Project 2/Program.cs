// Daniel Hollo
// deh66@zips.uakron.edu
// Human Computer Interaction (HCI) Assignment 2
// 2/27/2018

using System;
using System.Threading;

namespace HCI_Project_2
{
    class Program
    {
        public static double pi = 3.14159265358979323846264338;
        public static bool StopComp = false;
        public static bool StopProgram = false;

        static void Main(string[] args)
        {
            Input input = new Input();
            Thread thread = new Thread(input.IOinput);
            thread.Start();
           
        }

        // Compute Function
        static public void Compute(object a)
        {
            double result = pi;
            int i = 0;
            bool Done = false;

            Output CompO = new Output();

            while (!StopComp && !Done)
            {
                CompO.OnOutput(i.ToString());

                if (i < (int)a)
                    result = Math.Sqrt(result);
                else
                    Done = true;

                i++;
            }

            StopComp = false;
            CompO.OnOutput("Computation Complete: ");
            CompO.OnOutput(result.ToString());
            CompO.OnOutput("Enter New Integer (or 'q' to quit): ");

        }

        // IO Event Delegate
        public delegate void IOeventEventHandler(object sender, IOEventArgs e);
        // IO Event Class
        public class IOEventArgs : EventArgs
        {
            private string Throughput = "";

            public IOEventArgs(string text)
            {
                this.Throughput = text;
            }

            public string IOstring
            {
                get { return Throughput; }
                set { this.Throughput = value; }
            }
        }

        // IO Class
        public class Input
        {
            // Public Function to take user input
            public void IOinput()
            {
                string i = "";
                int n = 0;
                bool breakout = false;


                Output InpO = new Output();

                while (!breakout)
                {

                    InpO.OnOutput("Input an integer: ");

                    i = "";
                    i = Console.ReadLine();
                    //Console.WriteLine($"[THREAD] i = {i}");

                    if (i == "q")
                    {
                        breakout = true;
                        StopComp = true;
                        StopProgram = true;
                    }
                    else if(i == "s")
                    {
                        StopComp = true;
                    }
                    else if (i != "")
                    {
                        //IOEventArgs e = new IOEventArgs(i);
                        //OnInput(e);

                        if(Int32.TryParse(i, out n))
                        {
                            Thread th = new Thread(Compute);
                            th.Start(n);
                        }
                        else
                        {
                            InpO.OnOutput("Invalid Input, Please Enter a Number: ");
                        }
                    }
                }
            }

            // Create Instance of IOevent handler object
            public event IOeventEventHandler In;

            // Input Event Handler
            protected virtual void OnInput(IOEventArgs e)
            {
                if (In != null)
                {
                    In(this, e);
                }

                if (e.IOstring == "s")
                {
                    StopComp = true;
                }
            }
        }

        // Output Class
        public class Output
        {
            // Create Instance of IOevent handler object
            public event IOeventEventHandler Out;

            public virtual void OnOutput(IOEventArgs e)
            {
                if (Out != null)
                {
                    Out(this, e);
                }
                Console.WriteLine(e.IOstring);
            }
            public virtual void OnOutput(string s)
            {
                Console.WriteLine(s);
            }
        }

    }
}
