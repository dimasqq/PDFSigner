using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using PDFSigner.Data;
using PDFSigner.Managers.Interfaces;

namespace PDFSigner.Managers
{
    public class BaseManager : IBaseManager
    {
        protected readonly Context context;
        private IDbContextTransaction transaction;
        public BaseManager(
            Context context,
            IMapper mapper
        )
        {
            this.context = context;
        }

        public async Task BeginTransactionAsync()
        {
            transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (transaction == null)
            {
                throw new Exception("Transaction is null");
            }

            await transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (transaction == null)
            {
                throw new Exception("Transaction is null");
            }

            await transaction.RollbackAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
