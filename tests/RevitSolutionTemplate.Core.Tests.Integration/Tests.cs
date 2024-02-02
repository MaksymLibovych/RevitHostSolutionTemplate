using Autodesk.Revit.UI;
using FluentAssertions;
using NUnit.Framework;

namespace RevitSolutionTemplate.Core.Tests.Integration;

public class Tests
{
    [Test]
    public void UIApplication_ShouldNotBeNull_WhenRevitProjectIsOpen(UIApplication uiApplication)
    {
        uiApplication.Should().NotBeNull();
    }
}
