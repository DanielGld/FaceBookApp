using System.Collections.Generic;
using System;

namespace Logic
{
    public class TestManagement : ITesterObserver
    {
        UserFriendTestData m_TestData;

        public int QuizScore { get; set; } = 0;

        public Dictionary<int, AnswersObservable> m_UserAnswers { get; set; }

        public TestManagement(int i_NumOfQuestions, UserFriendTestData i_TestData/*, AnswersObservable i_AnswersObservable*/)
        {
            m_TestData = i_TestData;
            m_UserAnswers = new Dictionary<int, AnswersObservable>();

            AnswersObservable m_LiveAnswer = new AnswersObservable(i_TestData.City);
            m_LiveAnswer.AttachObserver(this);
            m_UserAnswers.Add(0, m_LiveAnswer);

            AnswersObservable m_MonthAnswer = new AnswersObservable(i_TestData.BirthMonth);
            m_MonthAnswer.AttachObserver(this);
            m_UserAnswers.Add(1, m_MonthAnswer);

            AnswersObservable m_AgeAnswer = new AnswersObservable(i_TestData.CurrentAge);
            m_AgeAnswer.AttachObserver(this);
            m_UserAnswers.Add(2, m_AgeAnswer);

            AnswersObservable m_BornDayAnswer = new AnswersObservable(i_TestData.DayOfBirth);
            m_BornDayAnswer.AttachObserver(this);
            m_UserAnswers.Add(3, m_BornDayAnswer);
        }

        public void CorrectAnswerSelected()
        {
            QuizScore++;
        }

        public bool HasAnsweredAllQ()
        {
            bool answeredAll = true;

            foreach (AnswersObservable observer in m_UserAnswers.Values)
            {
                if (string.IsNullOrEmpty(observer.Answer))
                {
                    answeredAll = false;
                }
            }

            return answeredAll;
        }

        public void ResetTestData()
        {
            QuizScore = 0;
            for (int i = 0; i < m_UserAnswers.Count; i++) 
            {
                m_UserAnswers[i] = null;
            }
        }
    }
}