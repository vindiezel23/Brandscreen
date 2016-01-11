using System;
using MongoDB.Bson;

namespace Brandscreen.Core.Services
{
    /// <summary>
    /// IdentityValue is 24 digit hex string.
    /// </summary>
    [Serializable]
    public struct IdentityValue : IEquatable<string>, IEquatable<Guid>, IEquatable<ObjectId>, IConvertible
    {
        public string Value { get; }

        private IdentityValue(string value)
        {
            Value = value;
        }

        public IdentityValue(Guid val)
            : this(val.ToString("N").Substring(0, 24))
        {
        }

        public IdentityValue(ObjectId val)
            : this(val.ToString())
        {
        }

        public bool Equals(string other)
        {
            return string.Equals(Value, other, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(Guid other)
        {
            return Equals(other.ToString("N").Substring(0, 24));
        }

        public bool Equals(ObjectId other)
        {
            return Equals(other.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is string) return Equals((string) obj);
            if (obj is Guid) return Equals((Guid) obj);
            if (obj is ObjectId) return Equals((ObjectId) obj);
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public static IdentityValue GenerateNewId()
        {
            return new IdentityValue(ObjectId.GenerateNewId());
        }

        public static IdentityValue Parse(string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            ObjectId objectId;
            if (ObjectId.TryParse(str, out objectId)) return objectId;
            throw new FormatException($"'{str}' is not a valid 24 digit hex string.");
        }

        public static implicit operator IdentityValue(string obj)
        {
            return new IdentityValue(obj);
        }

        public static implicit operator IdentityValue(Guid obj)
        {
            return new IdentityValue(obj);
        }

        public static implicit operator IdentityValue(ObjectId obj)
        {
            return new IdentityValue(obj);
        }

        public static implicit operator string(IdentityValue val)
        {
            return val.Value;
        }

        public static implicit operator Guid(IdentityValue val)
        {
            return Guid.Parse(val.Value.PadRight(32, '0'));
        }

        public static implicit operator ObjectId(IdentityValue val)
        {
            return ObjectId.Parse(val.Value);
        }

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Value;
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            switch (Type.GetTypeCode(conversionType))
            {
                case TypeCode.Object:
                    if (conversionType == typeof (object) || conversionType == typeof (ObjectId) || conversionType == typeof (Guid))
                        return this;
                    if (conversionType == typeof (BsonObjectId))
                        return new BsonObjectId((ObjectId) this);
                    if (conversionType == typeof (BsonString))
                        return new BsonString(Value);
                    break;
                case TypeCode.String:
                    return Value;
            }
            throw new InvalidCastException();
        }
    }
}