using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Controllers.Dto;
using System.Threading;
using MetricsAgent.Models.Domain.Services;
using MetricsAgent.DAL.Models;
using MapsterMapper;

namespace MetricsAgent.Mediatr.Handlers
{
    public class GetCPUMetricsQueryHandler : IRequestHandler<GetCPUMetricsQuery, IReadOnlyCollection<CPUMetricsResponceDto>>
    {
        private readonly IGetMetricsRepository<CPUMetricsDAL> _repository;
        private readonly IMapper _mapper;

        public GetCPUMetricsQueryHandler(IGetMetricsRepository<CPUMetricsDAL> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task<IReadOnlyCollection<CPUMetricsResponceDto>> Handle(GetCPUMetricsQuery request, CancellationToken cancellationToken)
        {
            var x = _mapper.Map<CPUMetricsDAL>(request);
        }
    }
}
