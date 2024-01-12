﻿using Nuke.Common.IO;

sealed partial class Build
{
    const string Version = "1.0.0";
    readonly AbsolutePath ArtifactsDirectory = RootDirectory / "output";

    protected override void OnBuildInitialized()
    {
        Configurations = new[]
        {
            "Release*",
            "Installer*"
        };
    }
}
