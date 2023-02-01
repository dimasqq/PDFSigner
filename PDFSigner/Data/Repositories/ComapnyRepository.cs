using PDFSigner.Data.Entities;
using PDFSigner.Data.Repositories.Interfaces;

namespace PDFSigner.Data.Repositories
{
    public class ComapnyRepository : BaseRepository<Company, Context>, ICompanyRepository
    {
        public ComapnyRepository(Context context) : base(context)
        {
        }
    }
}
