using DesktopBridge;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Storage;

namespace DynamicCodeCompiler
{
    public class CompilerHelper
    {
        private static CompilerHelper instance;

        private CodeDomProvider codeProvider;

        private Helpers helpers;

        public string CompiledDllPath { get; set; }

        public int Count { get; set; }

        private CompilerHelper()
        {             
            helpers = new Helpers();
            codeProvider = CodeDomProvider.CreateProvider("CSharp");
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

        public string Compile(string source,string assemblyname)
        {
            if (helpers.IsRunningAsUwp())
            {
                CompiledDllPath = ApplicationData.Current.LocalFolder.Path + assemblyname;
            }
            else
            {
                CompiledDllPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + assemblyname;
            }

            CompilerParameters parameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                OutputAssembly = CompiledDllPath
            };

            //Adding all referenced assemblies of running App to the compiler reference
            var assemblies = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !a.IsDynamic)
                            .Select(a => a.Location);

            parameters.ReferencedAssemblies.AddRange(assemblies.ToArray());            

            //Adding all external assemblies as embedded resource
            if (Session.ExternalAssembly.Count > 0)
            {
                foreach (KeyValuePair<string, string> entry in Session.ExternalAssembly)
                {
                    if (!parameters.ReferencedAssemblies.Contains(entry.Value))
                    {
                        parameters.ReferencedAssemblies.Add(entry.Value);
                    }
                }
            }

            //Externally adding Windows.winmd UWP runtime component reference UWP namespaces
            //parameters.ReferencedAssemblies.Add(@"C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Windows.winmd");
            parameters.ReferencedAssemblies.Add(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7\Microsoft.CSharp.dll");

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, source);

            string result = string.Empty;

            Count = results.Errors.Count;
            if (Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    result += "Line number " + CompErr.Line
                        + ", Error Number: " + CompErr.ErrorNumber
                        + ", '" + CompErr.ErrorText + ";\n\n";
                };

                return result;
            }
            else
            {
                var successResult = "Assembly Path : " + CompiledDllPath;
                if (Session.ExternalAssembly.Count > 0)
                {
                    successResult += "\n\nExternal Assembly Coping Path : " + GetAppExecutableDirectory();
                }   

                return successResult;
            }
        }

        /// <summary>
        /// Get the list of types from externally loaded assemblly
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Type[] GetAllTypesFromAssembly(string path)
        {
            var assembly = Assembly.LoadFile(path);

            return assembly.GetTypes();
        }

        /// <summary>
        /// Get the list of assemblies referenced in the running application. It will be loaded for dynamic compiler
        /// </summary>
        /// <returns></returns>
        public Assembly[] GetAppDomainAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        public List<string> GetLoadedAssembliesFromAppDomain()
        {
            var assemblies = new List<string>();

            foreach (var assembly in GetAppDomainAssemblies())
            {
                assemblies.Add(assembly.CodeBase.Replace(@"file:///", ""));
            }

            return assemblies;            
        }

        public List<string> GetLoadedAssembliesFileNameFromAppDomain()
        {
            var assemblies = new List<string>();

            foreach (var assembly in GetLoadedAssembliesFromAppDomain())
            {
                assemblies.Add(Path.GetFileName(assembly));
            }

            assemblies.Sort();
            return assemblies;
        }
        
        public Type[] GetCompiledAssembly()
        {
            var assembly = Assembly.LoadFile(CompiledDllPath);

            return assembly.GetTypes();
        }

        public string GetMethodName(string method)
        {
            Match matches = new Regex(@": (.+)\(", RegexOptions.IgnoreCase).Match(method);
            return matches.Groups[1].ToString();
        }

        public List<KeyValuePair<string, string>> GetParameterList(string method)
        {
            List<KeyValuePair<string, string>> parameterList = new List<KeyValuePair<string, string>>();

            if (!method.Contains("(  )"))
            {
                Match matches = new Regex(@"\(\s(.+)\s\)", RegexOptions.IgnoreCase).Match(method);
                if (matches.Groups.Count > 0)
                {
                    var group = matches.Groups[1];
                    var parameters = group.ToString().Split(',');

                    foreach (var parameter in parameters)
                    {
                        var items = parameter.Trim().Split(' ');
                        parameterList.Add(new KeyValuePair<string, string>(items[0], items[1]));
                    }
                }
            }

            return parameterList;
        }

        public void InvokeConstructor(Type[] paremeterTypes, object[] parametersValues)
        {
            try
            {
                CopyDependencyAssemblies();
                Type[] types = GetCompiledAssembly();
                Type type = types[0];
                ConstructorInfo ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly,
                    null,
                    paremeterTypes,
                    null);
                ctor.Invoke(parametersValues);
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        public void InvokeMethod(string method, Type[] paremeterTypes, object[] parametersValues)
        {
            try
            {
                CopyDependencyAssemblies();
                Type[] types = GetCompiledAssembly();
                Type type = types[0];
                MethodInfo methodInfo = type.GetMethod(method, 
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly,
                    null,
                    paremeterTypes,
                    null);

                object classInstance = Activator.CreateInstance(type, null);
                methodInfo.Invoke(classInstance, parametersValues);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        public string GetAppExecutableDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public void CopyDependencyAssemblies()
        {
            var appDirectory = GetAppExecutableDirectory();

            foreach (var externalAssembly in Session.ExternalAssembly)
            {
                try
                {
                    var fileName = Path.GetFileName(externalAssembly.Value);
                    File.Copy(externalAssembly.Value, appDirectory + @"\" + fileName, true);
                }
                catch (Exception)
                { }
            }
        }
    }
}