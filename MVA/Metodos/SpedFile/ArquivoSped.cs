using BLL.Model;
using DAL;
using NOTAS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NOTAS.Metodos.SpedFile
{
    public class ArquivoSped
    {

        // 0 - Entrada
        // 1- Saída

        public static Informacoes RetornaPeriodo(string pathFile)
        {
            return (from sped in File.ReadAllLines(pathFile)
                    .Take(1)
                    let splitFirstLine = sped.Split('|')
                    select new Informacoes
                    {
                        Periodo = splitFirstLine[4],
                        Cnpj = splitFirstLine[7]

                    }).FirstOrDefault();

        }

        public static List<Notas> RetonaChaves(string pathFile, string parametro)
        {

            string tipoDeNota = parametro.Equals("Entrada") ? "0" : "1";

            List<Notas> listaDeChaves = new List<Notas>();

            var splitC100 = (from sped in File.ReadAllLines(pathFile)
                             where sped.StartsWith("|C100|")
                             let splitFileLines = sped.Split('|')
                             select new
                             {
                                 Ind_Oper = splitFileLines[2],
                                 Chave = splitFileLines[9]

                             }).Where(x => x.Ind_Oper.Equals(tipoDeNota)).ToList();


            foreach (var c100 in splitC100)
            {

                if (string.IsNullOrEmpty(c100.Chave))
                {
                    continue;
                }

                var hasChaveExists = listaDeChaves.Any(x => x.Chave == c100.Chave);
                if (hasChaveExists == true)
                {
                    continue;
                }

                listaDeChaves.Add(new Notas
                {
                    Existe = false,
                    Chave = c100.Chave,
                });

            }

            return listaDeChaves;

        }

        public static FileInfo RetornaArquivoSpedNoRepositorio(string pathFile)
        {
            return UploadFolderRepository
            .GetAllFilesInDirectory(pathFile)
            .FirstOrDefault();
        }

    }
}