using System;
using System.ComponentModel;

namespace Models
{
    public class RankModel
    {
        [DisplayName("Posição Chegada")]
        public long Posicao { get; set; }

        [DisplayName("Código Piloto")]
        public string CodigoPiloto { get; set; }

        [DisplayName("Nome Piloto")]
        public string NomePiloto { get; set; }

        [DisplayName("Qtde Voltas Completadas")]
        public long QtdVoltas { get; set; }

        [DisplayName("Tempo Total de Prova")]
        public TimeSpan TempoTotal { get; set; }

        [DisplayName("Melhor Volta")]
        public TimeSpan MelhorVolta { get; set; }

        [DisplayName("Velocidade Média")]
        public TimeSpan VelocidadeMedia { get; set; }

        [DisplayName("Tempo Atraso")]
        public TimeSpan TempoAtraso { get; set; }



    }
}