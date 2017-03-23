using System;
using System.ComponentModel;

namespace Models
{
    public class CorridaModel
    {
        [DisplayName("Hora")]
        public TimeSpan Hora { get; set; }

        [DisplayName("Código Piloto")]
        public string CodigoPiloto { get; set; }

        [DisplayName("Piloto")]
        public string Piloto { get; set; }

        [DisplayName("Nº Volta")]
        public Int32 NumeroVolta { get; set; }

        [DisplayName("Tempo Volta")]
        public TimeSpan TempoVolta { get; set; }

        [DisplayName("Velocidade média da volta")]
        public string VelocidadeMedia { get; set; }
    }
}
