using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlogPlatform.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BlogContext _context;
        private IDbContextTransaction _currentTransaction;
        private readonly UserManager<User> _userManager;

        public UnitOfWork(BlogContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            Posts = new PostRepository(_context);
            Users = new UserRepository(_context, _userManager);
            Comments = new CommentRepository(_context);
            Categories = new CategoryRepository(_context);
            Tags = new TagRepository(_context);
        }

        public IPostRepository Posts { get; }
        public IUserRepository Users { get; }
        public ICommentRepository Comments { get; }
        public ICategoryRepository Categories { get; }
        public ITagRepository Tags { get; }
        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("There is already an active transaction");
            }

            _currentTransaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("No active transaction to commit");
            }

            try
            {
                _context.SaveChanges();
                _currentTransaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("No active transaction to rollback");
            }

            try
            {
                _currentTransaction.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Dispose()
        {
            _currentTransaction?.Dispose();
            _context.Dispose();
        }
    }
} 