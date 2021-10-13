using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FaceBookUI
{
    public partial class PersonalDetailsForm : Form
    {
        public PersonalDetailsForm(User i_User)
        {
            InitializeComponent();
            SetPersonalDetails(i_User);
        }

        private void SetPersonalDetails(User i_User)
        {
            try
            {
                lableUserFirstName.Text += " " + i_User.FirstName;
                lableUserLastName.Text += " " + i_User.LastName;
                lableUserGender.Text += " " + i_User.Gender;
                lableUserBirthday.Text += " " + i_User.Birthday;
                lableUserCity.Text += " " + i_User.Location.Name;
                lableUserEmail.Text += " " + i_User.Email;
            }
            catch
            {
                MessageBox.Show("A problem has occurred");
            }
        }
    }
}