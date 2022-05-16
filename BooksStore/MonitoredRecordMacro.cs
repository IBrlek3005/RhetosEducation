using System.Collections.Generic;
using System.ComponentModel.Composition;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace MyFirstConcept
{
    [Export(typeof(IConceptMacro))]
    public class CodeTable : IConceptMacro<CodeTableInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(CodeTableInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            if (conceptInfo.DataStructure is IWritableOrmDataStructure) // Activate validation only on writable data, for example on Entity.
                newConcepts.Add(new AutocodeInfo
                {
                    Property = conceptInfo,
                    RegularExpression = @"[B][0-9][0-9][0-9]",
                    ErrorMessage = "Invalid code"
                }) ;

            return newConcepts;
        }
    }
}