using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;


namespace MetricsManager.Dto
{
    public class AgentIdRequestDto
    {
        [BindRequired]
        public string Id { get; set; }
    }
}
