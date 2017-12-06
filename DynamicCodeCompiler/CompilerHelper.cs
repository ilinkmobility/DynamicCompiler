using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCodeCompiler
{
    public class CompilerHelper
    {
        string[] DefaultMethods = { "ToString", "Equals", "GetHashCode", "GetType" };

        private static CompilerHelper instance;

        private CompilerHelper()
        {
        }

        public static CompilerHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompilerHelper();
                }
                return instance;
            }
        }

        public void GetAppDomainAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain
                            .GetAssemblies();

            Type[] types = assemblies[1].GetTypes();

            GetTypeDetails(types[0]);
        }

        public void GetTypeDetails(Type type)
        {
            var typeModel = new TypeModel();
            
            typeModel.Name = type.Name;

            var methods = type.GetMethods();

            for (int i = 0; i < methods.Length; i++)
            {
                string name = methods[i].Name;
                if (!name.StartsWith("get_") && !name.StartsWith("set_") && !DefaultMethods.Contains(name))
                {
                    typeModel.Methods.Add(methods[i].Name);
                }
            }
            
            var x = typeModel;
        }
    }
}
