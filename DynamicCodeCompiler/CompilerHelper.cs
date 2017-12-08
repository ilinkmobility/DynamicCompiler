﻿using DesktopBridge;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public string Compile(string source)
        {
            if (helpers.IsRunningAsUwp())
            {
                CompiledDllPath = ApplicationData.Current.LocalFolder.Path + @"\DynamicAssembly.dll";
            }
            else
            {
                CompiledDllPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DynamicAssembly.dll";
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

            //Refering external assemblies
            if (Session.ExternalAssembly.Count > 0)
            {
                foreach (KeyValuePair<string, string> entry in Session.ExternalAssembly)
                {
                    if(!parameters.ReferencedAssemblies.Contains(entry.Value))
                    {
                        parameters.ReferencedAssemblies.Add(entry.Value);
                    }
                }
            }

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
                AssemblyHelper.Instance.GenerateTypeModel(GetCompiledAssembly());

                return CompiledDllPath;
            }
        }

        public Type[] GetAllTypesFromAssembly(string path)
        {
            var assembly = Assembly.LoadFile(path);

            return assembly.GetTypes();
        }

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

        public List<string> GetLoadedAssembliesPathFromAppDomain()
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

        public Type[] GetAllTypesFromAssembly(string path)
        {
            var assembly = Assembly.LoadFile(path);

            return assembly.GetTypes();
        }

        public int GetNumberOfParameters(string method)
        {
            if (!method.Contains("(  )"))
            {
                var parameters = method.Substring(method.IndexOf('(')).Split(',');
                return parameters.Length;
            }

            return 0;
        }

        public void InvokeConstructor()
        {
            try
            {
                MessageBox.Show("Calling constructor", "Started", MessageBoxButtons.OK);
                Type[] types = GetCompiledAssembly();
                Type type = types[0];
                ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
                ctor.Invoke(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }
    }
}
