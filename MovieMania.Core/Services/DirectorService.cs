using MovieMania.Core.Contracts;
using MovieMania.Infrastructure.Data.Common;

namespace MovieMania.Core.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IUnitOfWork unitOfWork;

        public DirectorService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}
