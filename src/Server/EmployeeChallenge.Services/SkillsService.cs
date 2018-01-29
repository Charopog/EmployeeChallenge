
namespace EmployeeChallenge.Services
{
    using AutoMapper;
    using EmployeeChallenge.Common.CustomExceptions;
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Entities;
    using EmployeeChallenge.Services.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SkillsService : ISkillsService
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;

        public SkillsService(IMapper mapper, ISkillRepository skillRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
        {
            var roles = await _skillRepository.GetAllSkillsAsync();
            return _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDto>>(roles);
        }

        public async Task<SkillDto> GetSkillAsync(Guid skillID)
        {
            var skill = await _skillRepository.GetSingleOrDefaultSkillAsync(skillID);
            if (skill == null)
            {
                throw new CustomNotFoundException($"Skill {skillID} does not exist");
            }
            return _mapper.Map<Skill, SkillDto>(skill);
        }

        public async Task<Guid> CreateSkillAsync(SkillDto skillDto)
        {
            var skill = _mapper.Map<SkillDto, Skill>(skillDto);
            _skillRepository.CreateSkill(skill);

            await _skillRepository.CommitAsync();
            return skill.ID;
        }

        public async Task DeleteSkillAsync(Guid skillID)
        {
            var skill = await _skillRepository.GetSingleOrDefaultSkillAsync(skillID);
            if (skill == null)
            {
                throw new CustomNotFoundException($"Skill {skillID} does not exist");
            }

            _skillRepository.DeleteSkill(skill);

            await _skillRepository.CommitAsync();
        }

        public async Task UpdateSkillAsync(Guid skillID, SkillDto skillDto)
        {
            var exists = await _skillRepository.ExistsAsync(skillID);
            if (!exists)
            {
                throw new CustomNotFoundException($"Skill {skillDto.ID} does not exist");
            }
            skillDto.ID = skillID;

            var skill = _mapper.Map<SkillDto, Skill>(skillDto);

            _skillRepository.UpdateSkill(skill);

            await _skillRepository.CommitAsync();

        }
        public Task<bool> SkillExistsAsync(Guid skillID)
        {
            return _skillRepository.ExistsAsync(skillID);
        }
    }
}
