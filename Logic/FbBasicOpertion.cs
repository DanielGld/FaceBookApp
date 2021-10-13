using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Logic
{
    public sealed class FbBasicOpertion
    {
        private static readonly object sr_Lock = new object();
        private static FbBasicOpertion s_Instance = null;
        private readonly string r_AppID = "472137157098899";
        private readonly string r_FbPermissions = "public_profile,user_birthday,user_friends,user_gender,user_likes,user_photos,user_posts";

        public LoginResult LoginResult { get; private set; }

        private FbBasicOpertion()
        {
        }

        public static FbBasicOpertion Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_Lock)
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
       
        public User LoginToFb(string i_LastAccessToken)
        {
            if (LoginResult == null  && i_LastAccessToken == null)
            {
                LoginResult = FacebookService.Login(r_AppID, r_FbPermissions);
            }
            else
            {
                i_LastAccessToken = i_LastAccessToken == null ? LoginResult.AccessToken : i_LastAccessToken;
                LoginResult = FacebookService.Connect(i_LastAccessToken);
            }
            
            return LoginResult.LoggedInUser;
        }

        public void LogOutFromFB()
        {
            // FacebookService.Logout();
        }
    }
}
