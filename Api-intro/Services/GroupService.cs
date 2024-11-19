using Api_intro.Data;
using Api_intro.DTOs.Countries;
using Api_intro.DTOs.Groups;
using Api_intro.Helpers.Exceptions;
using Api_intro.Models;
using Api_intro.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Api_intro.Services
{
    public class GroupService : IGroupService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GroupService(AppDbContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAsync(GroupCreateDto group)
        {
            await _context.Groups.AddAsync(_mapper.Map<Group>(group));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id) ?? throw new NotFoundException("Data notfound");
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, GroupEditDto group)
        {
            var existGroup = await _context.Groups.AsNoTracking()
                                                       .FirstOrDefaultAsync(m => m.Id == id) ?? throw new NotFoundException("Data notfound");

            _mapper.Map(group, existGroup);


            _context.Groups.Update(existGroup);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _context.Groups.AsNoTracking()
                                                                           .ToListAsync());
        }

        public async Task<GroupDto> GetByIdAsync(int id)
        {
            var result = await _context.Groups.AsNoTracking()
                                              .FirstOrDefaultAsync(m => m.Id == id);

            if (result is null) return null;

            return _mapper.Map<GroupDto>(result);
        }
    }
}
