using MovieMania.Core.Contracts;
using MovieMania.Infrastructure.Data.Common;

namespace MovieMania.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork unitOfWork;

        public ActorService(IUnitOfWork _unitOfWork)
        {
                unitOfWork = _unitOfWork;
        }
    }
}
