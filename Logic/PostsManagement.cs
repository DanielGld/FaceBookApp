using FacebookWrapper.ObjectModel;

namespace Logic
{
    public class PostsManagement
    {
        public PostsManagement()
        {
        }

        public void MakePost(User i_User, string i_Text)
        {
            i_User.PostStatus(i_Text);
        }
    }
}
