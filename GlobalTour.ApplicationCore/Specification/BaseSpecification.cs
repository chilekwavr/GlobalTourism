using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Specification
{
    public class BaseSpecifcation<T> : ISpecification<T>
    {
        public BaseSpecifcation()
        {
        }

        public BaseSpecifcation(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<Expression<Func<T, bool>>> WhereExpressions { get; } = new List<Expression<Func<T, bool>>>();

        public IEnumerable<(Expression<Func<T, object>> KeySelector, OrderTypeEnum OrderType)> OrderExpressions { get; } =
            new List<(Expression<Func<T, object>> KeySelector, OrderTypeEnum OrderType)>();

        /// <inheritdoc/>
        public IEnumerable<IncludeExpressionInfo> IncludeExpressions { get; } = new List<IncludeExpressionInfo>();

        /// <inheritdoc/>
        public IEnumerable<string> IncludeStrings { get; } = new List<string>();

        /// <inheritdoc/>
        public IEnumerable<(Expression<Func<T, string>> Selector, string SearchTerm, int SearchGroup)> SearchCriterias { get; } =
            new List<(Expression<Func<T, string>> Selector, string SearchTerm, int SearchGroup)>();


        /// <inheritdoc/>
        public int? Take { get; internal set; } = null;

        /// <inheritdoc/>
        public int? Skip { get; internal set; } = null;

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }

    public class IncludeExpressionInfo
    {
        public LambdaExpression LambdaExpression { get; }
        public Type EntityType { get; }
        public Type PropertyType { get; }
        public Type? PreviousPropertyType { get; }
        public IncludeTypeEnum Type { get; }

        private IncludeExpressionInfo(LambdaExpression expression,
                                      Type entityType,
                                      Type propertyType,
                                      Type? previousPropertyType,
                                      IncludeTypeEnum includeType)

        {
            _ = expression ?? throw new ArgumentNullException(nameof(expression));
            _ = entityType ?? throw new ArgumentNullException(nameof(entityType));
            _ = propertyType ?? throw new ArgumentNullException(nameof(propertyType));

            if (includeType == IncludeTypeEnum.ThenInclude)
            {
                _ = previousPropertyType ?? throw new ArgumentNullException(nameof(previousPropertyType));
            }

            this.LambdaExpression = expression;
            this.EntityType = entityType;
            this.PropertyType = propertyType;
            this.PreviousPropertyType = previousPropertyType;
            this.Type = includeType;
        }

        public IncludeExpressionInfo(LambdaExpression expression,
                                     Type entityType,
                                     Type propertyType)
            : this(expression, entityType, propertyType, null, IncludeTypeEnum.Include)
        {
        }

        public IncludeExpressionInfo(LambdaExpression expression,
                                     Type entityType,
                                     Type propertyType,
                                     Type previousPropertyType)
            : this(expression, entityType, propertyType, previousPropertyType, IncludeTypeEnum.ThenInclude)
        {
        }
    }
    public enum IncludeTypeEnum
    {
        Include = 1,
        ThenInclude = 2
    }


    public enum OrderTypeEnum
    {
        OrderBy = 1,
        OrderByDescending = 2,
        ThenBy = 3,
        ThenByDescending = 4
    }
}