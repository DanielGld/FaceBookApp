using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Logic
{
    public sealed class FbBasicOpertion
    {
        public User m_User = null;
        public PhotosManagement m_PhotosManagement;
        public PostsManagement m_PostsManagement;
        public LoginResult m_LoginResult;
        private AppSettings m_AppSettings = new AppSettings();
        private static FbBasicOpertion s_Instance = null;
        private static readonly object sr_lock = new object();

        private FbBasicOpertion()
        {
        }

        public static FbBasicOpertion Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_lock)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new FbBasicOpertion();
                        }
                    }
                }
                return s_Instance;
            }
        }
       

        public void LoginToFb(string i_LastAccessToken)
        {
            if (i_LastAccessToken == null)
            {
                m_LoginResult = FacebookService.Login("472137157098899", "public_profile,user_birthday,user_friends,user_gender,user_likes,user_photos,user_posts");
            }
            else
            {
                m_LoginResult = FacebookService.Connect(i_LastAccessToken);
            }

            m_User = m_LoginResult.LoggedInUser;
            m_PhotosManagement = new PhotosManagement(m_User);
            m_PostsManagement = new PostsManagement();
        }
    }
}
