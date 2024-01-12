using System;
using System.IO;
using WixSharp;
using WixSharp.CommonTasks;
using WixSharp.Controls;
using Assembly = System.Reflection.Assembly;

const string projectName = "RevitSolutionTemplate";

var currentDirectory = Directory.GetCurrentDirectory();
var installerPath = Path.Combine(currentDirectory, "publish", "Installer");
var tempDir = new DirectoryInfo(Path.Combine(installerPath, "bin", "temp"));

var project = new Project
{
    OutDir = "output",
    Name = projectName,
    Platform = Platform.x64,
    UI = WUI.WixUI_FeatureTree,
    MajorUpgrade = MajorUpgrade.Default,
    GUID = new Guid("5867d457-8d73-488a-80bc-ae807f92c602"),
    BannerImage = Path.Combine(installerPath, @"Resources\Icons\BannerImage.png"),
    BackgroundImage = Path.Combine(installerPath, @"Resources\Icons\BackgroundImage.png"),
    Version = Assembly.GetExecutingAssembly().GetName().Version.ClearRevision(),
    ControlPanelInfo =
    {
        Manufacturer = Environment.UserName,
        ProductIcon = Path.Combine(installerPath, @"Resources\Icons\ShellIcon.ico")
    }
};

var wixEntities = GenerateWixEntities(tempDir.FullName);
project.RemoveDialogsBetween(NativeDialogs.WelcomeDlg, NativeDialogs.VerifyReadyDlg);

BuildSingleUserMsi();
BuildMultiUserUserMsi();
Directory.Delete(tempDir.FullName, true);

void BuildSingleUserMsi()
{
    project.InstallScope = InstallScope.perUser;
    project.OutFileName = $"{projectName}-{project.Version}-SingleUser";
    project.Dirs = new Dir[]
    {
        new InstallDir(@"%AppDataFolder%\Autodesk\Revit\Addins\", wixEntities)
    };
    project.BuildMsi();
}

void BuildMultiUserUserMsi()
{
    project.InstallScope = InstallScope.perMachine;
    project.OutFileName = $"{projectName}-{project.Version}-MultiUser";
    project.Dirs = new Dir[]
    {
        new InstallDir(@"%CommonAppDataFolder%\Autodesk\Revit\Addins\", wixEntities)
    };
    project.BuildMsi();
}

WixEntity[] GenerateWixEntities(string releaseDir)
{
    return new Files().GetAllItems(releaseDir);
}