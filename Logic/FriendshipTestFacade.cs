using FacebookWrapper.ObjectModel;

namespace Logic
{
    public class FriendshipTestFacade
    {
        private TestManagement m_TestResults;
        private UserFriendTestData m_FriendData;
        private SetupAnswers m_TestData;
        private AnswersObservable m_AnswersObservable;

        public FriendshipTestFacade(User i_Friend, int i_NumOfQuestions)
        {
            m_FriendData = new UserFriendTestData(i_Friend);
            m_TestData = new SetupAnswers();
            m_TestResults = new TestManagement(i_NumOfQuestions, m_FriendData);
        }

        public void SaveUserAnswer(string i_SelectedAnswer, int i_QuestionNum)
        {
            m_TestResults.m_UserAnswers[i_QuestionNum].Answer = i_SelectedAnswer;
        }

        public bool HasFinishedTest()
        {
            return m_TestResults.HasAnsweredAllQ();
        }

        public string GetProfilePicURL()
        {
            return m_FriendData.UserFriend.PictureNormalURL;
        }

        public int FinishTest()
        {
            int testScore = 0;
            testScore = m_TestResults.QuizScore;
            m_TestResults.ResetTestData();

            return testScore;
        }

        public string[] SetUpAnswers(int i_CorrectAnswer, int i_MaxValue, int i_MinValue)
        {
            return m_TestData.SetUpNumericAnswers(i_CorrectAnswer, i_MaxValue, i_MinValue);
        }

        public string[] SetUpAnswers(string i_CorrectAnswer)
        {
            return m_TestData.SetUpWordAnswers(i_CorrectAnswer);
        }

        public int GetFriendBirthMonth()
        {
            return m_FriendData.BirthMonth;
        }

        public int GetFriendAge()
        {
            return m_FriendData.CurrentAge;
        }
        
        public string GetFriendDayOfBirth()
        {
            return m_FriendData.DayOfBirth;
        }

        public string GetFriendCity()
        {
            return m_FriendData.City;
        }
    }
}
