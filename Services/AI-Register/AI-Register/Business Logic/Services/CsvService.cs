using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Entities;

namespace BusinessLogic.Services
{
    public class CsvService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IAISystemRepository _aiSystemRepository;
        public CsvService(IProviderRepository providerRepository, IAISystemRepository aiSystemRepository)
        {
            _providerRepository = providerRepository;
            _aiSystemRepository = aiSystemRepository;
        }

        public async Task<Byte[]> GetAllFiles()
        {
          List<AISystemEntity> aiSystemEntities = await _aiSystemRepository.GetAiSystemEntities();
          CsvAiSystemCreationObject csvAiSystemCreationObject = new CsvAiSystemCreationObject();
          List<CsvAiSystemCreationObject> aiSystemList = new List<CsvAiSystemCreationObject>();

          foreach (AISystemEntity aisystemEntity in aiSystemEntities)
          {
              Provider provider = new Provider(aisystemEntity.ProviderEntity.Id, aisystemEntity.ProviderEntity.Name, aisystemEntity.ProviderEntity.Address,aisystemEntity.ProviderEntity.Email,aisystemEntity.ProviderEntity.PhoneNumber);
              csvAiSystemCreationObject = new CsvAiSystemCreationObject(aisystemEntity, provider);
              aiSystemList.Add(csvAiSystemCreationObject);
          }
          Byte[] result = FileContentResult(aiSystemList);
            return result;
        }

        public async Task<Byte[]> getFileByProvider(Guid providerId)
        {
            ProviderEntity pe = await _providerRepository.GetProviderById(providerId);
            Provider provider = new Provider(pe.Id,pe.Name,pe.Address,pe.Email,pe.PhoneNumber);
            List<CsvAiSystemCreationObject> aiSystemList = new List<CsvAiSystemCreationObject>();

            foreach (AISystemEntity aisystemEntity in pe.aISystemEntity)
            {
              
                CsvAiSystemCreationObject csvAiSystemCreationObject = new CsvAiSystemCreationObject(aisystemEntity, provider);
                aiSystemList.Add(csvAiSystemCreationObject);
            }
            Byte[] result = FileContentResult(aiSystemList);
            return result;
        }


        public static Byte[] FileContentResult(List<CsvAiSystemCreationObject> AISystemList)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                writer.WriteLine("sep=,");
                csv.WriteRecords(AISystemList);
                writer.Flush();
                memoryStream.Position = 0;

                return memoryStream.ToArray();

            }
        }
    }
}
