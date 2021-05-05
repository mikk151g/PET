using PET.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PET.Wpf.ViewModels
{
    public class ObservantViewModel : BaseViewModel
    {
        #region Private Fields

        private ObservableCollection<Observant> _observants = new ObservableCollection<Observant>();

        #endregion

        #region Constructors

        public ObservantViewModel()
        {
            GetAllObservants();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Contains all observants from the database
        /// </summary>
        public ObservableCollection<Observant> Observants
        {
            get { return _observants; }
            set { _observants = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds all the observants from the database to the Observants property
        /// </summary>
        public void GetAllObservants()
        {
            using (PETEntities db = new PETEntities())
            {
                ObservableCollection<Observant> observants = new ObservableCollection<Observant>();
                var query = from observant in db.Observant
                            orderby observant.Id
                            select observant;

                foreach (Observant observant in query)
                {
                    observants.Add(observant);
                }
                Observants = observants;
            }
        }

        /// <summary>
        /// Creates a new observant with the arguments as values and adds it to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="photo"></param>
        /// <param name="keywords"></param>
        /// <param name="nationality"></param>
        /// <param name="cprNumber"></param>
        /// <param name="height"></param>
        /// <param name="eyeColor"></param>
        /// <param name="hairColor"></param>
        /// <param name="skinColor"></param>
        /// <param name="headGear"></param>
        /// <param name="clothes"></param>
        public void CreateObservant(string firstName, string lastName, string address, string phoneNumber, string photo, string keywords, string nationality, string cprNumber, decimal height,
            string eyeColor, string hairColor, string skinColor, string headgear, string clothes)
        {
            using (PETEntities db = new PETEntities())
            {
                Observant observant = new Observant();
                observant.FirstName = firstName;
                observant.LastName = lastName;
                observant.Address = address;
                observant.PhoneNumber = phoneNumber;
                observant.Photo = photo;
                observant.Keywords = keywords;
                observant.Nationality = nationality;
                observant.CprNumber = cprNumber;
                observant.Height = height;
                observant.EyeColor = eyeColor;
                observant.HairColor = hairColor;
                observant.SkinColor = skinColor;
                observant.Headgear = headgear;
                observant.Clothes = clothes;

                db.Observant.Add(observant);
                db.SaveChanges();
            }
            GetAllObservants();
        }

        /// <summary>
        /// Converts the item to an observant and updates it with the arguments as values
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="photo"></param>
        /// <param name="keywords"></param>
        /// <param name="nationality"></param>
        /// <param name="cprNumber"></param>
        /// <param name="height"></param>
        /// <param name="eyeColor"></param>
        /// <param name="hairColor"></param>
        /// <param name="skinColor"></param>
        /// <param name="headgear"></param>
        /// <param name="clothes"></param>
        public void UpdateObservant(object selectedItem, string firstName, string lastName, string address, string phoneNumber, string photo, string keywords, string nationality, string cprNumber,
            decimal height, string eyeColor, string hairColor, string skinColor, string headgear, string clothes)
        {
            int idToUpdate = ((Observant)selectedItem).Id;

            foreach (Observant observant in Observants)
            {
                if (observant.Id == idToUpdate)
                {
                    using (PETEntities db = new PETEntities())
                    {
                        Observant update = db.Observant.Find(idToUpdate);
                        update.FirstName = firstName;
                        update.LastName = lastName;
                        update.Address = address;
                        update.PhoneNumber = phoneNumber;
                        update.Photo = photo;
                        update.Keywords = keywords;
                        update.Nationality = nationality;
                        update.CprNumber = cprNumber;
                        update.Height = height;
                        update.EyeColor = eyeColor;
                        update.HairColor = hairColor;
                        update.SkinColor = skinColor;
                        update.Headgear = headgear;
                        update.Clothes = clothes;
                        db.SaveChanges();
                    }
                }
            }
            GetAllObservants();
        }

        /// <summary>
        /// Converts the item to a observant and deletes it
        /// </summary>
        /// <param name="selectedItem">The item to delete</param>
        public void DeleteObservant(object selectedItem)
        {
            int idToDelete = ((Observant)selectedItem).Id;

            using (PETEntities db = new PETEntities())
            {
                var delete = db.Observant.Where(i => i.Id == idToDelete).First();
                db.Observant.Remove(delete);
                db.SaveChanges();
            }
            GetAllObservants();
        }

        #endregion
    }
}
