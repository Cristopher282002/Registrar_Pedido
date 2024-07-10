using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace ProyectoPedidos.Models
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del cliente es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El telefono del cliente es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La descripcion del pedido es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El monto del pedido es obligatorio")]
        [Range(10, 200, ErrorMessage = "El monto es entre 10 a 200")]
        public int Monto { get; set; }
    }
}
