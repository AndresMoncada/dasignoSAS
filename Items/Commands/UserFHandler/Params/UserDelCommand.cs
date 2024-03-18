using MediatR;

namespace dasignoSAS.Items.Commands.UserFHandler.Params
{
    public class UserDelCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
