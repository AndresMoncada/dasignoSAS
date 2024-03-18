using dasignoSAS.Context;
using dasignoSAS.Items.Commands.UserFHandler.Params;
using dasignoSAS.Models;
using MediatR;

namespace dasignoSAS.Items.Commands.UserFHandler.Delete
{

    public sealed class UserDelCommandHandler : IRequestHandler<UserDelCommand, bool>
    {
        private readonly AppDbContext _context;

        public UserDelCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UserDelCommand request, CancellationToken cancellationToken)
        {
            return await DeleteUser(request, cancellationToken);
        }

        public async Task<bool> DeleteUser(UserDelCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            
            if (user == null)
            {
                throw new Exception("User doesnt exists.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
         }

    } 
}
        
