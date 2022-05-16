using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword ("Sifarnik")]
    public class SifarnikInfo: IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }

    [Export(typeof(IConceptMacro))]
    public class SIfarnikMacro : IConceptMacro<SifarnikInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(SifarnikInfo sifarnik, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();
            ShortStringPropertyInfo StringName = new ShortStringPropertyInfo
            {
                DataStructure = sifarnik.Entity,
                Name = "Name"
            };
            newConcepts.Add(StringName);
            newConcepts.Add(new UniquePropertyInfo
            {
                Property = StringName
            });
            newConcepts.Add(new RequiredPropertyInfo
            {
                Property = StringName
            });
            return newConcepts;
        }
    }
}
