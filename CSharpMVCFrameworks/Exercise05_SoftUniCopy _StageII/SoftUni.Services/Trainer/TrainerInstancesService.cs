using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftUni.Common;
using SoftUni.Common.Settings;
using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Services.Trainer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.Services.Trainer
{
    public class TrainerInstancesService : ExtendedBaseService, ITrainerInstancesService
    {
        public TrainerInstancesService(SoftUniDbContext db, IMapper mapper, UserManager<User> userManager)
                                : base(db, mapper, userManager)
        {
        }

        public async Task<InstanceBindingModel> AddInstance(int id)
        {
            var trainers = await this.GetTrainersAsync();

            var viewModel = new InstanceBindingModel() { CourseId = id, AllTrainers = trainers };

            return viewModel;
        }

        public async Task<User> GetTrainer(string id)
        {
            var trainer = await this.userManager.FindByIdAsync(id);

            return trainer;
        }

        public void CreateInstance(InstanceBindingModel model)
        {
            var instance = this.mapper.Map<CourseInstance>(model);

            this.db.CourseInstances.Add(instance);

            this.db.SaveChanges();
        }

        public async Task<List<SelectListItem>> GetTrainersAsync()
        {
            var dbTrainers = await this.userManager.GetUsersInRoleAsync(RoleType.Trainer);

            var trainers = dbTrainers.Select(t => new SelectListItem
            {
                Text = t.FullName,
                Value = t.Id
            })
            .ToList();

            return trainers;
        }
    }
}