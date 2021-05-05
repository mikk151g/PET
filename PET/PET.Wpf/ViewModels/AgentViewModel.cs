using PET.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PET.Wpf.ViewModels
{
    public class AgentViewModel : BaseViewModel
    {
        #region Private Fields

        private ObservableCollection<Agent> _agents = new ObservableCollection<Agent>();

        #endregion

        #region Constructors

        public AgentViewModel()
        {
            GetAllAgents();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Contains all agents from the database
        /// </summary>
        public ObservableCollection<Agent> Agents
        {
            get { return _agents; }
            set { _agents = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds all the agents from the database to the Agents property
        /// </summary>
        public void GetAllAgents()
        {
            using (PETEntities db = new PETEntities())
            {
                var agents = from agent in db.Agent
                                          orderby agent.Id
                                          select agent;

                foreach (Agent registration in agents)
                {
                    Agents.Add(registration);
                }
            }
        }

        /// <summary>
        /// Creates a new agent with the arguments as values and adds it to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="photo"></param>
        public void CreateAgent(string firstName, string lastName, string address, string phoneNumber, string photo)
        {
            using (PETEntities db = new PETEntities())
            {
                Agent agent = new Agent();
                agent.FirstName = firstName;
                agent.LastName = lastName;
                agent.Address = address;
                agent.PhoneNumber = phoneNumber;
                agent.Photo = photo;

                db.Agent.Add(agent);
                db.SaveChanges();
            }
            GetAllAgents();
        }

        /// <summary>
        /// Converts the item to an agent and updates it with the arguments as values
        /// </summary>
        /// <param name="selectedItem">The item to update</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="photo"></param>
        public void UpdateAgent(object selectedItem, string firstName, string lastName, string address, string phoneNumber, string photo)
        {
            int idToUpdate = ((Agent)selectedItem).Id;

            foreach (Agent agent in Agents)
            {
                if (agent.Id == idToUpdate)
                {
                    using (PETEntities db = new PETEntities())
                    {
                        Agent update = db.Agent.Find(idToUpdate);
                        update.FirstName = firstName;
                        update.LastName = lastName;
                        update.Address = address;
                        update.PhoneNumber = phoneNumber;
                        update.Photo = photo;
                        db.SaveChanges();
                    }
                }
            }
            GetAllAgents();
        }

        /// <summary>
        /// Converts the item to a agent and deletes it
        /// </summary>
        /// <param name="selectedItem">The item to delete</param>
        public void DeleteRegistration(object selectedItem)
        {
            int idToDelete = ((Agent)selectedItem).Id;

            foreach (Agent agent in Agents)
            {
                if (agent.Id == idToDelete)
                {
                    using (PETEntities db = new PETEntities())
                    {
                        db.Agent.Remove(agent);
                        db.SaveChanges();
                    }
                }
            }
            GetAllAgents();
        }

        #endregion
    }
}
