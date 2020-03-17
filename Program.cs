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

        /// <summary>
        /// Called when the machine is empty and refills it
        /// </summary>
        /// <param name="sender">string which can be written out to the console</param>
        /// <param name="e"></param>
        private static void Instance_EmptyMachineEvent(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
            GumMachine.Instance.FillMachine();
        }
    }
}
