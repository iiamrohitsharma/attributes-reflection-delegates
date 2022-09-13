using System;

namespace attributes_reflection_delegates.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class MySpecialAttribute : Attribute
    {
    }
}
