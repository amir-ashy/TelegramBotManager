using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Nikia.TelegramBotManager.BotManager.Validation
{
    public class FileValidator : AbstractValidator<File> , ISingletonDependency
    {
        private readonly IRepository<File> _fileRepository;

        public FileValidator(IRepository<File> fileRepository)
        {
            _fileRepository = fileRepository;
        
            RuleFor(file => file.Code).NotNull().NotEmpty().WithMessage("the file code must be filled");
            RuleFor(file => file).Must(file =>
            {
                return !_fileRepository.Any(fl => fl.BotId.CompareTo(file.BotId) == 0 && fl.Code == file.Code && fl.Id.CompareTo(file.Id)!= 0);
            }).WithMessage("the file code must be unique");
        }
    }

}
