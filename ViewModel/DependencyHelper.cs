using System.Linq.Expressions;
using System.Reflection;
using System.Windows;

namespace MottSchottkyAnalizer.Core.ViewModel;

public static class DependencyHelper<TOwner>
{
    public static DependencyProperty Register<TProperty>(
        Expression<Func<TOwner, TProperty>> expression)
    {
        return Register(expression, new PropertyMetadata(default(TProperty)));
    }

    public static DependencyProperty Register<TProperty>(
        Expression<Func<TOwner, TProperty>> expression,
        PropertyMetadata metadata)
    {
        MemberInfo memberInfo = GetMemberInfo(expression);
        return DependencyProperty.Register(
            memberInfo.Name,
            typeof(TProperty),
            typeof(TOwner),
            metadata);
    }

    private static MemberInfo GetMemberInfo<TProperty>(
        Expression<Func<TOwner, TProperty>> expression)
    {
        if (expression.Body is MemberExpression memberExpression)
        {
            return memberExpression.Member;
        }

        if (expression.Body is UnaryExpression unaryExpression &&
            unaryExpression.Operand is MemberExpression unaryMemberExpression)
        {
            return unaryMemberExpression.Member;
        }

        throw new ArgumentException("Expression must point to a property.", nameof(expression));
    }
}
