using System;
using FacebookWrapper.ObjectModel;

namespace Logic
{
    public class UserFriendTestData
    {
        DateTime m_BirthDate;

        public string City { get; private set; }

        public int CurrentAge { get; private set; }

        public int BirthMonth { get; private set; }

        public string DayOfBirth { get; private set; }

        public User UserFriend { get; private set; }

        public UserFriendTestData(User i_Friend)
        {
            UserFriend = i_Friend;
            GetFriendDetails();
        }

        private void GetFriendDetails()
        {
            getFriendBirthDate();
            CalculateAge(m_BirthDate, DateTime.Now);
            try
            {
                City = UserFriend.Location.Name;  
            }
            catch
            {
                City = "No city";
            }
        }

        private void CalculateAge(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            {
                age--;
            }

            CurrentAge = age;
        }

        private void getFriendBirthDate()
        {
            int day, month, year;
            try
            {
                string[] friendBirthday = UserFriend.Birthday.Split('/');
                month = int.Parse(friendBirthday[0]);
                day = int.Parse(friendBirthday[1]);
                year = int.Parse(friendBirthday[2]);
            }
            catch
            {
                month = 0;
                day = 0;
                year = 0;
                DayOfBirth = "null";
            }

            m_BirthDate = new DateTime(year, month, day);
            BirthMonth = m_BirthDate.Month;
            DayOfBirth = m_BirthDate.DayOfWeek.ToString();
        }
    }
}