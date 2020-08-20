using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FireStats.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditorWindows.xaml
    /// </summary>
    public partial class EmployeeEditorWindows
    {

        #region DependencyProperty

        #region FirstName : string - Имя
        public static DependencyProperty FirstNameProperty = DependencyProperty.Register(
            nameof(FirstName),
            typeof(string),
            typeof(EmployeeEditorWindows),
            new PropertyMetadata(null));
        [Description("Имя")]
        public string FirstName { get => (string)GetValue(FirstNameProperty); set => SetValue(FirstNameProperty, value); }
        #endregion

        #region SurName : string - Фамилия
        public static DependencyProperty SurNameProperty = DependencyProperty.Register(
           nameof(SurName),
           typeof(string),
           typeof(EmployeeEditorWindows),
           new PropertyMetadata(null));
        [Description("Фамилия")]
        public string SurName { get => (string)GetValue(SurNameProperty); set => SetValue(SurNameProperty, value); }
        #endregion

        #region Patronymic : string - Отчество
        public static DependencyProperty PatronymicProperty = DependencyProperty.Register(
          nameof(Patronymic),
          typeof(string),
          typeof(EmployeeEditorWindows),
          new PropertyMetadata(null));
        [Description("Отчество")]
        public string Patronymic { get => (string)GetValue(PatronymicProperty); set => SetValue(PatronymicProperty, value); }
        #endregion

        #region Birthday : DateTime - День рождения
        public static DependencyProperty BirthdayProperty = DependencyProperty.Register(
           nameof(Birthday),
           typeof(DateTime),
           typeof(EmployeeEditorWindows),
           new PropertyMetadata(null));
        [Description("День рождения")]
        public DateTime Birthday { get => (DateTime) GetValue(BirthdayProperty); set => SetValue(BirthdayProperty, value); }
        #endregion

        #region Position : string - Должность
        public static DependencyProperty PositionProperty = DependencyProperty.Register(
           nameof(Position),
           typeof(string),
           typeof(EmployeeEditorWindows),
           new PropertyMetadata(null));
        [Description("Должность")]
        public string Position { get => (string)GetValue(PositionProperty); set => SetValue(PositionProperty, value); }
        #endregion

        #region Rank : string - Звание
        public static DependencyProperty RankProperty = DependencyProperty.Register(
           nameof(Rank),
           typeof(string),
           typeof(EmployeeEditorWindows),
           new PropertyMetadata(null));
        [Description("Звание")]
        public string Rank { get => (string)GetValue(RankProperty); set => SetValue(RankProperty, value); }
        #endregion

        #region Note : string - Заметки
        public static DependencyProperty NoteProperty = DependencyProperty.Register(
           nameof(Note),
           typeof(string),
           typeof(EmployeeEditorWindows),
           new PropertyMetadata(null));
        [Description("Заметки")]
        public string Note { get => (string) GetValue(NoteProperty); set => SetValue(NoteProperty, value); }
        #endregion

        #endregion



        public EmployeeEditorWindows()
        {
            InitializeComponent();
        }
    }
}
