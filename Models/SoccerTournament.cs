using System;
using System.Collections.Generic;

namespace Models
{
    public class SoccerTournament
    {
        // Attributes
        private String firstTeamName, secondTeamName;
        private Int32  goalsScoredFirstTeam, goalsScoredSecondTeam;

        /// <summary>Constructor method</summary>
        public SoccerTournament()
        {
            this.firstTeamName         = "";
            this.secondTeamName        = "";
            this.goalsScoredFirstTeam  = 0;
            this.goalsScoredSecondTeam = 0;
        }

        // Methods
        /// Getters and setters
        public String FirstTeamName
        {
            get { return firstTeamName; }
            set { firstTeamName = value; }
        }
        public String SecondTeamName
        {
            get { return firstTeamName; }
            set { firstTeamName = value; }
        }

        public Int32 GoalsScoredFirstTeam
        {
            get { return goalsScoredFirstTeam; }
            set { goalsScoredFirstTeam = value; }
        }
        public Int32 GoalsScoredSecondTeam
        {
            get { return goalsScoredSecondTeam; }
            set { goalsScoredSecondTeam = value; }
        }

        // Validations
        /// <summary>Is empty</summary>
        private Boolean IsEmpty(String teamName)
        {
            return teamName == "";
        }

        public void ShowGame()
        {
            Console.WriteLine(
                "{ Results }\n(" +
                this.goalsScoredFirstTeam + ") " +
                this.firstTeamName + " vs " +
                this.secondTeamName + " (" +
                this.goalsScoredSecondTeam + ")"
            );
        }

        /// <summary>Of index</summary>
        public static void ShowGameOfIndex(List<SoccerTournament> matchResults, Int32 index)
        {
            Console.WriteLine(
                "{ Results }\n(" +
                matchResults[index].GoalsScoredFirstTeam + ") " +
                matchResults[index].FirstTeamName + " vs " +
                matchResults[index].SecondTeamName + " (" +
                matchResults[index].GoalsScoredSecondTeam + ")"
            );
        }

        private String RegisterTeamName(String propName)
        {
            String teamName = "";

            do
            {
                Console.Write("Type the {0} team name: ", propName);
                teamName = Console.ReadLine();

                if (this.IsEmpty(teamName))
                {
                    Console.WriteLine("\nError! The {0} team name is empty\n", propName);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            } while (this.IsEmpty(teamName));

            Console.Clear();

            return teamName;
        }
        
        public Int32 RegisterTeamGoals(String propName)
        {
            Int32 teamGoals = 0;

            do
            {
                Console.Write("Type the {0} team goals: ", propName);
                teamGoals = Convert.ToInt32(Console.ReadLine());

                if (teamGoals < 0 || teamGoals > 15)
                {
                    Console.WriteLine("\nError! {0} team goals are not valid\n", propName);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            } while (teamGoals < 0 || teamGoals > 15);

            Console.Clear();

            return teamGoals;
        }

        /// <summary>Register game results.
        /// (*) Data: team names and goals</summary>
        public void RegisterGameResults()
        {
            this.firstTeamName         = this.RegisterTeamName("first");
            this.goalsScoredFirstTeam  = this.RegisterTeamGoals("first");
            this.secondTeamName        = this.RegisterTeamName("second");
            this.goalsScoredSecondTeam = this.RegisterTeamGoals("second");
        }

        /// <summary>Show game with more goals</summary>
        public static Int32 GetPositionOfTheHighest(List<SoccerTournament> matchResults, String propName)
        {
            Int32 firstGoal = 0;
            Int32 higher    = 0;

            propName = propName.ToLower();

            if (propName == "first")
                firstGoal = matchResults[0].GoalsScoredFirstTeam;
            
            if (propName == "second")
                firstGoal = matchResults[0].GoalsScoredSecondTeam;

            for (Int32 index = 0; index < matchResults.Count; index++)
            {
                // LMAO
                if (propName == "first")
                    if (matchResults[index].GoalsScoredFirstTeam > firstGoal)
                        higher = index;

                if (propName == "second")
                    if (matchResults[index].GoalsScoredSecondTeam > firstGoal)
                        higher = index;
            }

            return higher;
        }

        /// <summary>Show game with more goals</summary>
        public static Boolean IsBarcelonaFC(List<SoccerTournament> matchResults)
        {
            foreach (var results in matchResults)
            {
                if (
                    results.firstTeamName == "barcelona"    ||
                    results.firstTeamName == "barcelona fc" ||
                    results.secondTeamName == "barcelona"   ||
                    results.secondTeamName == "barcelona fc"
                ) return true;
            }

            return false;
        }

        /// <summary>Show game with more goals</summary>
        public static void ShowGameWithMoreGoals(List<SoccerTournament> matchResults)
        {
            Int32 firstIndex  = SoccerTournament.GetPositionOfTheHighest(matchResults, "first");
            Int32 secondIndex = SoccerTournament.GetPositionOfTheHighest(matchResults, "second");
            Int32 res         = (firstIndex > secondIndex) ? firstIndex : secondIndex;

            SoccerTournament.ShowGameOfIndex(matchResults, res);
        }

        /// <summary>Get tied games</summary>
        public static Int32 GetTiedGames(List<SoccerTournament> matchResults)
        {
            Int32 totalTiedGames = 0;

            foreach (SoccerTournament results in matchResults)
            {
                if (results.GoalsScoredFirstTeam == results.GoalsScoredSecondTeam)
                    totalTiedGames++;
            }

            return totalTiedGames;
        }
    }
}
