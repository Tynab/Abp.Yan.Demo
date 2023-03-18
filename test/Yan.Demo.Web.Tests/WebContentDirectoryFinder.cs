using System;
using System.IO;
using System.Linq;
using static System.Environment;
using static System.IO.Directory;
using static System.IO.Path;
using static System.IO.SearchOption;

namespace Yan.Demo;

/// <summary>
/// This class is used to find root path of the web project. Used for;
/// 1. unit tests (to find views).
/// 2. entity framework core command line commands (to find the conn string).
/// </summary>
public static class WebContentDirectoryFinder
{
    public static string CalculateContentRootFolder()
    {
        var directoryInfo = new DirectoryInfo(GetDirectoryName(typeof(DemoDomainModule).Assembly.Location) ?? throw new Exception($"Could not find location of {typeof(DemoDomainModule).Assembly.FullName} assembly!"));
        if (GetEnvironmentVariable("NCrunch") == "1")
        {
            while (!DirectoryContains(directoryInfo.FullName, "Yan.Demo.Web.csproj", AllDirectories))
            {
                directoryInfo = directoryInfo.Parent ?? throw new Exception("Could not find content root folder!");
            }
            var webProject = GetFiles(directoryInfo.FullName, string.Empty, AllDirectories).First(filePath => string.Equals(GetFileName(filePath), "Yan.Demo.Web.csproj"));
            return GetDirectoryName(webProject);
        }
        while (!DirectoryContains(directoryInfo.FullName, "Yan.Demo.sln"))
        {
            directoryInfo = directoryInfo.Parent ?? throw new Exception("Could not find content root folder!");
        }
        var webFolder = Combine(directoryInfo.FullName, $"src{DirectorySeparatorChar}Yan.Demo.Web");
        return Directory.Exists(webFolder) ? webFolder : throw new Exception("Could not find root folder of the web project!");
    }

    private static bool DirectoryContains(string directory, string fileName, SearchOption searchOption = TopDirectoryOnly) => GetFiles(directory, string.Empty, searchOption).Any(filePath => string.Equals(GetFileName(filePath), fileName));
}
