using dasignoSAS.Models;
using MediatR;

namespace dasignoSAS.Items.Commands.UserFHandler.Params
{
    public class UserQueryByIdCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
