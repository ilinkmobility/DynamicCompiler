using DesktopBridge;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
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

        public string AppPackageId { get; set; } = "244891f1-8d7d-4f90-8a31-6b968672039b";

        string zipFile = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Release.zip");
        string extractedFolder = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Release");

        /// <summary>
        /// Constructor.
        /// </summary>
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


        /// <summary>
        /// Compile process.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="assemblyname"></param>
        /// <param name="windows10KitPath"></param>
        /// <returns></returns>
        public string Compile(string source,string assemblyname, string windows10KitPath, bool isUWPCompileDeploy = false)
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
                GenerateExecutable = isUWPCompileDeploy,
                GenerateInMemory = true,
                OutputAssembly = CompiledDllPath
            };

            if (isUWPCompileDeploy) {
                parameters.CompilerOptions = "/t:winexe";
            }

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

            if (!string.IsNullOrEmpty(windows10KitPath))
            {
                parameters.ReferencedAssemblies.Add(windows10KitPath);
            }
            
            //To access Windows.System namespace. Launcher class need to be accessed.
            try
            {
                parameters.ReferencedAssemblies.Add(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\Microsoft.CSharp.dll");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
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

        /// <summary>
        /// Gets the loaded assemblies from app domain.
        /// </summary>
        /// <returns></returns>
        public List<string> GetLoadedAssembliesFromAppDomain()
        {
            var assemblies = new List<string>();

            foreach (var assembly in GetAppDomainAssemblies())
            {
                assemblies.Add(assembly.CodeBase.Replace(@"file:///", ""));
            }

            return assemblies;            
        }

        /// <summary>
        /// Gets the loaded assemblies file name from app domain.
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Gets the compiled assembly.
        /// </summary>
        /// <returns></returns>
        public Type[] GetCompiledAssembly()
        {
            var assembly = Assembly.LoadFile(CompiledDllPath);

            return assembly.GetTypes();
        }

        /// <summary>
        /// Gets the method name.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public string GetMethodName(string method)
        {
            Match matches = new Regex(@": (.+)\(", RegexOptions.IgnoreCase).Match(method);
            return matches.Groups[1].ToString();
        }

        /// <summary>
        /// Gets the parameter list in form of key value pairs as parameter name and parameter type of passing method.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetParameterList(string method)
        {
            List<KeyValuePair<string, string>> parameterList = new List<KeyValuePair<string, string>>();

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
            return parameterList;
        }

        /// <summary>
        /// Invoke the dynamically created constructors with arguments using Reflection
        /// </summary>
        /// <param name="paremeterTypes"></param>
        /// <param name="parametersValues"></param>
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
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Invoke the dynamically created methods with arguments using Reflection
        /// </summary>
        /// <param name="method"></param>
        /// <param name="paremeterTypes"></param>
        /// <param name="parametersValues"></param>
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

        /// <summary>
        /// Gets the directory of the app executable.
        /// </summary>
        /// <returns></returns>
        public string GetAppExecutableDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Copies the dependency assemblies to app execution directory.
        /// </summary>
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
                }
            }
        }



        private async void CopyReleaseZip()
        {
            //MessageBox.Show("1");
            try
            {
                StorageFile zipFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Release.zip"));

                string sourcePath = zipFile.Path;
                string targetPathToCopy = Path.Combine(ApplicationData.Current.LocalFolder.Path, zipFile.Name);

                if (!File.Exists(targetPathToCopy))
                {
                    // To copy a file to another location
                    File.Copy(sourcePath, targetPathToCopy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void ExtractReleaseZip()
        {
            //MessageBox.Show("2");
            try
            {
                if (Directory.Exists(extractedFolder))
                {
                    Directory.Delete(extractedFolder, true);
                    Directory.CreateDirectory(extractedFolder);
                }

                MessageBox.Show(zipFile + "XXX" + extractedFolder);

                ZipFile.ExtractToDirectory(zipFile, extractedFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void UpdateAppManifest(string assemblyName)
        {
            try
            {
                //AppPackageId = Guid.NewGuid().ToString();
                //MessageBox.Show(AppPackageId);

                string appxManifestFilePath = Path.Combine(extractedFolder, "AppxManifest.xml");
                string text = File.ReadAllText(appxManifestFilePath);
                text = text.Replace("APPNAME", assemblyName);
                //text = text.Replace("APPPKGID", AppPackageId);
                File.WriteAllText(appxManifestFilePath, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        public void DeployAsUWPApp()
        {
            try
            {
                CopyReleaseZip();
                ExtractReleaseZip();

                var assemblyName = Path.GetFileName(CompiledDllPath).Replace(".dll", "").Replace(".exe", "");

                File.Copy(CompiledDllPath, Path.Combine(extractedFolder, assemblyName + ".exe"));
                
                UpdateAppManifest(assemblyName);

                var path = ApplicationData.Current.LocalFolder.Path;
                var appx = Path.Combine(path, assemblyName + @".appx");

                //MessageBox.Show("MakeAppx");

                string makeAppxCommand = @"MakeAppx pack /l /d " + Path.Combine(path, "Release") + @" /p " + appx;

                ExecutePowerShell(makeAppxCommand);

                //MessageBox.Show("SignTool");

                string signAppx = @"SignTool sign /fd sha256 /a /f D:\UWP\DynamicCompilerTools\iLink-Systems.pfx /p Welcome123 " + appx;

                ExecutePowerShell(signAppx);              

                string addpackagesyntax = @"Add-AppxPackage -Path " + appx;
                string addpackagecmdlet = string.Format("\"{0}\"", addpackagesyntax);
                //powershell.exe -Command "Add-AppxPackage -Path C:\Users\vignesha\AppData\Local\Packages\48141348-0714-4092-9b64-beaac406807b_y1rwc9yf20874\LocalState\Dynamic.appx"
                string deploy = "powershell.exe -Command " + addpackagecmdlet;

                //MessageBox.Show("Deploy : " + deploy);

                ExecutePowerShell(deploy);

                string packageFamilyNames = ExecutePowerShell("get-appxpackage | Select PackageFamilyName");

                string packageToInvoke = string.Empty;

                //MessageBox.Show("Count : " + packageFamilyNames.Length);

                foreach (var packageName in packageFamilyNames.Split('@'))
                {
                    if (packageName.Contains(AppPackageId))
                    {
                        packageToInvoke = packageName.Replace("{PackageFamilyName=", "").Replace("}", "");
                        //MessageBox.Show(packageToInvoke);
                    }
                }

                if (!string.IsNullOrEmpty(packageToInvoke))
                {
                    string launch = @"explorer.exe shell:appsFolder\" + packageToInvoke + "!" + "App";
                   // MessageBox.Show(launch);
                    ExecutePowerShell(launch);
                }


                //MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private string ExecutePowerShell(string script)
        {
            string result = string.Empty;

            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                    // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                    PowerShellInstance.AddScript(script);

                    // invoke execution on the pipeline (collecting output)
                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    // loop through each output object item
                    foreach (PSObject outputItem in PSOutput)
                    {
                        // if null object was dumped to the pipeline during the script then a null
                        // object may be present here. check for null to prevent potential NRE.
                        if (outputItem != null)
                        {
                            //TODO: do something with the output item 

                            //if (outputItem.BaseObject.GetType().FullName != "System.ServiceProcess.ServiceController")
                            //{
                            //    result += outputItem.BaseObject.ToString() + "\r\n";
                            //}

                            result += outputItem.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }

            return result;
        }
    }
}