using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repositories;

        public UpdateAboutCommandHandler(IRepository<About> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var values= await _repositories.GetByIdAsync(command.AboutID);

            values.Description = command.Description;
            values.Title = command.Title;
            values.ImageUrl= command.ImageUrl;

            await _repositories.UpdateAsync(values);

        }
    }
}
