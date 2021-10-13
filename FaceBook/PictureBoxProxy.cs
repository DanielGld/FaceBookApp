using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FaceBookUI
{
    public class PictureBoxProxy : PictureBox
    {
        public Photo Photo { get; set; }

        public PictureBoxProxy()
        {
        }

        public void LoadAsync(Photo i_Photo)
        {
            base.LoadAsync(i_Photo.PictureNormalURL);
            Photo = i_Photo;
        }
    }
}