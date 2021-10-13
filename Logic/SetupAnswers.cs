using System;
using System.Linq;

namespace Logic
{
    public class SetupAnswers
    {
        private Random m_Rand = new Random();

        public string[] Cities { get; } = { "Netanya", "Ashdod", "Tel-Aviv", "Haifa", "Dimona", "Eilat", "Jerusalem" };

        public string[] DaysOfWeek { get; } = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public string[] SetUpNumericAnswers(int i_CorrectAnswer, int i_MaxValue, int i_MinValue)
        {
            string[] values = new string[4];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = m_Rand.Next(i_MaxValue, i_MinValue).ToString();
            }

            values[m_Rand.Next(0, 3)] = i_CorrectAnswer.ToString();

            return values;
        }

        public string[] SetUpWordAnswers(string i_CorrectAnswer)
        {
            string[] answerChoices;
            string[] values = new string[4];

            if (DaysOfWeek.Contains(i_CorrectAnswer))
            {
                answerChoices = DaysOfWeek;
            }
            else
            {
                answerChoices = Cities;
            }

            for (int i = 0; i < values.Length; i++) 
            {
                values[i] = answerChoices[m_Rand.Next(0, answerChoices.Length)];
            }

            values[m_Rand.Next(0, 3)] = i_CorrectAnswer;

            return values;
        }
    }
}