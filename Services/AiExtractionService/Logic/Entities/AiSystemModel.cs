﻿using logic.Models;

namespace logic.Entities;

public class AiSystemModel
{
    public string TradeName { get; set; } = null!;
    public string UnambiguousReference { get; set; } = null!;
    public string Description { get; set; } = null!;
    public AiSystemProvider Provider { get; set; } = null!;
    public AiSystemRepresentative? Representative { get; set; } = null!;
    public AiStatus AiStatus { get; set; } = AiStatus.OnTheMarket | AiStatus.InService;
    public RegistrationStatus RegistrationStatus { get; set; } = RegistrationStatus.Pending;
}