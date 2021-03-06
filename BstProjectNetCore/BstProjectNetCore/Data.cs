using BstProjectNetCore.Models;
using System;
using System.IO;
using System.Linq;

namespace BstProjectNetCore
{
    public static class Data
    {
        public static Hierarchy ReadData(string path)
        {
            var datas = File.ReadAllLines(path).Where(_ => !_.Contains("|"));
            var hierarchy = new Hierarchy { TotalRoots = datas.Count() };

            foreach (var data in datas)
            {
                var dataSplitted = data.Split(';');

                if (Convert.ToChar(dataSplitted.Last()) == 'E')
                {
                    hierarchy.Index = (Convert.ToInt32(dataSplitted[0]), Convert.ToInt32(dataSplitted[1]), dataSplitted[2], Convert.ToChar(dataSplitted[3]));
                    continue;
                }

                hierarchy.SubIndex.Add((Convert.ToInt32(dataSplitted[0]), Convert.ToInt32(dataSplitted[1]), dataSplitted[2], Convert.ToChar(dataSplitted[3])));
            }

            return hierarchy;
        }
    }
}
