using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK_Roller_2021
{
    public class Dice
    {
        private int currentRoll = 0;
        private guildEnum guild;
        private int dieValue;
        private string name;
        public bool saved = false;
        private Random rnd = new Random();

        public Dice(int val, guildEnum gul, string str)
        {
            dieValue = val;
            guild = gul;
            name = str;
        }

        public Dice(int val, guildEnum gul)
        {
            dieValue = val;
            guild = gul;
        }

        public int roll()
        {
            if (!saved)
            {
                currentRoll = rnd.Next(1, dieValue + 1);
            }
            return currentRoll;
        }

        public void toggleSave()
        {
            saved = !saved;
        }

        public string getName()
        {
            return name;
        }

        public guildEnum getGuild()
        {
            return guild;
        }

        public int getDieValue()
        {
            return dieValue;
        }

        public int getCurrentRoll()
        {
            return currentRoll;
        }

        ~Dice()
        {

        }


    }
}
