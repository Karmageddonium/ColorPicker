using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace ColorPickerWPF.Core.Code
{
    public class BindableUserControl : UserControl, INotifyPropertyChanged
    {
        #region public methods
        /// <summary>
        /// Метод для уведомления об изменении свойства модели представления - наследника.
        /// Требуется вызывать при изменении свойства модели представления, к которому есть привязка в представлении!
        /// </summary>
        /// <param name="aProp"> Имя измененного свойства </param>
        public void OnPropertyChanged([CallerMemberName] string aProp = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aProp));
        }
        #endregion

        #region public events
        /// <summary>
        /// Событие изменения свойства модели представления - наследника
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
