using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FireStats.WPF.Login.ViewModel.Base 
{

    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// Обнавление значений свойства. Разрешает кольцевые обновления свойств.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Ссылка на свойство.</param>
        /// <param name="value">Новое значение.</param>
        /// <param name="PropertyName">Имя свойства.</param>
        /// <returns>Возвращает true если свойство изменилось, false если свойство изменено не было.</returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
            //Освобождение управляемых ресурсов
        }
    }
}
