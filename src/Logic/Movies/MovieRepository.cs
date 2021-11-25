﻿using CSharpFunctionalExtensions;
using Logic.Utils;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Movies
{
    public class MovieRepository
    {
        public Maybe<Movie> GetOne(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<Movie>(id);
            }
        }

        public IReadOnlyList<Movie> GetList(Specification<Movie> specification, double minimumRating, int page = 0, int pageSize = 4)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Movie>()
                    .Where(specification.ToExpression())
                    .Where(x => x.Rating >= minimumRating)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        public IQueryable<Movie> Find()
        {
            ISession session = SessionFactory.OpenSession();
            return session.Query<Movie>();
            
        }
    }
}
