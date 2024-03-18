using dasignoSAS.Context;
using dasignoSAS.Items.Commands.UserFHandler.Params;
using dasignoSAS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dasignoSAS.Items.Commands.UserFHandler.Read
{

    public sealed class UserQueryCommandHandler : IRequestHandler<UserQueryByIdCommand, User>
    {
        private readonly AppDbContext _context;

        public UserQueryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(UserQueryByIdCommand request, CancellationToken cancellationToken)
        {
            return await QueryUser(request, cancellationToken); 
        }
        
        public async Task<User> QueryUser(UserQueryByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            return user ?? throw new Exception("User doesnt exists.");
        }

    }
}
