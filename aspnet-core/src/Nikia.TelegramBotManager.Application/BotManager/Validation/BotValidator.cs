using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikia.TelegramBotManager.BotManager.Validation
{
    public class BotValidator : AbstractValidator<Bot>
    {
      
        public BotValidator()
        {
            RuleFor(bot => bot.Name).Must((str) =>
            {
                return true;
            });
        }
    }
}
