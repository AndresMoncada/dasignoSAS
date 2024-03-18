using dasignoSAS.Context;
using dasignoSAS.Items.Commands.UserFHandler.Params;
using dasignoSAS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace dasignoSAS.Items.Commands.UserFHandler.Create
{
    public sealed class UserInsCommandHandler : IRequestHandler<UserInsCommand, bool>
    {
        private readonly AppDbContext _context;

        public UserInsCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UserInsCommand request, CancellationToken cancellationToken)
        {
            return await CreateUser(request, cancellationToken);
        }

        public async Task<bool> CreateUser(UserInsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    PrimerNombre = request.PrimerNombre,
                    SegundoNombre = request.SegundoNombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    FechaNacimiento = request.FechaNacimiento,
                    Sueldo = request.Sueldo,
                    FechaCrea = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {   
                return false;
            }

            return true;
        }
    }  
}
