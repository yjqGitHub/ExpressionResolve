using System;
using System.Collections.Generic;
using System.Data;

namespace JQ.Expressions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TypeUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/5/27 17:39:40
    /// </summary>
    public static class TypeUtil
    {
        private static Dictionary<RuntimeTypeHandle, DbType> _typeMap;
        static TypeUtil()
        {
            _typeMap = new Dictionary<RuntimeTypeHandle, DbType>
            {
                [typeof(byte).TypeHandle] = DbType.Byte,
                [typeof(sbyte).TypeHandle] = DbType.SByte,
                [typeof(short).TypeHandle] = DbType.Int16,
                [typeof(ushort).TypeHandle] = DbType.UInt16,
                [typeof(int).TypeHandle] = DbType.Int32,
                [typeof(uint).TypeHandle] = DbType.UInt32,
                [typeof(long).TypeHandle] = DbType.Int64,
                [typeof(ulong).TypeHandle] = DbType.UInt64,
                [typeof(float).TypeHandle] = DbType.Single,
                [typeof(double).TypeHandle] = DbType.Double,
                [typeof(decimal).TypeHandle] = DbType.Decimal,
                [typeof(bool).TypeHandle] = DbType.Boolean,
                [typeof(string).TypeHandle] = DbType.String,
                [typeof(char).TypeHandle] = DbType.StringFixedLength,
                [typeof(Guid).TypeHandle] = DbType.Guid,
                [typeof(DateTime).TypeHandle] = DbType.DateTime,
                [typeof(DateTimeOffset).TypeHandle] = DbType.DateTimeOffset,
                [typeof(TimeSpan).TypeHandle] = DbType.Time,
                [typeof(byte[]).TypeHandle] = DbType.Binary,
                [typeof(byte?).TypeHandle] = DbType.Byte,
                [typeof(sbyte?).TypeHandle] = DbType.SByte,
                [typeof(short?).TypeHandle] = DbType.Int16,
                [typeof(ushort?).TypeHandle] = DbType.UInt16,
                [typeof(int?).TypeHandle] = DbType.Int32,
                [typeof(uint?).TypeHandle] = DbType.UInt32,
                [typeof(long?).TypeHandle] = DbType.Int64,
                [typeof(ulong?).TypeHandle] = DbType.UInt64,
                [typeof(float?).TypeHandle] = DbType.Single,
                [typeof(double?).TypeHandle] = DbType.Double,
                [typeof(decimal?).TypeHandle] = DbType.Decimal,
                [typeof(bool?).TypeHandle] = DbType.Boolean,
                [typeof(char?).TypeHandle] = DbType.StringFixedLength,
                [typeof(Guid?).TypeHandle] = DbType.Guid,
                [typeof(DateTime?).TypeHandle] = DbType.DateTime,
                [typeof(DateTimeOffset?).TypeHandle] = DbType.DateTimeOffset,
                [typeof(TimeSpan?).TypeHandle] = DbType.Time,
                [typeof(object).TypeHandle] = DbType.Object
            };
        }

        #region 根据类型对应类型获取对应数据库对应的类型

        /// <summary>
        /// 根据类型对应类型获取对应数据库对应的类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>数据库对应的类型</returns>
        public static DbType Type2DbType(Type type)
        {
            if (_typeMap.ContainsKey(type.TypeHandle))
            {
                return _typeMap[type.TypeHandle];
            }
            else
            {
                return DbType.Object;
            }
        }

        #endregion 根据类型对应类型获取对应数据库对应的类型

        /// <summary>
        /// 判断类型是否为集合或者数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsArrayOrCollection(this Type type)
        {
            if (type == null) return false;
            return type.IsArray || type.IsGenericType;
        }
    }
}