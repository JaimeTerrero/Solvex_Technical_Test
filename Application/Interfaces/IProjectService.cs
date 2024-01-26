using Application.ViewModels;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectService : IGenericService<ProjectViewModel, SaveProjectViewModel, Project>
    {
    }
}
