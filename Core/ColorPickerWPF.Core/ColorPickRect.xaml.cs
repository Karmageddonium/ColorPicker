using ColorPickerWPF.Core.Code;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorPickerWPF.Core
{
    //TODO Make common with ColorPicRow
    //TODO Migrate to .Net Framework
    /// <summary>
    /// Логика взаимодействия для ColorPickRect.xaml
    /// </summary>
    public partial class ColorPickRect : BindableUserControl
    {
        public event EventHandler OnPick;

        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        private SolidColorBrush colorBrush;

        public SolidColorBrush ColorBrush
        {
            get
            {
                (colorBrush ?? (colorBrush = new SolidColorBrush())).Color = Color;
                return colorBrush;
            }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(Color),
                typeof(ColorPickRect), new FrameworkPropertyMetadata(Colors.White,  
                    new PropertyChangedCallback((d, a) => 
                    { 
                        ((ColorPickRect)d).OnPropertyChanged(nameof(ColorBrush)); 
                    })));


        public ColorPickerDialogOptions Options { get; set; }
        public ColorPickRect()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                Color color;
                Color? initialColor = null;
                if (ColorDisplayGrid.Background is SolidColorBrush scb)
                {
                    initialColor = scb.Color;
                }
                if (ColorPickerWindow.ShowDialog(out color, Options, initialColor: initialColor))
                {
                    Color = color;
                    OnPick?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
