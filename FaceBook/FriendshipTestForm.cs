using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using Logic;

namespace FaceBookUI
{
    public partial class FriendshipTestForm : Form
    {
        private int m_NumOfQuestions = 4;
        private int m_NumOfAnswers = 4;
        private int m_QuestionNumber = 0;
        private RadioButton[] m_QLive;
        private RadioButton[] m_QMonth;
        private RadioButton[] m_QAge;
        private RadioButton[] m_QDay;
        private GroupBox[] m_Groups;
        private FriendshipTestFacade m_TestFacade;

        public FriendshipTestForm(User i_Friend)
        {
            InitializeComponent();

            m_Groups = new GroupBox[m_NumOfQuestions];
            m_QDay = new RadioButton[m_NumOfAnswers];
            m_QAge = new RadioButton[m_NumOfAnswers];
            m_QMonth = new RadioButton[m_NumOfAnswers];
            m_QLive = new RadioButton[m_NumOfAnswers];
            m_TestFacade = new FriendshipTestFacade(i_Friend, m_NumOfQuestions);
        }
     
        private void fillOptionsToRadioButtons(RadioButton[] i_RadioButtons, string[] i_Values)
        {
            for (int i = 0; i < i_Values.Length; i++)
            {
                i_RadioButtons[i].Text = i_Values[i];
            }
        }

        private void resetFormData()
        {
            foreach (GroupBox gb in m_Groups)
            {
                gb.Visible = false;
            }

            m_QuestionNumber = 0;
            buttonBack.Enabled = false;
            buttonNext.Enabled = true;
            buttonSubmit.Visible = false;
            resetRadioButton(m_QAge);
            resetRadioButton(m_QLive);
            resetRadioButton(m_QDay);
            resetRadioButton(m_QMonth);
        }

        private void getUserAnswer(RadioButton rb)
        {
            if (rb.Checked)
            {
                m_TestFacade.SaveUserAnswer(rb.Text, m_QuestionNumber);
            }

            if (m_TestFacade.HasFinishedTest())
            {
                buttonSubmit.Visible = true;
            }
        }

        private void fillRadioButtons()
        {
            m_QLive[0] = radioButtonLive1;
            m_QLive[1] = radioButtonLive2;
            m_QLive[2] = radioButtonLive3;
            m_QLive[3] = radioButtonLive4;

            m_QMonth[0] = radioButtonMonth1;
            m_QMonth[1] = radioButtonMonth2;
            m_QMonth[2] = radioButtonMonth3;
            m_QMonth[3] = radioButtonMonth4;

            m_QAge[0] = radioButtonAge1;
            m_QAge[1] = radioButtonAge2;
            m_QAge[2] = radioButtonAge3;
            m_QAge[3] = radioButtonAge4;

            m_QDay[0] = radioButtonBornDay1;
            m_QDay[1] = radioButtonBornDay2;
            m_QDay[2] = radioButtonBornDay3;
            m_QDay[3] = radioButtonBornDay4;

            m_Groups[0] = groupBoxLive;
            m_Groups[1] = groupBoxMonth;
            m_Groups[2] = groupBoxAge;
            m_Groups[3] = groupBoxBorn;
        }

        public void FriendshipTestForm_Shown(object sender, EventArgs e)
        {
            int maxAge = 90;
            int minAge = 10;
            int firstMonth = 1;
            int lastMonth = 12;
            fillRadioButtons();
            pictureBoxFriendProfile.Load(m_TestFacade.GetProfilePicURL());
            fillOptionsToRadioButtons(m_QMonth, m_TestFacade.SetUpAnswers(m_TestFacade.GetFriendBirthMonth(), firstMonth, lastMonth));
            fillOptionsToRadioButtons(m_QAge, m_TestFacade.SetUpAnswers(m_TestFacade.GetFriendAge(), minAge, maxAge));
            fillOptionsToRadioButtons(m_QDay, m_TestFacade.SetUpAnswers(m_TestFacade.GetFriendDayOfBirth()));
            fillOptionsToRadioButtons(m_QLive, m_TestFacade.SetUpAnswers(m_TestFacade.GetFriendCity()));
            m_Groups[0].Visible = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (m_Groups[m_QuestionNumber].Visible == true)
            {
                m_Groups[m_QuestionNumber].Visible = false;
                m_Groups[m_QuestionNumber + 1].Visible = true;
            }

            m_QuestionNumber++;
            if (m_QuestionNumber == m_NumOfQuestions - 1)
            {
                buttonNext.Enabled = false;
            }

            if (m_QuestionNumber > 0)
            {
                buttonBack.Enabled = true;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (m_Groups[m_QuestionNumber].Visible == true)
            {
                m_Groups[m_QuestionNumber].Visible = false;
                m_Groups[m_QuestionNumber - 1].Visible = true;
            }

            m_QuestionNumber--;
            if (m_QuestionNumber == 0)
            {
                buttonBack.Enabled = false;
            }

            if (m_QuestionNumber < m_NumOfQuestions)
            {
                buttonNext.Enabled = true;
            }
        }

        private void radioButtonBornDay_Click(object sender, EventArgs e)
        {
            getUserAnswer((RadioButton)sender);
        }

        private void radioButtonAge_Click(object sender, EventArgs e)
        {
            getUserAnswer((RadioButton)sender);
        }

        private void radioButtonLive_Click(object sender, EventArgs e)
        {
            getUserAnswer((RadioButton)sender);
        }

        private void radioButtonMonth_Click(object sender, EventArgs e)
        {
            getUserAnswer((RadioButton)sender);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You'r Score is " + m_TestFacade.FinishTest() + "/" + m_NumOfQuestions);
            resetFormData();
        }

        private void resetRadioButton(RadioButton[] rb)
        {
            foreach (RadioButton button in rb)
            {
                button.Checked = false;
            }
        }
    }
}