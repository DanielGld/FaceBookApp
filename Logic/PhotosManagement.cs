using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Logic
{
    public class PhotosManagement
    {
        public Photo[] PicsInAlbum { get; private set; }

        public Album MobileUploadsAlbum { get; private set; }
        
        public int TotalNumOfPhotos { get; private set; } = 0;

        public readonly int r_NumOfPicturesInPage;

        public SortPhotosStrategy m_SortPhoto;

        public PhotosManagement(User i_User, int i_NumOfPicturesInPage)
        {
            getAlbum(i_User);
            getAllPhotos(i_User);
            r_NumOfPicturesInPage = i_NumOfPicturesInPage;
            m_SortPhoto = new SortPhotosStrategy(this);
        }

        private void getAlbum(User i_User)
        {
            foreach (Album album in i_User.Albums)
            {
                if (album.Name.ToLower() == "mobile uploads")
                {
                    MobileUploadsAlbum = album;
                }
            }
        }

        private void getAllPhotos(User i_User)
        {
            try
            {
                TotalNumOfPhotos = MobileUploadsAlbum.Photos.Count;
                PicsInAlbum = new Photo[TotalNumOfPhotos];
                for (int i = 0; i < TotalNumOfPhotos; i++)
                {
                    PicsInAlbum[i] = MobileUploadsAlbum.Photos[i];
                }
            }
            catch { }
        }

        public IEnumerable<Photo> GetUserPhotos(int i_PhotosToDisplayIndex)
        {
            int totalNumOfPhotos = PicsInAlbum.Length;
            int currentPhotoIndex = i_PhotosToDisplayIndex;

            i_PhotosToDisplayIndex += r_NumOfPicturesInPage;
            while (currentPhotoIndex < i_PhotosToDisplayIndex)
            {
                yield return currentPhotoIndex < totalNumOfPhotos ? PicsInAlbum[currentPhotoIndex++] : null;
            }
        }

        public class SortPhotosStrategy
        {
            PhotosManagement m_PhotosManagemnent;

            public SortFilterFunc m_FilterParameter { get; set; }

            public SortPhotosStrategy(PhotosManagement i_PhotosManagment)
            {
                m_PhotosManagemnent = i_PhotosManagment;
            }

            public delegate int SortFilterFunc(int i_index);

            public void SortPhotosBy()
            {
                int[] sortedPhotos = new int[m_PhotosManagemnent.TotalNumOfPhotos];
                int[] originalArry = new int[m_PhotosManagemnent.TotalNumOfPhotos];

                if (m_FilterParameter != null)
                {
                    for (int i = 0; i < m_PhotosManagemnent.TotalNumOfPhotos; i++)
                    {
                        sortedPhotos[i] = m_FilterParameter.Invoke(i);
                        originalArry[i] = sortedPhotos[i];
                    }
                }

                Array.Sort(sortedPhotos);
                for (int i = m_PhotosManagemnent.TotalNumOfPhotos - 1; i >= 0; i--)
                {
                    for (int j = 0; j < m_PhotosManagemnent.TotalNumOfPhotos; j++)
                    {
                        if (sortedPhotos[i] == originalArry[j])
                        {
                            m_PhotosManagemnent.PicsInAlbum[m_PhotosManagemnent.TotalNumOfPhotos - 1 - i] = m_PhotosManagemnent.MobileUploadsAlbum.Photos[j];
                            originalArry[j] = -1;
                            break;
                        }
                    }
                }
            }
        }
    }
}