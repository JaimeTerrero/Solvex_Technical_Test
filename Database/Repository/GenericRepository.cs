using Application.DTOs;
using Application.Interfaces;
using Database.Context;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            if (entity == null) throw new KeyNotFoundException("Los campos son obligatorios");
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<Entity>().FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("Los campos son obligatorios");
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<Entity> UpdateAsync(Entity entity, int id)
        {
            var entry = await _dbContext.Set<Entity>().FindAsync(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            if (entity == null) throw new KeyNotFoundException("Los campos son obligatorios");
            return entity;
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<Entity>().FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("No project found");
            return entity;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var entry = await _dbContext.Set<Project>().FindAsync(project.Id);
            _dbContext.Entry(entry).CurrentValues.SetValues(project);
            await _dbContext.SaveChangesAsync();
            if (project == null) throw new KeyNotFoundException("Los campos son obligatorios");
            return project;
        }
    }
}
