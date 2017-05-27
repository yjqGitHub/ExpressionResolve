using System.Linq.Expressions;

namespace JQ.Expressions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ExpressionExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/5/27 17:41:58
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// 判断最子级是否为常量表达式
        /// </summary>
        /// <param name="exp">需要判断的表达式</param>
        /// <returns>true表示是</returns>
        public static bool IsConstantExpression(this Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant)
            {
                return true;
            }
            bool flage = false;
            var checkExp = exp as MemberExpression;
            while (checkExp != null)
            {
                if (checkExp.Expression == null)
                {
                    if (checkExp.NodeType == ExpressionType.Constant)
                    {
                        flage = true;
                    }
                    checkExp = checkExp.Expression as MemberExpression;
                }
                else
                {
                    flage = checkExp.Expression.NodeType == ExpressionType.Constant;
                    checkExp = checkExp.Expression as MemberExpression;
                }
            }
            return flage;
        }

        /// <summary>
        /// 判断最子级是否为参数或者变量表达式
        /// </summary>
        /// <param name="exp">需要判断的表达式</param>
        /// <returns>true表示不是</returns>
        public static bool IsNotParameterExpression(this Expression exp)
        {
            if (exp.NodeType == ExpressionType.Parameter)
            {
                return false;
            }
            bool flage = true;
            var checkExp = exp as MemberExpression;
            while (checkExp != null && checkExp.Expression != null)
            {
                if (checkExp.Expression.NodeType == ExpressionType.Parameter)
                {
                    flage = false;
                    break;
                }
                checkExp = checkExp.Expression as MemberExpression;
            }
            return flage;
        }

        /// <summary>
        /// 将表达式通过调用方法转为常量表达式
        /// </summary>
        /// <param name="exp">要转换的表示</param>
        /// <returns></returns>
        public static ConstantExpression ToConstantExpression(this Expression exp)
        {
            var memberValue = Expression.Lambda(exp).Compile().DynamicInvoke();
            return Expression.Constant(memberValue);
        }
    }
}