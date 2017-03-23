using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class RankBusiness
    {
        /// <summary>
        /// Metodo que ira montar a lista de retorno
        /// </summary>
        /// <returns></returns>
        public static List<RankModel> CalcularVoltas(string[] allLines)
        {
            var result = (from p in ConverterLista(allLines)
                          group p by new { p.CodigoPiloto, p.Piloto } into g
                          select new RankModel
                          {
                              CodigoPiloto = g.Key.CodigoPiloto,
                              NomePiloto = g.Key.Piloto,
                              QtdVoltas = g.Count(),
                              TempoTotal = g.Aggregate(new TimeSpan(), (sum, total) => sum.Add(total.TempoVolta)),
                              MelhorVolta = g.Min(x => x.TempoVolta)
                          }).ToList();

            //montar classificação

            var melhorTempoTotal = result.OrderBy(p => p.TempoTotal).FirstOrDefault()?.TempoTotal ?? TimeSpan.MinValue;
            var listaClassificacao = new List<RankModel>();
            var posicao = 1;
            foreach (var item in result.OrderBy(p => p.TempoTotal).ToList())
            {
                listaClassificacao.Add(new RankModel
                {
                    Posicao = posicao,
                    CodigoPiloto = item.CodigoPiloto,
                    NomePiloto = item.NomePiloto,
                    QtdVoltas = item.QtdVoltas,
                    TempoTotal = item.TempoTotal,
                    MelhorVolta = item.MelhorVolta,
                    TempoAtraso = melhorTempoTotal - item.TempoTotal
                });
                posicao++;
            }
            return listaClassificacao;
        }

        /// <summary>
        /// Metodo para converter o arquivo txt numa lista tipado
        /// </summary>
        /// <param name="allLines"></param>
        /// <returns></returns>
        public static List<CorridaModel> ConverterLista(string[] allLines)
        {
            var list = new List<CorridaModel>();

            for (var i = 1; i < allLines.Count(); i++)
            {
                var tagsSplit = allLines[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(s => s.Trim()).ToArray();

                var model = new CorridaModel
                {
                    Hora = TimeSpan.Parse(tagsSplit[0]),
                    CodigoPiloto = tagsSplit[1].Split('–')[0].Trim(),
                    Piloto = tagsSplit[1].Split('–')[1].Trim(),
                    NumeroVolta = Convert.ToInt32(tagsSplit[2]),
                    TempoVolta = TimeSpan.Parse($"{"00"}:{tagsSplit[3]}"),
                    VelocidadeMedia = tagsSplit[4]
                };
                list.Add(model);
            }

            return list.ToList();
        }

        public static TimeSpan Melhortempo(List<RankModel> result)
        {
            return result.Min(m => m.MelhorVolta);
        }
    }
}
