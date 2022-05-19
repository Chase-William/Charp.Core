﻿using System.Reflection;

using Docsharp.Core.Models.Docs;
using Docsharp.Core.Models.Members;

namespace Docsharp.Core.Models.Types
{
    public class EnumModel : TypeMember<TypeInfo, Documentation>, IFieldable
    {
        public const string ENUM_TYPE_STRING = "enum";
        public override bool CanHaveInternalTypes => false;
        public override string Type => ENUM_TYPE_STRING;

        public FieldModel[] Fields { get; set; }

        public string UnderLyingType => Meta.GetEnumUnderlyingType().ToString();        

        //public string BackingType => Meta.

        public EnumModel(TypeInfo member) : base(member)
        {
            // Omit first the element as it is provided by default by the compiler
            var fields = member.GetFields();
            Fields = new FieldModel[fields.Length - 1];
            for (int i = 1; i < fields.Length; i++)
                Fields[i - 1] = new FieldModel(fields[i]);
        }
    }
}