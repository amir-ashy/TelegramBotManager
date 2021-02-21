using Microsoft.AspNetCore.Authorization;
using Nikia.TelegramBotManager.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Nikia.TelegramBotManager.BotManager
{
    [Authorize]
    public class BotService : CrudAppService<Bot, BotDto, Guid>, IBotService
    {
        public BotService(IRepository<Bot, Guid> repository) : base(repository)
        {

            GetPolicyName = TelegramBotManagerPermissions.Bots.Default;
            GetListPolicyName = TelegramBotManagerPermissions.Bots.Default;
            CreatePolicyName = TelegramBotManagerPermissions.Bots.Create;
            UpdatePolicyName = TelegramBotManagerPermissions.Bots.Edit;
            DeletePolicyName = TelegramBotManagerPermissions.Bots.Delete;
        }
        public override async Task<BotDto> CreateAsync(BotDto input)
        {
            await AssignServicePath(input);
            return await base.CreateAsync(input);
        }

        public async Task AssignServicePath(BotDto input)
        {
            var allBotList= await Repository.GetListAsync();
            allBotList.RemoveAll(bot => bot.Id == input.Id);
            if (input.ServerPathId.IsNullOrEmpty())
            {
                for (int i = 1; i < 10; i++)
                {
                    if(!allBotList.Where(bot => !bot.ServerPathId.IsNullOrEmpty()).Any(bot => bot.ServerPathId.CompareTo($"service{i}") == 0))
                    {
                        input.ServerPathId = $"servicePath{i}";
                        return;
                    }
                }
            }
        }

        public override async Task<BotDto> UpdateAsync(Guid id, BotDto input)
        {
            await AssignServicePath(input);
            return await base.UpdateAsync(id, input);
        }

    }

}

