using System.Collections.Generic;

namespace DynamicCodeCompiler
{
    public class TypeModel
    {
        public string Name { get; set; }
        public List<PropertyModel> Properties { get; set; } = new List<PropertyModel>();
        public List<ConstructorModel> Constructors { get; set; } = new List<ConstructorModel>();
        public List<MethodModel> Methods { get; set; } = new List<MethodModel>();
    }

    public class PropertyModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class ConstructorModel
    {
        public string[] ArgumentTypes { get; set; }
    }

    public class MethodModel
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public string[] ArgumentTypes { get; set; }
    }
}
