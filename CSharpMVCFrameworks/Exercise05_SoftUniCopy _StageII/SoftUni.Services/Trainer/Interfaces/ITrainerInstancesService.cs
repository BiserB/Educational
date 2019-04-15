using Microsoft.AspNetCore.Mvc.Rendering;
using SoftUni.Common;
using SoftUni.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftUni.Services.Trainer.Interfaces
{
    public interface ITrainerInstancesService
    {
        Task<InstanceBindingModel> AddInstance(int id);

        Task<List<SelectListItem>> GetTrainersAsync();

        Task<User> GetTrainer(string id);

        void CreateInstance(InstanceBindingModel model);
    }
}