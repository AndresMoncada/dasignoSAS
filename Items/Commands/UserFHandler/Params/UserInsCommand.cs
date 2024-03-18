using dasignoSAS.Models;
using MediatR;

namespace dasignoSAS.Items.Commands.UserFHandler.Params
{
    public class UserInsCommand: User, IRequest<bool>
    {
    }
}
