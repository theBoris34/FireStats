using FireStats.WPF.Infrastructure.Commands.Base;
using System;

namespace FireStats.WPF.Infrastructure.Commands
{

    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        /// <summary>
        /// Действия которые может выполнять. Execute и CanExecute.
        /// </summary>
        /// <param name="Execute"></param>
        /// <param name="CanExecute"></param>
        public LambdaCommand(Action<object> Execute, Func<object,bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }


        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _Execute(parameter);
        }
    }
}
