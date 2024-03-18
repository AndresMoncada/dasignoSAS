using dasignoSAS.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace dasignoSAS.Items.Commands.UserFHandler.Params
{
    public class UserUpdateCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public decimal? Sueldo { get; set; }
    }
}
