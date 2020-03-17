using System;

namespace BubbleGumMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            GumMachine.Instance.EmptyMachineEvent += Instance_EmptyMachineEvent;
            GumMachine.Instance.FillMachine();


            while (true)
            {
                Console.WriteLine("Ooh, piece of candy: " + GumMachine.Instance.GiveBubbleGum().Name);
            }
        }

        private static void Instance_EmptyMachineEvent(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());

            GumMachine.Instance.FillMachine();
        }
    }
}
