using System;

namespace SimpleDnD
{
    class Dice
    {
        Random rand = new Random();
        private int _value;

        public Dice()
        {
            this._value = this.RollDice();
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
                Console.WriteLine("{0}! A Critical Hit!", dieResult);
            }
            else
            {
                Console.WriteLine("You rolled a {0}. That's a hit!", dieResult );
            }
            return dieResult;
        }

    }

    class Modifier
    {
        private int _modifierValue;
        public Modifier()
        {
            this._modifierValue = this.EnterModifier();
        }

        public int EnterModifier()
        {
            Console.WriteLine("Dungeon Master, enter a modifier: ");
            int modifier = Convert.ToInt32(Console.ReadLine());
            return modifier;
        }
    }

    class ArmorClass
    {
        private int _armorValue;

        public ArmorClass()
        {
            this._armorValue = this.EnterArmorClass();
        }

        public int EnterArmorClass()
        {
            Console.WriteLine("Dungeon Master, enter enemy armor class: ");
            int ac = Convert.ToInt32(Console.ReadLine());
            return ac;
        }

    }

    class Hit
    {
        public bool IsHit()
        {
            bool isHit;
            Dice gameRoll = new Dice();
            int hitResult = gameRoll.RollDice();
            Console.WriteLine(hitResult);
            Modifier gameModifier = new Modifier();
            int playerRoll = (hitResult + gameModifier.EnterModifier());
            ArmorClass enemyArmor = new ArmorClass();
            int enemyGameArmor = enemyArmor.EnterArmorClass();

            if (enemyGameArmor > playerRoll)
            {
                isHit = true;
                Console.WriteLine("You hit the enemy!");
            }
            else
            {
                isHit = false;
                Console.WriteLine("You missed! Great effort.");
            }

            return isHit;
        }
    }

    class DamageDice : Hit
    {
        Random damageRand = new Random();
        int numberOfDice;
        int sidedDice;
        int totalDamage;
        public int DamageToEnemy()
        {
            Console.WriteLine("What dice are you using: ");
            string diceClass = Console.ReadLine();
            numberOfDice = Int32.Parse(diceClass.Substring(0, 1));
            sidedDice = Int32.Parse(diceClass.Substring(2, 1));

            for (int roll = 0; roll < numberOfDice; roll++)
            {
                int damageDone = damageRand.Next(1, sidedDice);
                Console.WriteLine("{0} damage to enemy", damageDone);
                totalDamage += damageDone;
                Console.WriteLine("Damage to enemy: {0}", totalDamage);

            }

            return totalDamage;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Hit attackEnemy = new Hit();
            attackEnemy.IsHit();
            DamageDice damageToEnemy = new DamageDice();
            damageToEnemy.DamageToEnemy();
        }
    }
}

