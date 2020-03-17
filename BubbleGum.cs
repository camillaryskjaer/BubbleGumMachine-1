using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleGumMachine
{
    public enum GumColor
    {
        RED,
        BLUE,
        PURPLE,
        YELLOW,
        ORANGE,
        GREEN
    }

    class BubbleGum
    {
        private GumColor color;

        public GumColor Color
        {
            get { return color; }
            set { color = value; }
        }

        private string name;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Name corresponds to what color it has.
        /// </summary>
        /// <param name="color"></param>
        public BubbleGum(GumColor color)
        { 
            Color = color;
            switch (Color)
            {
                case GumColor.RED:
                    name = "Strawberry";
                    break;
                case GumColor.BLUE:
                    name = "Blue berry";
                    break;
                case GumColor.PURPLE:
                    name = "Raspberry";
                    break;
                case GumColor.YELLOW:
                    name = "Tutti frutti";
                    break;
                case GumColor.ORANGE:
                    name = "Orange";
                    break;
                case GumColor.GREEN:
                    name = "Apple";
                    break;
                default:
                    name = "New Gum";
                    break;
            }
        }
    }
}
