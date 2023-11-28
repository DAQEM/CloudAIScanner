using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;

namespace BusinessLogic.Services
{
    public static class CsvService
    {


        public static Byte[] FileContentResult(List<CsvAiSystemCreationObject> AISystemList)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(AISystemList);
                writer.Flush();
                memoryStream.Position = 0;

                return memoryStream.ToArray();

            }
        }
    }
}
