using Docshark.Core.Models.Lang.Types;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Docshark.Test.Interfaces.Meta
{
    /// <summary>
    /// Ensures the aspects of <see cref="INestableTest"/> operate as expected.
    /// </summary>
    internal interface INestableTest
    {
        /// <summary>
        /// Ensures the existance/absense of properties are handled correctly.
        /// </summary>
        void PropertiesExistTest();
        /// <summary>
        /// Ensures the existance/absense of fields are handled correctly.
        /// (THIS TEST EXPECTS BACKING FIELDS OF PROPERTIES TO BE OMITTED)
        /// </summary>
        void FieldsExistTest();
        /// <summary>
        /// Ensures the existance/absense of methods are handled correctly.
        /// (THIS TEST EXPECTS PRIVATE & MEMBERS System.Object TO BE OMITTED)
        /// </summary>
        void MethodsExistTest();

        /// <summary>
        /// Implement to get the class type provided via <paramref name="className"/>.
        /// </summary>
        /// <param name="className">Class type as a string to get acquired.</param>
        /// <returns>A class type that implements <see cref="IMemberContainable"/>.</returns>
        T GetType<T>(string className) where T : IMemberContainable;

        /// <summary>
        /// Returns count of fields declared in the class.
        /// </summary>
        /// <param name="type">Type to get fields from.</param>
        /// <returns>Declared fields from instance within <paramref name="type"/>.</returns>
        static int GetFieldCount(Type type)
            =>  type.GetRuntimeFields()
            .Where(field => !field.GetCustomAttributesData().Any(attr => attr.AttributeType.Name == typeof(CompilerGeneratedAttribute).Name))
            .Count();

        /// <summary>
        /// Collection of members always present in an object.
        /// Works for structs too because they are <see cref="ValueType"/> which is a class behind the scenes.
        /// </summary>
        static readonly string[] DEFAULT_OBJ_METHODS = typeof(object).GetRuntimeMethods().Select(m => m.Name).ToArray();

        /// <summary>
        /// Returns count of public methods declared in the class. This ignores
        /// generated property getter/setters.
        /// </summary>
        /// <param name="type">Type to get methods from.</param>
        /// <returns>Declared methods from instance within <paramref name="type"/>.</returns>
        static int GetMethodCount(Type type)
            => type // Filter out default methods and compiler generated
                .GetRuntimeMethods()
                .Where(method => !method.IsSpecialName &&
                !DEFAULT_OBJ_METHODS.Any(name => name.Equals(method.Name))
            ).Count();

        /// <summary>
        /// Returns count of properties declared in the class.
        /// </summary>
        /// <param name="type">Type to get properties from.</param>
        /// <returns>Declared properties from instance within <paramref name="type"/>.</returns>
        static int GetPropertyCount(Type type)
            => type.GetTypeInfo().GetRuntimeProperties().Count();
    }
}
