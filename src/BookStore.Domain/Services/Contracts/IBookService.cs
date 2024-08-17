﻿using BookStore.Aggregates.Comment;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace BookStore.Services.Contracts
{
    public interface IBookService : IDomainService, IScopedDependency
    {
        public double GetBookRating(List<Comment> comments);
    }
}
