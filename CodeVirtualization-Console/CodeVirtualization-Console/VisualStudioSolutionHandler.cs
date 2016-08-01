using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace CodeVirtualization_Console
{
    class VisualStudioSolutionHandler
    {
        // start Roslyn workspace
        public static MSBuildWorkspace workspace = MSBuildWorkspace.Create();

        public static IEnumerable<Project> GetProjects(string pathToSolution)
        {
            

            // open solution we want to analyze
            Solution solutionToAnalyze =
                workspace.OpenSolutionAsync(pathToSolution).Result;

            var projects = solutionToAnalyze.Projects;

            return projects;   
        }


        public static Compilation GetProjectCompilation(Project project)
        {
            // get the project's compilation
            // compilation contains all the types of the 
            // project and the projects referenced by 
            // our project. 
            Compilation projectCompilation =
                project.GetCompilationAsync().Result;                  

            return projectCompilation;
        }

        
    }
}
