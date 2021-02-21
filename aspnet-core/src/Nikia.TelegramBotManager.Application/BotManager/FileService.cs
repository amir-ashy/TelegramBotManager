using Microsoft.AspNetCore.Authorization;
using Nikia.TelegramBotManager.BotManager.Validation;
using Nikia.TelegramBotManager.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Nikia.TelegramBotManager.BotManager
{
    [Authorize]
    public class FileService : CrudAppService<File, FileDto, Guid, FileResultRequestDto>, IFileService
    {
        private readonly IRepository<Bot, Guid> botRepository;
        private readonly FileValidator fileValidator;

        public FileService(IRepository<File, Guid> repository, IRepository<Bot, Guid> botRepository, FileValidator fileValidator) : base(repository)
        {
            this.botRepository = botRepository;
            this.fileValidator = fileValidator;


            GetPolicyName = TelegramBotManagerPermissions.Files.Default;
            GetListPolicyName = TelegramBotManagerPermissions.Files.Default;
            CreatePolicyName = TelegramBotManagerPermissions.Files.Create;
            UpdatePolicyName = TelegramBotManagerPermissions.Files.Edit;
            DeletePolicyName = TelegramBotManagerPermissions.Files.Delete;
        }
        public override async Task<FileDto> CreateAsync(FileDto input)
        {
            await DetermineShareUrlAsync(input);
            var file = await MapToEntityAsync(input);
            var validationResult = await fileValidator.ValidateAsync(file);
            if (!validationResult.IsValid)
                throw new AbpException(validationResult.Errors[0].ErrorMessage);
            return await base.CreateAsync(input);
        }
        public override async Task<FileDto> UpdateAsync(Guid id, FileDto input)
        {
            await DetermineShareUrlAsync(input);
            var file = await MapToEntityAsync(input);
            file.SetId(id);
            var validationResult = await fileValidator.ValidateAsync(file);
            if (!validationResult.IsValid)
                throw new AbpException(validationResult.Errors[0].ErrorMessage);
            return await base.UpdateAsync(id, input);
        }

        private async Task DetermineShareUrlAsync(FileDto input)
        {
            if (!input.ShareUrl.IsNullOrEmpty()) return;
            var bot = await botRepository.GetAsync(input.BotId);
            var fileIndex = bot.ServerPathId.Replace("Service", string.Empty) + Utility.AesOperation.RandomString(10);
            input.ShareUrl = $"https://t.me/" + bot.Name.Replace("@", string.Empty) + "?start=" + fileIndex;
        }

        public override async Task<FileDto> GetAsync(Guid id)
        {
            var query = from file in Repository
                        join bot in botRepository on file.BotId equals bot.Id
                        where file.Id == id
                        select new { bot, file };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(File), id);
            }

            var bookDto = ObjectMapper.Map<File, FileDto>(queryResult.file);
            bookDto.BotName = queryResult.bot.Name;
            return bookDto;
        }

        public override async Task<PagedResultDto<FileDto>> GetListAsync(FileResultRequestDto input)
        {
            var query = from file in Repository
                        join bot in botRepository on file.BotId equals bot.Id
                        orderby input.Sorting
                        select new { bot, file };
            if (input.BotId.HasValue)
                query = query.Where(q => q.file.BotId.Equals(input.BotId));
            query = query.Skip(input.SkipCount).Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);
            var fileList = queryResult.Select(f =>
            {
                var fileDto = ObjectMapper.Map<File, FileDto>(f.file);
                fileDto.BotName = f.bot.Name;
                return fileDto;
            }).ToList();

            var totalCount = await AsyncExecuter.CountAsync(Repository.WhereIf(input.BotId.HasValue, q => q.BotId.Equals(input.BotId)));

            return new PagedResultDto<FileDto>(
                totalCount,
                fileList
            ); ;
        }

    }
}
