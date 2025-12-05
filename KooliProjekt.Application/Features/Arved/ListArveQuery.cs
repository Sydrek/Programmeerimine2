using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Arved
{
    public class ListArveQuery : IRequest<OperationResult<PagedResult<ArveList>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
