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

namespace SiteManagement.Application.Features.Queries.Invoices.GetInvoices
{
    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, IList<InvoiceVm>>
    {
        private readonly IInvoiceRepository _ınvoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceListQueryHandler(IInvoiceRepository ınvoiceRepository, IMapper mapper)
        {
            _ınvoiceRepository = ınvoiceRepository;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceVm>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _ınvoiceRepository.GetInvoiceList();

            return _mapper.Map<IList<InvoiceVm>>(invoices);
        }
    }
}
