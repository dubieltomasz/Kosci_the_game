using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Kości__gra_.Game
{
    public enum Category
    {
        Aces,
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes,
        ThreeOfAKind,
        FourOfAKind,
        FullHouse,
        SmallStraight,
        LargeStraight,
        Yahtzee,
        Chance
    }

    public enum Dice
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six
    }

    public enum Action
    {
        Join,
        Roll,
        ChooseCategory,
        Quit
    }

    public class Game
    {
        const int maxRolls = 3;
        const int bonusPoints = 35;

        public int players;
        private int currentPlayer = 0;
        public int[,] scoreArray = new int[4, 2];
        public Dice[,] dice = new Dice[4, 5];
        public bool[,] categories = new bool[4, Enum.GetNames(typeof(Category)).Length];
        public Random random = new Random();
        public int turnsLeft;
        public int[] rolls = [0, 0, 0, 0];

        public Game(int players)
        {
            this.players = players;
            turnsLeft = Enum.GetNames(typeof(Category)).Length * players;

            for (int i = 0; i < 4; ++i)
            {
                for(int j = 0; j < Enum.GetNames(typeof(Category)).Length; ++j)
                {
                    categories[i, j] = false;
                }
            }
        }

        public string[] ShowScore()
        {
            string[] result = ["", "", "", ""];

            for(int i = 0; i < players; ++i)
            {
                result[i] += "Player " + i + ": " + (scoreArray[i, 0] + scoreArray[i, 1]) + "\n";
            }

            return result;
        }

        public bool GameEnded()
        {
            return turnsLeft == 0;
        }

        public int CurrentPlayer()
        {
            return currentPlayer;
        }

        public string[] MadeMove(int player, Action action, bool[]? dice, Category? category)
        {
            Debug.WriteLine(Convert.ToString(player) + " " + Convert.ToString(action) + " " + Convert.ToString(dice) + " " + Convert.ToString(category) + "\n");

            string response = "OK";
            string[] response2 = [];

            if (player < 0 || player > players || player != currentPlayer)
            {
                return ["Wrong player number"];
            }

            switch(action)
            {
                case Action.Join:
                    break;
                case Action.Roll:
                    if (dice == null)
                    {
                        return ["No dice specified"];
                    }
                    else if (dice.Length != 5)
                    {
                        return ["Wrong size of dice array"];
                    }

                    response = PlayerRolledDice(player, dice);
                    break;
                case Action.ChooseCategory:
                    if(category == null || !category.HasValue)
                    {
                        return ["Category not specified"];
                    }
                    else if(!Enum.IsDefined(typeof(Category), category))
                    {
                        return ["Undefied category"];
                    }
                    currentPlayer = (currentPlayer + 1) % players;
                    --turnsLeft;

                    response2 = PlayerChooseCategory(player, category.Value);
                    break;
                case Action.Quit:
                    break;
                default:
                    return ["Wrong player action"];
            }

            if(response2.Length == 0)
            {
                return [response];
            }
            else
            {
                return response2;
            }
        }

        private string PlayerRolledDice(int player, bool[] whichDice)
        {
            if (rolls[player] == 0)
            {
                whichDice = [true, true, true, true, true];
            }
            else if (rolls[player] >= maxRolls)
            {
                return "Player " + player + " already rolled maximum number of times";
            }

            string diceCombination = "";

            for (int i = 0; i < 5; ++i)
            {
                if (whichDice[i])
                {
                    dice[player, i] = (Dice) random.Next(0, Enum.GetNames(typeof(Dice)).Length) + 1;
                }

                diceCombination += Convert.ToString((int) dice[player, i]);
            }

            ++rolls[player];

            return diceCombination;
        }

        private string[] PlayerChooseCategory(int player, Category category)
        {
            if (categories[player, (int) category])
            {
                return ["Category " + Convert.ToString(category) + " for Player " + player + " already chosen"];
            }
            else
            {
                categories[player, (int)category] = true;
                rolls[player] = 0;
                return AddScore(player, category);
            }
        }

        private string[] AddScore(int player, Category category)
        {
            int scoreType1 = 0, scoreType2 = 0;
            int bonus = 0;

            switch (category)
            {
                case Category.Aces:
                    scoreType1 += FirstTypeCategory(player, Dice.One);
                    bonus += Bonus(player);
                    break;
                case Category.Twos:
                    scoreType1 += FirstTypeCategory(player, Dice.Two);
                    bonus += Bonus(player);
                    break;
                case Category.Threes:
                    scoreType1 += FirstTypeCategory(player, Dice.Three);
                    bonus += Bonus(player);
                    break;
                case Category.Fours:
                    scoreType1 += FirstTypeCategory(player, Dice.Four);
                    bonus += Bonus(player);
                    break;
                case Category.Fives:
                    scoreType1 += FirstTypeCategory(player, Dice.Five);
                    bonus += Bonus(player);
                    break;
                case Category.Sixes:
                    scoreType1 += FirstTypeCategory(player, Dice.Six);
                    bonus += Bonus(player);
                    break;
                case Category.ThreeOfAKind:
                    scoreType2 += SomeOfAKindScore(player, 3);
                    break;
                case Category.FourOfAKind:
                    scoreType2 += SomeOfAKindScore(player, 4);
                    break;
                case Category.FullHouse:
                    int pair = SomeOfAKindScore(player, 2);
                    int tuple = SomeOfAKindScore(player, 3);

                    if(pair != 0 && tuple != 0)
                    {
                        scoreType2 += 25;
                    }
                    break;
                case Category.SmallStraight:
                    scoreType2 += Straight(player, Category.SmallStraight);
                    break;
                case Category.LargeStraight:
                    scoreType2 += Straight(player, Category.LargeStraight);
                    break;
                case Category.Yahtzee:
                    scoreType2 += (SomeOfAKindScore(player, 5) != 0 ? 50 : 0);
                    break;
                case Category.Chance:
                    scoreType2 += DiceSum(player);
                    break;
            }

            scoreArray[player, 0] += scoreType1;
            scoreArray[player, 0] += bonus;
            scoreArray[player, 1] += scoreType2;

            string response = "Player " + player + " got [" + (scoreType1 + scoreType2) + "] points for category " + Convert.ToString(category);
            if(bonus > 0)
            {
                response += " with bonus " + bonusPoints + " points";
            }

            return [Convert.ToString(scoreType1 + scoreType2), Convert.ToString(category), response,
                Convert.ToString(dice[player, 0]) + "-" + Convert.ToString(dice[player, 1]) + "-" + Convert.ToString(dice[player, 2]) + "-" + Convert.ToString(dice[player, 3]) + "-" + Convert.ToString(dice[player, 4])
            ];
        }

        private int FirstTypeCategory(int player, Dice type)
        {
            int count = 0;

            for (int i = 0; i < 5; ++i)
            {
                if (dice[player, i] == type)
                {
                    ++count;
                }
            }

            return count * (int) type;
        }

        private int Bonus(int player)
        {
            int count = 0;

            for(Category category = Category.Aces; category < Category.ThreeOfAKind; ++category)
            {
                if (categories[player, (int) category] == true)
                {
                    ++count;
                }
            }

            return count == 6 && scoreArray[player, 0] >= 63 ? bonusPoints : 0;
        }

        private int SomeOfAKindScore(int player, int k)
        {
            int[] dice = new int[Enum.GetNames(typeof(Dice)).Length];
            bool ok = false;

            for (int i = 0; i < 5; ++i)
            {
                ++dice[(int) this.dice[player, i] - 1];

                if(dice[(int)this.dice[player, i] - 1] == k)
                {
                    ok = true;
                }
            }

            if(ok)
            {
                return DiceSum(player);
            }
            else
            {
                return 0;
            }
        }

        private int Straight(int player, Category category)
        {
            int mask = 0;

            for( int i = 0; i < 5; ++i)
            {
                mask |= (1 << (int) dice[player, i]);
            }

            if(category == Category.SmallStraight)
            {
                if (mask == 0b111100 || mask == 0b011110 || mask == 0b001111)
                {
                    return 30;
                }
            }
            else
            {
                if (mask == 0b111110 || mask == 0b011111)
                {
                    return 40;
                }
            }

            return 0;
        }

        private int DiceSum(int player)
        {
            int sum = 0;

            for (int i = 0; i < 5; ++i)
            {
                sum += (int) dice[player, i];
            }

            return sum;
        }
    }
}
