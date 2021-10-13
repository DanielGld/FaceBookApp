using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Logic
{
    public class QuizFacade
    {
        public User m_User;
        public SetupAnswers m_Answers;
        public TestManagement m_TestManagment;
        public UserFriendTestData m_FriendData;
        //private PhotosManagement m_PhotosManagement;
        //private PostsManagement m_PostsManagement;

        public QuizFacade(User io_User, string io_FriendName, int io_NumOfQuestions)
        {
            m_User = io_User;
            m_Answers = new SetupAnswers();
            m_FriendData = new UserFriendTestData(io_User, io_FriendName);
            m_TestManagment = new TestManagement(io_NumOfQuestions, m_FriendData);

            //m_PhotosManagement = new PhotosManagement(m_User);
            //m_PostsManagement = new PostsManagement();
        }

        public string[] SetUpAnswer(object io_answer, int? io_min = 0, int io_max = 0)
        {
            if (io_min == 0 && io_max == 0)
            {
                return m_Answers.SetUpWordAnswers((string)io_answer);
            }
            else
            {
                return m_Answers.SetUpNumericAnswers((int)io_answer, (int)io_min, (int)io_max);
            }
        }

        public int QuizScore()
        {
            int QuizScore;

            m_TestManagment.CheckAnswers();
            QuizScore = m_TestManagment.QuizScore;
            m_TestManagment.ResetTestData();

            return QuizScore;
        }

        public string[] GetUserAnswers()
        {
            return m_TestManagment.UserAnswers;
        }

        public bool IsAllQuestionsAnswered()
        {
            return m_TestManagment.HasAnsweredAllQ();
        }

        public string GetFriendProfilePicture()
        {
            return m_FriendData.UserFriend.PictureLargeURL;
        }
    }
}
