using AutoMapper;
using MediatR;
using SiteManagement.Application.Contracts.Persistence.Repositories.Invoices;
using SiteManagement.Application.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Invoices.GetInvoice
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, IList<InvoiceVm>>
    {
        private readonly IInvoiceRepository _ınvoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository ınvoiceRepository, IMapper mapper)
        {
            _ınvoiceRepository = ınvoiceRepository;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceVm>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _ınvoiceRepository.GetInvoiceById(request.UserId);

            return _mapper.Map<IList<InvoiceVm>>(invoices);
        }
    }
}
