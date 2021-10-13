using System.Collections.Generic;

namespace Logic
{
    public class AnswersObservable
    {
        private string m_CorrectAnswer;
        private string m_UserAnswer = null;
        private readonly List<ITesterObserver> m_TesterObservers = new List<ITesterObserver>();

        public AnswersObservable(object i_userFriendData)
        {
            m_CorrectAnswer = i_userFriendData.ToString();
        }

        public string Answer
        {
            get { return m_UserAnswer; }
            set
            {
                if (m_UserAnswer != value)
                {
                    m_UserAnswer = value.ToString();
                    if (m_CorrectAnswer == m_UserAnswer)
                    {
                        notifyTesterObservers();
                    }
                }
            }
        }

        public void AttachObserver(ITesterObserver i_TesterObserver)
        {
            m_TesterObservers.Add(i_TesterObserver);
        }

        public void DetachObserver(ITesterObserver i_TesterObserver)
        {
            m_TesterObservers.Remove(i_TesterObserver);
        }

        private void notifyTesterObservers()
        {
            foreach (ITesterObserver observer in m_TesterObservers)
            {
                observer.CorrectAnswerSelected();
            }
        }
    }
}