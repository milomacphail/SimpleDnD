using System;

namespace SimpleDnD
{
    class Dice
    {
        Random rand = new Random();
        private int _value;
        public int dieResult;

        public Dice()
        {
            this._value = dieResult;
        }

        public int RollDice()
        {
            dieResult = rand.Next(1, 21);

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
        int modifier;
        public Modifier()
        {
            this._modifierValue = modifier;
        }

        public int EnterModifier()
        {
            Console.WriteLine("Dungeon Master, enter a modifier: ");
            modifier = Convert.ToInt32(Console.ReadLine());
            return modifier;
        }
    }

    
    class Enemy
    {
        private int  _hitPoints;
        int enemyHitPoints;

        public Enemy()
        {
            this._hitPoints = enemyHitPoints;
        }

    }

    class ArmorClass
    {
        private int _armorValue;
        public int targetArmor;

        public ArmorClass()
        {
            this._armorValue = targetArmor;
        }

        public int EnterArmorClass()
        {
            Console.WriteLine("Dungeon Master, enter enemy armor class: ");
            targetArmor = Convert.ToInt32(Console.ReadLine());
            return targetArmor;
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
            int modRoll = gameModifier.EnterModifier();
            int playerRoll = (hitResult + modRoll);
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
                int damageDone = damageRand.Next(1, sidedDice + 1);
                Console.WriteLine("{0} damage to enemy", damageDone);
                totalDamage += damageDone;

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

