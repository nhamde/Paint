using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   

    public partial class MainWindow : Window
    {
        Line objLine = null;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void brushSizeChanged(object sender, SelectionChangedEventArgs e)
        { 
            ComboBox cb = sender as 
        }


        private void brushColorChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void modeChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            Point startPt = e.GetPosition(canvas);
            objLine = new Line();
            objLine.Stroke = Brushes.Brown;
            objLine.X1 = startPt.X;
            objLine.Y1 = startPt.Y;
            objLine.X2 = startPt.X;
            objLine.Y2 = startPt.Y;

            canvas.Children.Add(objLine);
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (objLine == null)
                return;

            Point currentPt = e.GetPosition(relativeTo: canvas);
            objLine.X2 = currentPt.X;
            objLine.Y2 = currentPt.Y;
        }

        private void mouseUp(object sender, MouseButtonEventArgs e)
        {
            objLine = null;
        }
    }
}
