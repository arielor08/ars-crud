using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfiliateDataAccess.Models
{
    public class Afiliados
    {
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Cedula { get; set; }
        public string Estatus { get; set; }
        public int MontoRestante { get; set; }
        public string NSS { get; set; }
        [DisplayName("Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [DisplayName("Monto Consumido")]
        public int MontoConsumido { get; set; }

        public int? IdEstatus { get; set; }

        public int? IdPlan { get; set; }
    }
}
