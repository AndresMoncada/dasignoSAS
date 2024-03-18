using dasignoSAS.Context;
using dasignoSAS.Items.Commands.UserFHandler.Params;
using dasignoSAS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dasignoSAS.Items.Commands.UserFHandler.Read
{

    public sealed class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, bool>
    {
        private readonly AppDbContext _context;

        public UserUpdateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            return await DeleteUser(request, cancellationToken); 
        }
        
        public async Task<bool> DeleteUser(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken) ?? throw new Exception("User doesnt exists.");

            user.PrimerNombre = request.PrimerNombre ?? user.PrimerNombre;
            user.SegundoNombre = request.SegundoNombre ?? user.SegundoNombre;
            user.PrimerApellido = request.PrimerApellido ?? user.PrimerApellido;
            user.SegundoApellido = request.SegundoApellido ?? user.SegundoApellido;
            user.FechaNacimiento = request.FechaNacimiento ?? user.FechaNacimiento;
            user.Sueldo = request.Sueldo ?? user.Sueldo;
            user.FechaModifica = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
