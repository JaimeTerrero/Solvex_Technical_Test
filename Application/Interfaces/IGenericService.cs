using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericService<ViewModel, SaveViewModel, Entity> 
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class
    {
        Task<SaveViewModel> AddAsync(SaveViewModel vm);
        Task UpdateAsync(SaveViewModel vm, int id);
        Task Delete(int id);
        Task<List<ViewModel>> GetAllAsync();
        Task<SaveViewModel> GetById(int id);
    }
}
