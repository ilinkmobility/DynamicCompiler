using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCodeCompiler
{
    public class Constants
    {
        //Dummy classes
        public static List<TypeModel> Classes = new List<TypeModel>() {
            new TypeModel() {
                Name = "Class1",
                Properties = {
                    new PropertyModel { Name = "Property1", Type = "int" },
                    new PropertyModel { Name = "Property2", Type = "string" }
                },
                Constructors = {
                    new ConstructorModel() { ArgumentTypes = new string[] { "int" } },
                    new ConstructorModel() { ArgumentTypes = new string[] { "int", "string" } }
                },
                Methods = {
                    new MethodModel() { Name = "Method1", ReturnType = "int", ArgumentTypes = new string[] { "int" } },
                    new MethodModel() { Name = "Method2", ReturnType = "object", ArgumentTypes = new string[] { "int", "string" } }
                }
            },
            new TypeModel() {
                Name = "Class2",
                Properties = {
                    new PropertyModel { Name = "Property1", Type = "int" },
                    new PropertyModel { Name = "Property2", Type = "string" }
                },
                Constructors = {
                    new ConstructorModel() { ArgumentTypes = new string[] { "int" } },
                    new ConstructorModel() { ArgumentTypes = new string[] { "int", "string" } }
                },
                Methods = {
                    new MethodModel() { Name = "Method1", ReturnType = "int", ArgumentTypes = new string[] { "int" } },
                    new MethodModel() { Name = "Method2", ReturnType = "object", ArgumentTypes = new string[] { "int", "string" } }
                }
            },
        };
    }
}
