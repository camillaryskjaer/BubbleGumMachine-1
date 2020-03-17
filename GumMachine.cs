using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace BubbleGumMachine
{
    //I'm not 100% sure whether or not my methods does too much, so please tell me if they do

    class GumMachine
    {
        bool isEmpty = false;
        Random rnd = new Random();
        public event EventHandler EmptyMachineEvent;
        List<int> gumLeftInMachine = new List<int>();

        private BubbleGum[] bubbleGums;

        public BubbleGum[] BubbleGums
        {
            get { return bubbleGums; }
            set { bubbleGums = value; }
        }

        //Singleton pattern
        private GumMachine()
        {

        }
        private static GumMachine instance = null;
        public static GumMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GumMachine();
                }
                return instance;
            }
        }

        //Fills the machine with bubblegum
        public void FillMachine()
        {
            BubbleGums = new BubbleGum[55];
            BalanceBubbleGumAmount();
            isEmpty = false;
        }

        /// <summary>
        /// Balances out the colors until it reaches machine max capacity
        /// </summary>
        /// There probably is a smarter way to do this
        private void BalanceBubbleGumAmount()
        {
            int counter = 0;
            //Green
            for (int i = 0; i < BubbleGums.Length * 0.10; i++)
            {
                BubbleGums[counter] = new BubbleGum(GumColor.GREEN);
                counter++;
            }
            //Blue
            for (int i = 0; i < BubbleGums.Length * 0.25; i++)
            {
                BubbleGums[counter] = new BubbleGum(GumColor.BLUE);
                counter++;
            }
            //Purple
            for (int i = 0; i < BubbleGums.Length * 0.12; i++)
            {
                BubbleGums[counter] = new BubbleGum(GumColor.PURPLE);
                counter++;
            }
            //Yellow
            for (int i = 0; i < BubbleGums.Length * 0.20; i++)
            {
                BubbleGums[counter] = new BubbleGum(GumColor.YELLOW);
                counter++;
            }
            //Orange
            for (int i = 0; i < BubbleGums.Length * 0.19; i++)
            {
                BubbleGums[counter] = new BubbleGum(GumColor.ORANGE);
                counter++;
            }
            //red
            for (int i = 0; i < BubbleGums.Length * 0.14; i++)
            {
                BubbleGums[counter] = new BubbleGum(GumColor.RED);
                if (counter == BubbleGums.Length - 1)
                    break;
                counter++;
            }

        }

        /// <summary>
        /// Gives a random gum depending on what gums are left in the machine( <see cref="gumLeftInMachine"/>)
        /// </summary>
        /// <returns>returns the bubblegum you got from the machine!</returns>
        public BubbleGum GiveBubbleGum()
        {
            if (isEmpty)
            {
                EmptyMachineEvent("The machine is now empty and needs to be refilled", new EventArgs());
            }

            gumLeftInMachine.Clear();

            for (int i = 0; i < BubbleGums.Length; i++)
            {
                if (BubbleGums[i] != null)
                {
                    gumLeftInMachine.Add(i);
                }
            }
            if (gumLeftInMachine.Count == 1)
            {
                isEmpty = true;
                return BubbleGums[gumLeftInMachine[0]];
            }

            //Saving the gum temporarely so we don't return a null
            int index = gumLeftInMachine[rnd.Next(0, gumLeftInMachine.Count)];
            BubbleGum gum = BubbleGums[index];
            BubbleGums[index] = null;
            return gum;
        }
    }
}
