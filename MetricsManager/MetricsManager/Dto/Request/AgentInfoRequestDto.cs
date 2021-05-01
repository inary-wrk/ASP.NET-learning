using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MetricsManager.Dto
{
    public class AgentInfoRequestDto
    {
        [BindRequired]
        public string Id { get; set; }
        [BindRequired]
        public Uri Address { get; set; }
    }
}
