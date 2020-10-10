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
    public partial class ColorPickRect : UserControl
    {
        public event EventHandler OnPick;

        public Color Color { get; set; }

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
                    SetColor(color);
                    OnPick?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        public void SetColor(Color color)
        {
            Color = color;
            ColorDisplayGrid.Background = new SolidColorBrush(color);
        }
    }
}
