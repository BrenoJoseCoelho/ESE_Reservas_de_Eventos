﻿namespace Promocoes.Dtos
{
    public class PromotionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public Guid CampaignId { get; set; }
    }
}