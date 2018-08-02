using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HelloWorldAppl
{
    
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class TrainingService : ITrainingService
    {
        List<Training> trainingsList = GetTraining();

        private static List<Training> GetTraining()
        {
            return new List<Training>
            {
                new Training {Id=1, Name="WCF", Description ="platform to create SOA application", Trainer="Ankit" },
                new Training {Id=2, Name="asmxService", Description ="platform to create distributed application for HTTP", Trainer="Rahul" },
                new Training {Id=3, Name="Web Api", Description ="platform to create HTTP application", Trainer="Sachin" }

            };
        }

        public void addTraining(Training newTraining)
        {
            var maxId = trainingsList.Max(e => e.Id);
            newTraining.Id = maxId + 1;
            if (newTraining != null)
            {
                trainingsList.Add(newTraining);
            }
            else
            {
                throw new Exception("New Training can't be null");
            }
            
        }

        public void editTraining(int trainingId, Training training)
        {
            var res = trainingsList.Find(e => e.Id == trainingId);
            if (res == null)
            {
                throw new Exception("Not Dound !!");
            }
            else
            {
                try
                {
                    res.Name = training.Name;
                    res.Trainer = training.Trainer;
                    res.Description = training.Description;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public Training getTraining(int id)
        {
            var res = trainingsList.Find(e => e.Id == id);
            if (res == null)
            {
                throw new Exception("Not Dound !!");
            }
            else
            {
                return res;
            }
        }
        public List<Training> getTrainings()
        {
            return trainingsList;
        }

        public void removeTraining(int trainingId)
        {
            var res = trainingsList.Find(e => e.Id == trainingId);
            if (res == null)
            {
                throw new Exception("Not Dound !!");
            }
            else
            {
                trainingsList.Remove(res);
            }
        }
    }
}
