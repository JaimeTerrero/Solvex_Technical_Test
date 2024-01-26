using Application.ViewModels;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //public class ProjectService : GenericService<SaveProjectViewModel, ProjectViewModel, Project>
    //{
    //    private readonly ProjectRepository _projectRepository;

    //    public ProjectService(ApplicationDbContext context) : base()
    //    {
    //        _projectRepository = new(context);
    //    }

    //    public async Task Add(SaveProjectViewModel vm)
    //    {
    //        Project project = new();
    //        project.Name = vm.Name;
    //        project.Description = vm.Description;
    //        await _projectRepository.AddAsync(project);
    //    }

    //    public async Task Update(SaveProjectViewModel vm)
    //    {
    //        Project project = new();
    //        project.Id = vm.Id;
    //        project.Name = vm.Name;
    //        project.Description = vm.Description;
    //        await _projectRepository.UpdateAsync(project);
    //    }

    //    public async Task Delete(int id)
    //    {
    //        var project = await _projectRepository.GetByIdAsync(id);
    //        await _projectRepository.DeleteAsync(project);
    //    }

    //    public async Task<SaveProjectViewModel> GetById(int id)
    //    {
    //        var project = await _projectRepository.GetByIdAsync(id);
    //        var user = AutoMapper

    //        SaveProjectViewModel vm = new();
    //        vm.Id = id;
    //        vm.Name = project.Name;
    //        vm.Description = project.Description;
    //        vm.UserId = project.Users.fi
    //    }
    //}
}
