using System.Collections.Generic;

namespace DynamicCodeCompiler
{
    public class TypeModel
    {
        public string Name { get; set; }
        public List<string> Properties { get; set; } = new List<string>();
        public List<string> Constructors { get; set; } = new List<string>();
        public List<string> Methods { get; set; } = new List<string>();
    }
}
