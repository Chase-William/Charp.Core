﻿using System.Collections.Generic;
using System.Reflection;

using Charp.Core.Models.Members;
using LoxSmoke.DocXml;

namespace Charp.Core.Models.Types
{
    public class ClassModel : TypeMember<TypeInfo, TypeComments>, INestable
    {
        public const string CLASS_TYPE_STRING = "class";
        public bool IsPublic => Meta.IsPublic;

        public override bool CanHaveInternalTypes => true;
        public override string Type => CLASS_TYPE_STRING;

        public PropertyModel[] Properties { get; set; }
        public FieldModel[] Fields { get; set; }
        public MethodModel[] Methods { get; set; }
        public EventModel[] Events { get; set; }

        public ClassModel(TypeInfo member, DocXmlReader reader) : base(member)
        {
            INestable.Init(this, member, reader);
        }
    }
}