using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Datos.Entidades
{

    public class PrestamoDTO
    {
        public int IdPrestamo { get; set; }
        public string CantidadLibros { get; set; }
        public string EstadoPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime Devolucion { get; set; }


        public UsuarioDTO Usuario { get; set; }
    }

    public class JsonStringDateConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "dd-MM-yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), DateFormat, CultureInfo.InvariantCulture);
        }


        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }

    }
}