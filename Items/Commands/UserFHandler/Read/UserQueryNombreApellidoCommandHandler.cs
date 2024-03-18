using dasignoSAS.Context;
using dasignoSAS.Items.Commands.UserFHandler.Params;
using dasignoSAS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dasignoSAS.Items.Commands.UserFHandler.Read
{
    public sealed class UserQueryNombreApellidoCommandHandler(AppDbContext context) : IRequestHandler<UserQueryByNombreApellidoCommand, IEnumerable<User>>
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<User>> Handle(UserQueryByNombreApellidoCommand request, CancellationToken cancellationToken)
        {
            return await QueryUser(request, cancellationToken);
        }

        public async Task<IEnumerable<User>> QueryUser(UserQueryByNombreApellidoCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.PrimerNombre))
            {
                query = query.Where(u => u.PrimerNombre.Contains(request.PrimerNombre));
            }

            if (!string.IsNullOrEmpty(request.PrimerApellido))
            {
                query = query.Where(u => u.PrimerApellido.Contains(request.PrimerApellido));
            }

            var skip = (request.Pagina - 1) * request.CantidadPorPagina;
            var users = await query.Skip(skip).Take(request.CantidadPorPagina).ToListAsync(cancellationToken);

            return users;
        }
    }
}
