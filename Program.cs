using System;
using System.Collections.Generic;

namespace plan_a_heist
{
    class Program
    {
        static void Main(string[] args)
        {

            int bankDifficultyLevel = 100;

            
            List<Member> Team = new List<Member>();
            Console.WriteLine("Plan Your Heist!");

            string memberName = "";
            do
            {
                Console.WriteLine("Crew Member Name:");
                memberName = Console.ReadLine();
                if(memberName == "")
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

            }
            while (memberName.Length > 0);

            int teamSkillLevel = 0;

            foreach(Member member in Team)
            {
                teamSkillLevel += member.SkillLevel;
            }  

            if(teamSkillLevel >= bankDifficultyLevel)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"you did it");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"straight to jail");
                Console.ResetColor();
            }

            Console.WriteLine($"there are {Team.Count} members");

                // foreach (Member member in Team)
                // {
                // Console.WriteLine($"{member.Name} has a skill level of {member.SkillLevel} and a courage factor of {member.CourageFactor}.");
                // }



        }
    }
}
