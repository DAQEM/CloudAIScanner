﻿using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services;

public class AISystemService
{
    public IAISystemRepository AiSystemRepository;

    public AISystemService(IAISystemRepository aiSystemRepository)
    {
        AiSystemRepository = aiSystemRepository;
    }

    public void AddAiSystem(AISystem aiSystem)
    {
        
        CertificateEntity certificateEntity = new CertificateEntity();
        certificateEntity.Number = aiSystem.certificate.Number;
        certificateEntity.Type = aiSystem.certificate.Type;
        
        ScanCertificateEntity scanCertificateEntity = new ScanCertificateEntity();
        scanCertificateEntity.Id = aiSystem.certificate.ScanCertificate.guid;
        certificateEntity.ScanCertificate = scanCertificateEntity;
        certificateEntity.ExpiryDate = aiSystem.certificate.ExpiryDate;
        certificateEntity.NameNotifiedBody = aiSystem.certificate.NameNotifiedBody;
        certificateEntity.IdNotifiedBody = aiSystem.certificate.IdNotifiedBody;
        
        AISystemEntity aiSystemEntity = new AISystemEntity();
        aiSystemEntity.Name = aiSystem.Name;
        aiSystemEntity.Status = aiSystem.Status;
        aiSystemEntity.URL = aiSystem.URL;
        aiSystemEntity.TechnicalDocumentationLink = aiSystem.TechnicalDocumentationLink;
        aiSystemEntity.DateAdded = DateOnly.FromDateTime(DateTime.Now);
        aiSystemEntity.ApprovalStatus = 0;
        aiSystemEntity.CertificateEntity = certificateEntity;
        aiSystemEntity.ProviderId = aiSystem.provider.guid;
        
        AiSystemRepository.AddSystemAI(aiSystemEntity);
    }
    public void AddAiSystems(List<AISystem> aiSystems)
    {
        foreach (AISystem aiSystem in aiSystems)
        {
            CertificateEntity certificateEntity = new CertificateEntity();
            certificateEntity.Number = aiSystem.certificate.Number;
            certificateEntity.Type = aiSystem.certificate.Type;
        
            ScanCertificateEntity scanCertificateEntity = new ScanCertificateEntity();
            scanCertificateEntity.Id = aiSystem.certificate.ScanCertificate.guid;
            certificateEntity.ScanCertificate = scanCertificateEntity;
            certificateEntity.ExpiryDate = aiSystem.certificate.ExpiryDate;
            certificateEntity.NameNotifiedBody = aiSystem.certificate.NameNotifiedBody;
            certificateEntity.IdNotifiedBody = aiSystem.certificate.IdNotifiedBody;
        
            AISystemEntity aiSystemEntity = new AISystemEntity();
            aiSystemEntity.Name = aiSystem.Name;
            aiSystemEntity.Status = aiSystem.Status;
            aiSystemEntity.URL = aiSystem.URL;
            aiSystemEntity.TechnicalDocumentationLink = aiSystem.TechnicalDocumentationLink;
            aiSystemEntity.DateAdded = DateOnly.FromDateTime(DateTime.Now);
            aiSystemEntity.ApprovalStatus = 0;
            aiSystemEntity.CertificateEntity = certificateEntity;
            aiSystemEntity.ProviderId = aiSystem.provider.guid;
        
            AiSystemRepository.AddSystemAI(aiSystemEntity);
        }
    }
}