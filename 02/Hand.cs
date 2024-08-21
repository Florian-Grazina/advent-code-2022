using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Hand
    {
        public Choice Choice { get; set; }
        public Choice EnemyChoice { get; set; }


        public Hand(string[] choices)
        {
            EnemyChoice = Parse(choices[0]);
            Choice = ParseGame(choices[1]);
        }


        private Choice Parse(string choice)
        {
            return choice switch
            {
                "A" => Choice.Rock,
                "B" => Choice.Paper,
                "C" => Choice.Scissors
            };
        }

        private Choice ParseGame(string choice)
        {
            if(choice == "X")
            {
                if (EnemyChoice == Choice.Rock)
                    return Choice.Scissors;
                if (EnemyChoice == Choice.Paper)
                    return Choice.Rock;
                if (EnemyChoice == Choice.Scissors)
                    return Choice.Paper;
            }

            if (choice == "Z")
            {
                if (EnemyChoice == Choice.Rock)
                    return Choice.Paper;
                if (EnemyChoice == Choice.Paper)
                    return Choice.Scissors;
                if (EnemyChoice == Choice.Scissors)
                    return Choice.Rock;
            }

            return EnemyChoice;
        }

        public int Play()
        {
            int score = CheckScore();
            score += (int)Choice;

            return score;
        }

        private int CheckScore()
        {
            if (Choice == Choice.Rock && EnemyChoice == Choice.Scissors ||
                Choice == Choice.Paper && EnemyChoice == Choice.Rock ||
                Choice == Choice.Scissors && EnemyChoice == Choice.Paper)
                return 6;

            if (Choice == Choice.Rock && EnemyChoice == Choice.Paper ||
                Choice == Choice.Paper && EnemyChoice == Choice.Scissors ||
                Choice == Choice.Scissors && EnemyChoice == Choice.Rock)
                return 0;

            else return 3;
        }
    }
}
