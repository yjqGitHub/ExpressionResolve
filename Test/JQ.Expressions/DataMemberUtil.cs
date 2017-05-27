using System;

namespace JQ.Expressions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DataMemberUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/5/27 17:41:36
    /// </summary>
    public static class DataMemberUtil
    {
        /// <summary>
        /// 将两个数据成员按照类型是否为Key类型排序
        /// </summary>
        /// <param name="member1"></param>
        /// <param name="member2"></param>
        /// <returns>item1是值类型或者非值类型</returns>
        public static Tuple<DataMember, DataMember> GetKeyMember(DataMember member1, DataMember member2)
        {
            if ((member2 != null && member2.MemberType == DataMemberType.Key) && (member1 == null || (member1.MemberType != DataMemberType.Key)))
            {
                return Tuple.Create(member2, member1);
            }
            return Tuple.Create(member1, member2);
        }

        public static bool IsValue(this DataMember member)
        {
            if (member == null)
            {
                return false;
            }
            return member.MemberType == DataMemberType.Value;
        }

        /// <summary>
        /// 判断类型是否为集合或者数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsArrayOrCollection(this DataMember member)
        {
            if (member == null || member.Value == null) return false;
            return member.Value.GetType().IsArrayOrCollection();
        }
    }
}