using Domain.Data;
using Domain.Models;
using MediatR;

namespace Application.Commands.Persons
{
    public class GetPersonCommand : IRequest<IQueryable<Person>>
    {
        public class Handler : IRequestHandler<GetPersonCommand, IQueryable<Person>>
        {
            private readonly DemoContext _context;

            public Handler(DemoContext context)
            {
                _context = context;
            }

            public async Task<IQueryable<Person>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
            {
                return _context.Person.AsQueryable();
            }
        }
    }
}
