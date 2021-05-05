using PET.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PET.Wpf.ViewModels
{
    public class InformantViewModel : BaseViewModel
    {
        #region Private Fields

        private ObservableCollection<Informant> _informant = new ObservableCollection<Informant>();

        #endregion

        #region Constructors

        public InformantViewModel()
        {
            GetAllInformants();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Contains all informants from the database
        /// </summary>
        public ObservableCollection<Informant> Informants
        {
            get { return _informant; }
            set { _informant = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds all the informants from the database to the Informants property
        /// </summary>
        public void GetAllInformants()
        {
            using (PETEntities db = new PETEntities())
            {
                ObservableCollection<Informant> informants = new ObservableCollection<Informant>();
                var query = from informant in db.Informant
                             orderby informant.Id
                             select informant;

                foreach (Informant informant in query)
                {
                    informants.Add(informant);
                }
                Informants = informants;
            }
        }

        /// <summary>
        /// Creates a new informant with the arguments as values and adds it to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="photo"></param>
        /// <param name="keywords"></param>
        public void CreateInformant(string firstName, string lastName, string address, string phoneNumber, string photo, string keywords)
        {
            using (PETEntities db = new PETEntities())
            {
                Informant informant = new Informant();
                informant.FirstName = firstName;
                informant.LastName = lastName;
                informant.Address = address;
                informant.PhoneNumber = phoneNumber;
                informant.Photo = photo;
                informant.Keywords = keywords;

                db.Informant.Add(informant);
                db.SaveChanges();
            }
            GetAllInformants();
        }

        /// <summary>
        /// Converts the item to an informants and updates it with the arguments as values
        /// </summary>
        /// <param name="selectedItem">The item to update</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="photo"></param>
        /// <param name="keywords"></param>
        public void UpdateInformant(object selectedItem, string firstName, string lastName, string address, string phoneNumber, string photo, string keywords)
        {
            int idToUpdate = ((Informant)selectedItem).Id;

            foreach (Informant informant in Informants)
            {
                if (informant.Id == idToUpdate)
                {
                    using (PETEntities db = new PETEntities())
                    {
                        Informant update = db.Informant.Find(idToUpdate);
                        update.FirstName = firstName;
                        update.LastName = lastName;
                        update.Address = address;
                        update.PhoneNumber = phoneNumber;
                        update.Photo = photo;
                        update.Keywords = keywords;
                        db.SaveChanges();
                    }
                }
            }
            GetAllInformants();
        }

        /// <summary>
        /// Converts the item to a informant and deletes it
        /// </summary>
        /// <param name="selectedItem">The item to delete</param>
        public void DeleteInformant(object selectedItem)
        {
            int idToDelete = ((Informant)selectedItem).Id;
                        
            using (PETEntities db = new PETEntities())
            {
                var delete = db.Informant.Where(i => i.Id == idToDelete).First();
                db.Informant.Remove(delete);
                db.SaveChanges();
            }   
            GetAllInformants();
        }

        #endregion
    }
}
