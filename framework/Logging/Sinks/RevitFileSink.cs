using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Formatting;
using System.IO;

namespace RevitSolutionTemplate.Framework.Logging.Sinks;

public class RevitFileSink : ILogEventSink
{
    private readonly string _defaultTemplate =
        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}";

    private readonly string _path;
    private readonly ITextFormatter _textFormatter;

    public RevitFileSink(string path, ITextFormatter? textFormatter = null)
    {
        _path = path;
        _textFormatter = textFormatter ?? new MessageTemplateTextFormatter(_defaultTemplate);
    }

    public void Emit(LogEvent logEvent)
    {
        using var streamWriter = new StreamWriter(_path, true);
        _textFormatter.Format(logEvent, streamWriter);
    }
}
