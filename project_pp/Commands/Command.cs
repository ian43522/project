using System;

namespace project_pp.Commands;
public class Command : CommandBase
{
    private readonly Action<object?>? _execute;
    private readonly Func<object?, bool>? _canExecute;

    public Command() { }
    public Command(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this._execute = execute;
        this._canExecute = canExecute;
    }
    public override bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }
    public override void Execute(object? parameter)
    {
        _execute?.Invoke(parameter);
    }
}
