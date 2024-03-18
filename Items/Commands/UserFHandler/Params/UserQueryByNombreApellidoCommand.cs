using dasignoSAS.Models;
using MediatR;

namespace dasignoSAS.Items.Commands.UserFHandler.Params
{
    public class UserQueryByNombreApellidoCommand : IRequest<IEnumerable<User>>
    {
        public string? PrimerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public int Pagina { get; set; }
        public int CantidadPorPagina { get; set; }
    }

}
