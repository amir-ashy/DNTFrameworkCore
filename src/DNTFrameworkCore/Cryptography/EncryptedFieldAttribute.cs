using System;

namespace DNTFrameworkCore.Cryptography
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EncryptedFieldAttribute : Attribute
    { }
}