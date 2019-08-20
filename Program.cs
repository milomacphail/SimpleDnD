using System;

namespace SimpleDnD
{
    class Dice
    {
        Random rand = new Random();
        int value;

        public Dice()
        {
            this.value = this.RollDice();
        }

        public int RollDice()
        {
            int dieResult = rand.Next(1, 20);

            if (dieResult == 1)
            {
                Console.WriteLine("A {0}! Critical miss!", dieResult);
            }
            else if (dieResult == 20)
            {
                Console.WriteLine("A Critical Hit!");
            }

            return dieResult;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Dice gameRoll = new Dice();
            Console.WriteLine(gameRoll.RollDice());
        }
    }
}
