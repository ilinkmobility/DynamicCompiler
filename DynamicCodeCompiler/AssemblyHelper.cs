using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicCodeCompiler
{
    public class AssemblyHelper
    {
        string[] DefaultMethods = { "ToString", "Equals", "GetHashCode", "GetType" };

        private static AssemblyHelper instance;

        /// <summary>
        /// Constructor.
        /// </summary>
        private AssemblyHelper()
        {
        }

        public static AssemblyHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssemblyHelper();
                }
                return instance;
            }
        }

        /// <summary>
        /// Generates the type model.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public List<TypeModel> GenerateTypeModel(Type[] types)
        {
            var typeModels = new List<TypeModel>();

            foreach (var type in types)
            {
                typeModels.Add(GetTypeModel(type));
            }

            return typeModels;
        }

        /// <summary>
        /// Gets the type model(properties,constructors,methods).
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TypeModel GetTypeModel(Type type)
        {
            int i, j = 0;

            var typeModel = new TypeModel
            {
                Name = type.Name
            };

            //Collecting all properties
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                typeModel.Properties.Add(new PropertyModel() { Name = property.Name, Type = property.PropertyType.Name });
            }

            //Collecting all constructors
            var constructors = type.GetConstructors();

            for (i = 0; i < constructors.Length; i++)
            {
                var constructorModel = new ConstructorModel();
                var parameters = constructors[i].GetParameters();

                constructorModel.ArgumentTypes = new string[parameters.Length];

                for (j = 0; j < parameters.Length; j++)
                {
                    constructorModel.ArgumentTypes[j] = parameters[j].ParameterType.Namespace.ToString() + "." + parameters[j].ParameterType.Name + " " + parameters[j].Name;
                }

                typeModel.Constructors.Add(constructorModel);
            }

            //Collecting all methods
            var methods = type.GetMethods();

            for (i = 0; i < methods.Length; i++)
            {
                string name = methods[i].Name;
                if (!name.StartsWith("get_") && !name.StartsWith("set_") && !DefaultMethods.Contains(name))
                {
                    var methodModel = new MethodModel();
                    methodModel.Name = methods[i].Name;
                    methodModel.ReturnType = methods[i].ReturnType.Name;

                    var parameters = methods[i].GetParameters();

                    methodModel.ArgumentTypes = new string[parameters.Length];

                    for (j = 0; j < parameters.Length; j++)
                    {
                        methodModel.ArgumentTypes[j] = parameters[j].ParameterType.Namespace.ToString() + "." + parameters[j].ParameterType.Name + " " + parameters[j].Name;
                    }

                    typeModel.Methods.Add(methodModel);
                }
            }

            return typeModel;
        }

        /// <summary>
        /// Generates the tree node.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public TreeNode[] GenereateTreeNode(List<TypeModel> types)
        {
            var treeNodes = new TreeNode[types.Count];
            int count = 0;

            foreach (var type in types)
            {
                List<TreeNode> pnode = new List<TreeNode>();
                List<TreeNode> cnode = new List<TreeNode>();
                List<TreeNode> mnode = new List<TreeNode>();

                //Properties.
                foreach (var property in type.Properties)
                {
                    pnode.Add(new TreeNode(property.Type + " : " + property.Name));
                }

                TreeNode[] PropertiesArray = pnode.ToArray();

                //Constructors.
                foreach (var constructor in type.Constructors)
                {
                    cnode.Add(new TreeNode(type.Name + "( " + string.Join(", ", constructor.ArgumentTypes) + " )"));
                }

                TreeNode[] ConstructorsArray = cnode.ToArray();

                //Methods.
                foreach (var method in type.Methods)
                {
                    mnode.Add(new TreeNode(method.ReturnType + " : " + method.Name
                        + "( " + string.Join(", ", method.ArgumentTypes) + " )"));
                }

                TreeNode[] MethodsArray = mnode.ToArray();

                //Adding each node.
                TreeNode Properties = new TreeNode("Properties", PropertiesArray);
                TreeNode Constructors = new TreeNode("Constructors", ConstructorsArray);
                TreeNode Methods = new TreeNode("Methods", MethodsArray);
                TreeNode[] MainComponents = new TreeNode[] { Properties, Constructors, Methods };

                // Final node.
                TreeNode treeNode = new TreeNode(type.Name, MainComponents);

                treeNodes[count++] = treeNode;
            }

            return treeNodes;
        }
    }
}
