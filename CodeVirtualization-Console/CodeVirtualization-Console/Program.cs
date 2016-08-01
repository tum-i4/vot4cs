using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace CodeVirtualization_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            if (!setConfigFileAtRuntime(args))
                return;
        
            if (args.Length < 2)
            {
                Console.WriteLine("Please specify a solultion (.sln) file:");
                Console.WriteLine("Usage: <tool> <config-file> <solution-file>");
                return;
            }
            var dir = Environment.CurrentDirectory;
            string pathToSolution = args[1];

            Console.WriteLine("path to solution: {0}", pathToSolution);

            IEnumerable<Project> projects = null;
            try
            {
                projects = VisualStudioSolutionHandler.GetProjects(pathToSolution);
            }
            catch (Exception e)
            {
                Console.WriteLine("INVALID path to solution: {0}", pathToSolution);
                return;
            }

            foreach (var project in projects)
            {
                                
                var compilation = VisualStudioSolutionHandler.GetProjectCompilation(project);

                var syntaxTrees = compilation.SyntaxTrees;
                foreach (var syntaxTree in syntaxTrees)
                {                    
                    var model = compilation.GetSemanticModel(syntaxTree, true);
                    Document doc = project.GetDocument(syntaxTree);

                    var virtualizationContext = new VirtualizationContext();
                    virtualizationContext.semanticModel = model;
                    virtualizationContext.project = project;
                    virtualizationContext.document = doc;
                    virtualizationContext.compilation = compilation;
                    virtualizationContext.workspace = VisualStudioSolutionHandler.workspace;

                    var virtualizationHandler = new VirtualizationHandler(virtualizationContext);                    
                    virtualizationHandler.VirtualizeProject();                    
                }

            }

            Console.WriteLine();
            Console.WriteLine(">>OK: Virtualization Complete!");
            Console.ReadKey();
        }

       
        private static bool setConfigFileAtRuntime(string[] args)
        {
            string runtimeconfigfile;

            if (args.Length == 0)
            {                
                Console.WriteLine("Please specify a config file:");
                Console.WriteLine("Usage: <tool> <config-file> <solution-file>");
               
                return false;
            }

            runtimeconfigfile = args[0];

            // Specify config settings at runtime.
            var configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = runtimeconfigfile;
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);


            //VPC_IDENTIFIER
            try
            {
                var vpcIdentifier = config.AppSettings.Settings["VPC_IDENTIFIER"];
                if (vpcIdentifier != null)
                {
                    VirtualizationContext.VPC_IDENTIFIER = vpcIdentifier.Value;
                }
                Console.WriteLine("VPC_IDENTIFIER: {0}", VirtualizationContext.VPC_IDENTIFIER);
            }
            catch (Exception e)
            {
                VirtualizationContext.VPC_IDENTIFIER = "xyc";
                Console.WriteLine("VPC_IDENTIFIER: {0} (default)", VirtualizationContext.VPC_IDENTIFIER);
            }


            //CODE_IDENTIFIER
            try
            {
                var codeIdentifier = config.AppSettings.Settings["CODE_IDENTIFIER"];
                if (codeIdentifier != null)
                {
                    VirtualizationContext.CODE_IDENTIFIER = codeIdentifier.Value;
                }
                Console.WriteLine("CODE_IDENTIFIER: {0}", VirtualizationContext.CODE_IDENTIFIER);
            }
            catch (Exception e)
            {
                VirtualizationContext.CODE_IDENTIFIER = "bcd";
                Console.WriteLine("CODE_IDENTIFIER: {0} (default)", VirtualizationContext.CODE_IDENTIFIER);
            }
           

            //DATA_IDENTIFIER
            try
            {
                var dataIdentifier = config.AppSettings.Settings["DATA_IDENTIFIER"];
                if (dataIdentifier != null)
                {
                    VirtualizationContext.DATA_IDENTIFIER = dataIdentifier.Value;
                }
                Console.WriteLine("DATA_IDENTIFIER: {0}", VirtualizationContext.DATA_IDENTIFIER);
            }
            catch (Exception e)
            {
                VirtualizationContext.DATA_IDENTIFIER = "def";
                Console.WriteLine("DATA_IDENTIFIER: {0} (default)", VirtualizationContext.DATA_IDENTIFIER);
            }
            

            //DEFAULT_MOST_FREQUENT_OPERATION
            try
            {
                var defaultMostFrequent = config.AppSettings.Settings["DEFAULT_MOST_FREQUENT_OPERATION"];
                if (defaultMostFrequent != null)
                {
                    VirtualizationContext.DEFAULT_MOST_FREQUENT_OPERATION = Boolean.Parse(defaultMostFrequent.Value);
                }
                Console.WriteLine("DEFAULT_MOST_FREQUENT_OPERATION: {0}", VirtualizationContext.DEFAULT_MOST_FREQUENT_OPERATION);
            }
            catch (Exception e)
            {
                VirtualizationContext.DEFAULT_MOST_FREQUENT_OPERATION = true;
                Console.WriteLine("DEFAULT_MOST_FREQUENT_OPERATION: {0} (default)", VirtualizationContext.DEFAULT_MOST_FREQUENT_OPERATION);
            }

            //INSTRUCTION_SIZE_POSTFIX
            try
            {
                var instructionPostfix = config.AppSettings.Settings["INSTRUCTION_SIZE_POSTFIX"];
                if (instructionPostfix != null)
                {
                    VirtualizationContext.INSTRUCTION_SIZE_POSTFIX = Int32.Parse(instructionPostfix.Value);
                }
                Console.WriteLine("INSTRUCTION_SIZE_POSTFIX: {0}", VirtualizationContext.INSTRUCTION_SIZE_POSTFIX);
            }
            catch (Exception e)
            {
                VirtualizationContext.INSTRUCTION_SIZE_POSTFIX = 30;
                Console.WriteLine("INSTRUCTION_SIZE_POSTFIX: {0} (default)", VirtualizationContext.INSTRUCTION_SIZE_POSTFIX);
            }


            //INSTRUCTION_SIZE_PREFIX
            try
            {
                var instructionPrefix = config.AppSettings.Settings["INSTRUCTION_SIZE_PREFIX"];
                if (instructionPrefix != null)
                {
                    VirtualizationContext.INSTRUCTION_SIZE_PREFIX = Int32.Parse(instructionPrefix.Value);
                }
                Console.WriteLine("INSTRUCTION_SIZE_PREFIX: {0}", VirtualizationContext.INSTRUCTION_SIZE_PREFIX);
            }
            catch (Exception e)
            {
                VirtualizationContext.INSTRUCTION_SIZE_PREFIX = 20;
                Console.WriteLine("INSTRUCTION_SIZE_PREFIX: {0} (default)", VirtualizationContext.INSTRUCTION_SIZE_PREFIX);
            }

            //INSTRUCTION_SIZE_OFFSET
            try
            {
                var instructionSizeOffset = config.AppSettings.Settings["INSTRUCTION_SIZE_OFFSET"];
                if (instructionSizeOffset != null)
                {
                    VirtualizationContext.INSTRUCTION_SIZE_OFFSET = Int32.Parse(instructionSizeOffset.Value);
                }
                Console.WriteLine("INSTRUCTION_SIZE_OFFSET: {0}", VirtualizationContext.INSTRUCTION_SIZE_OFFSET);
            }
            catch (Exception e)
            {
                VirtualizationContext.INSTRUCTION_SIZE_OFFSET = 20;
                Console.WriteLine("INSTRUCTION_SIZE_OFFSET: {0} (default)", VirtualizationContext.INSTRUCTION_SIZE_OFFSET);
            }


            //MAX_INVOCATIONS
            try
            {
                var maxInvocations = config.AppSettings.Settings["MAX_INVOCATIONS"];
                if (maxInvocations != null)
                {
                    VirtualizationContext.MAX_INVOCATIONS = Int32.Parse(maxInvocations.Value);
                }
                Console.WriteLine("MAX_INVOCATIONS: {0}", VirtualizationContext.MAX_INVOCATIONS);
            }
            catch (Exception e)
            {
                VirtualizationContext.MAX_INVOCATIONS = 1;
                Console.WriteLine("MAX_INVOCATIONS: {0} (default)", VirtualizationContext.MAX_INVOCATIONS);
            }

            //MAX_OPERANDS
            try
            {
                var maxOperands = config.AppSettings.Settings["MAX_OPERANDS"];
                if (maxOperands != null)
                {
                    VirtualizationContext.MAX_OPERANDS = Int32.Parse(maxOperands.Value);
                }
                Console.WriteLine("MAX_OPERANDS: {0}", VirtualizationContext.MAX_OPERANDS);
            }
            catch (Exception e)
            {
                VirtualizationContext.MAX_OPERANDS = 1;
                Console.WriteLine("MAX_OPERANDS: {0} (default)", VirtualizationContext.MAX_OPERANDS);
            }

            //MAX_JUNK_CODE
            try
            {
                var maxJunkCode = config.AppSettings.Settings["MAX_JUNK_CODE"];
                if (maxJunkCode != null)
                {
                    VirtualizationContext.MAX_JUNK_CODE = Int32.Parse(maxJunkCode.Value);
                }
                Console.WriteLine("MAX_JUNK_CODE: {0}", VirtualizationContext.MAX_JUNK_CODE);
            }
            catch (Exception e)
            {
                VirtualizationContext.MAX_JUNK_CODE = 10;
                Console.WriteLine("MAX_JUNK_CODE: {0} (default)", VirtualizationContext.MAX_JUNK_CODE);
            }

            //MAX_DATA_KEY
            try
            {
                var maxDataKey = config.AppSettings.Settings["MAX_DATA_KEY"];
                if (maxDataKey != null)
                {
                    VirtualizationContext.MAX_DATA_KEY = Int32.Parse(maxDataKey.Value);
                }
                Console.WriteLine("MAX_DATA_KEY: {0}", VirtualizationContext.MAX_DATA_KEY);
            }
            catch (Exception e)
            {
                VirtualizationContext.MAX_DATA_KEY = 3999;
                Console.WriteLine("MAX_DATA_KEY: {0} (default)", VirtualizationContext.MAX_DATA_KEY);
            }


            //MAX_CODE_KEY
            try
            {
                var maxCodeKey = config.AppSettings.Settings["MAX_CODE_KEY"];
                if (maxCodeKey != null)
                {
                    VirtualizationContext.MAX_CODE_KEY = Int32.Parse(maxCodeKey.Value);
                }
                Console.WriteLine("MAX_CODE_KEY: {0}", VirtualizationContext.MAX_CODE_KEY);
            }
            catch (Exception e)
            {
                VirtualizationContext.MAX_CODE_KEY = 99999;
                Console.WriteLine("MAX_CODE_KEY: {0} (default)", VirtualizationContext.MAX_CODE_KEY);
            }


            //MIN_SWITCH_KEY
            try
            {
                var minSwitchKey = config.AppSettings.Settings["MIN_SWITCH_KEY"];
                if (minSwitchKey != null)
                {
                    VirtualizationContext.MIN_SWITCH_KEY = Int32.Parse(minSwitchKey.Value);
                }
                Console.WriteLine("MIN_SWITCH_KEY: {0}", VirtualizationContext.MIN_SWITCH_KEY);
            }
            catch (Exception e)
            {
                VirtualizationContext.MIN_SWITCH_KEY = 1000;
                Console.WriteLine("MIN_SWITCH_KEY: {0} (default)", VirtualizationContext.MIN_SWITCH_KEY);
            }

            //MAX_SWITCH_KEY
            try
            {
                var maxSwitchKey = config.AppSettings.Settings["MAX_SWITCH_KEY"];
                if (maxSwitchKey != null)
                {
                    VirtualizationContext.MAX_SWITCH_KEY = Int32.Parse(maxSwitchKey.Value);
                }
                Console.WriteLine("MAX_SWITCH_KEY: {0}", VirtualizationContext.MAX_SWITCH_KEY);
            }
            catch (Exception e)
            {
                VirtualizationContext.MAX_SWITCH_KEY = 9999;
                Console.WriteLine("MAX_SWITCH_KEY: {0} (default)", VirtualizationContext.MAX_SWITCH_KEY);
            }

            return true;
        }

    }
}
