using Domain.Data;
using Domain.Models;
using MediatR;

namespace Application.Commands.Persons
{
    public class CreatePersonCommand : IRequest<Person>
    {
        public Person Person { get; set; } = null!; 

        public class Handler : IRequestHandler<CreatePersonCommand, Person>
        {
            private readonly DemoContext _context;

            public Handler(DemoContext context)
            {
                _context = context;
            }

            public async Task<Person> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
            {
                await _context.Person.AddAsync(command.Person, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return command.Person;
            }
        }
    }
}
