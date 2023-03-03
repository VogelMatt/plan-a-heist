using System;
using System.Collections.Generic;

namespace plan_a_heist
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Member> Team = new List<Member>();
            Console.WriteLine("Plan Your Heist!");

            Console.WriteLine("Please select a difficulty level:");
            string bankDifficultyLevelString = Console.ReadLine();
            int.TryParse(bankDifficultyLevelString, out int userBankDifficultyLevel);

            string memberName = "";
            do
            {
                Console.WriteLine("Crew Member Name:");
                memberName = Console.ReadLine();
                if (memberName == "")
                {
                    break;
                }


                Console.WriteLine("Crew Member skill level:");
                string memberSkillLevelString = Console.ReadLine();
                int.TryParse(memberSkillLevelString, out int memberSkillLevel);

                Console.WriteLine("Crew Member courage factor:");
                string memberCourageFactorString = Console.ReadLine();
                double.TryParse(memberCourageFactorString, out double memberCourageFactor);

                Member newMember = new Member(memberName, memberSkillLevel, memberCourageFactor);
                Team.Add(newMember);
                Console.WriteLine();
            }
            while (memberName.Length > 0);

            int teamSkillLevel = 0;

            foreach (Member member in Team)
            {
                teamSkillLevel += member.SkillLevel;
            }

            Console.WriteLine("How many trials do you want to run?:");
            string trialChoiceString = Console.ReadLine();
            int.TryParse(trialChoiceString, out int trialChoice);

            int successfulTrials = 0;
            int failedTrials = 0;

            for (int i = 0; i < trialChoice; i++)
            {
                int bankDifficultyLevel = userBankDifficultyLevel;
                int LuckValue = new Random().Next(-10, 11);
                bankDifficultyLevel += LuckValue;

                Console.WriteLine($"total skill level of team :{teamSkillLevel} and bank's difficulty level is {bankDifficultyLevel}");

                if (teamSkillLevel >= bankDifficultyLevel)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"you did it");
                    Console.ResetColor();
                    successfulTrials++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"straight to jail");
                    Console.ResetColor();
                    failedTrials++;
                }
            }
            Console.WriteLine($"Number of successful runs: {successfulTrials}");
            Console.WriteLine($"Number of failed runs: {failedTrials}");
        }
    }
}