using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using System;
using System.IO;
using System.Linq;

sealed partial class Build
{
    Target CreateInstaller => _ => _
    .TriggeredBy(Compile)
    .Executes(() =>
    {
        var exePattern = $"*{Solution.publish.Installer.Name}.exe";
        var exeFile = Directory.EnumerateFiles(Solution.publish.Installer.Directory, exePattern, SearchOption.AllDirectories).FirstOrDefault();
        if (exeFile is null) throw new Exception($"No installer file was found for the project: {Solution.publish.Installer.Name}");

        var process = ProcessTasks.StartProcess(exeFile);
        process.AssertZeroExitCode();
    });
}
