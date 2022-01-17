using NOTAS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NOTAS.Metodos.TxtFile
{
    public class TxtComChaves
    {
        public static List<Notas> RetonaChaves(string pathFile)
        {

            List<Notas> listaDeChaves = new List<Notas>();

            var splitFile = (from sped in File.ReadAllLines(pathFile)
                             select new
                             {
                                 Chave = sped
                             }).ToList();

            foreach (var file in splitFile)
            {

                if (string.IsNullOrEmpty(file.Chave))
                {
                    continue;
                }
                var hasChaveExists = listaDeChaves.Any(x => x.Chave == file.Chave);
                if (hasChaveExists == true)
                {
                    continue;
                }

                listaDeChaves.Add(new Notas
                {
                    Existe = false,
                    Chave = file.Chave,
                });

            }

            return listaDeChaves;

        }

    }
}