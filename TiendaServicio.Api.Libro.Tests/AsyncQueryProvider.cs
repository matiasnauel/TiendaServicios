﻿using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TiendaServicio.Api.Libro.Tests
{
    public class AsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _provider;

        public AsyncQueryProvider(IQueryProvider provider)
        {
            _provider = provider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new AsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new AsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _provider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _provider.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
        {
            var resultadoTipo = typeof(TResult).GetGenericArguments()[0];
            var ejecucionResultado = typeof(IQueryProvider)
                .GetMethod(
                 name: nameof(IQueryProvider.Execute),
                 genericParameterCount: 1,
                 types: new[] { typeof(Expression) })
                .MakeGenericMethod(resultadoTipo)
                .Invoke(this, new[] { expression });
            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))?
                .MakeGenericMethod(resultadoTipo).Invoke(null, new[] {ejecucionResultado });
        }
    }
}
