using System;
using System.Windows.Input;

namespace project_pp.Commands;
public class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object? parameter) => true;

    public virtual void Execute(object? parameter) { }
}
