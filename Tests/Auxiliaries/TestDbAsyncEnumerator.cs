using System.Data.Entity.Infrastructure;

namespace Tests.Auxiliaries
{
    public class TestDbAsyncEnumerator<TEntity> : IDbAsyncEnumerator<TEntity>
    {
        private readonly IEnumerator<TEntity> _inner;

        public TestDbAsyncEnumerator(IEnumerator<TEntity> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            // Do not dispose the inner enumerator, since it might be enumerated again, 
            // reset it instead
            _inner.Reset();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public TEntity Current
        {
            get { return _inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }
}