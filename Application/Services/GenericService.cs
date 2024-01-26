using Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where Entity : class
        where SaveViewModel : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Entity> _genericRepository;

        public GenericService(IGenericRepository<Entity> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public virtual async Task<SaveViewModel> AddAsync(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(await _genericRepository.AddAsync(entity));
            return saveVm;
        }

        public virtual async Task UpdateAsync(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _genericRepository.UpdateAsync(entity, id);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            await _genericRepository.DeleteAsync(id);
        }

        public virtual async Task<SaveViewModel> GetById(int id)
        {
            return _mapper.Map<SaveViewModel>(await _genericRepository.GetByIdAsync(id));
        }

        public virtual async Task<List<ViewModel>> GetAllAsync()
        {
            return _mapper.Map<List<ViewModel>>(await _genericRepository.GetAllAsync());
        }
    }
}
