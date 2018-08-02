using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldAppl
{
    [ServiceContract]
    interface ITrainingService
    {
        [OperationContract]
        List<Training> getTrainings();

        [OperationContract]
        Training getTraining(int id);

        [OperationContract]
        void addTraining(Training newTraining);

        [OperationContract]
        void removeTraining(int trainingId);

        [OperationContract]
        void editTraining(int trainingId, Training training);

    }

    [DataContract]
    public class Training
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Trainer { get; set; }
    }
}