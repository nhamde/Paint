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
        bool paintStarted = false;
        Line objLine = null;
        string drawMode;
        Point initialPt;
        Brush brush;
        int size;
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
            string[] selectedSize = brushSize.SelectedItem.ToString().Split();
            size = int.Parse(selectedSize[1]);
        }
        private void brushColorChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] selectedColor = brushColor.SelectedItem.ToString().Split();
            switch(selectedColor[1])
            {
                case "Red":
                    brush = Brushes.Red;
                    break;
                case "Green":
                    brush = Brushes.Green;
                    break;
                case "Blue":
                    brush = Brushes.Blue;
                    break;
                case "Yellow":
                    brush = Brushes.Yellow;
                    break;
                case "Orange":
                    brush = Brushes.Orange;
                    break;
            }
        }
        private void modeChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] selectedMode = mode.SelectedItem.ToString().Split();
            if (selectedMode[1] == "FreeDraw")
            {
                drawMode = "freeStyle";
            }
            else
            {
                drawMode = "straightLine";
            }
        }
        private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            if (drawMode == "straightLine")
            {
                paintStarted = true;
                Point startPt = e.GetPosition(canvas);
                objLine = new Line();
                objLine.Stroke = brush;
                objLine.StrokeThickness = size;
                objLine.X1 = startPt.X;
                objLine.Y1 = startPt.Y;
                objLine.X2 = startPt.X;
                objLine.Y2 = startPt.Y;
                canvas.Children.Add(objLine);
            }
            else
            {
                paintStarted = true;
                initialPt = e.GetPosition(canvas);
                objLine = new Line();
                objLine.Stroke = brush;
                objLine.StrokeThickness = size;
                objLine.X1 = initialPt.X;
                objLine.Y1 = initialPt.Y;
            }
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (paintStarted)
            {
                if (drawMode == "straightLine")
                {   
                    Point currentPt = e.GetPosition(relativeTo: canvas);
                    objLine.X2 = currentPt.X;
                    objLine.Y2 = currentPt.Y;
                }
                else if (drawMode == "freeStyle")
                {
                    objLine = new Line();
                    objLine.Stroke = brush;
                    objLine.StrokeThickness = size;
                    objLine.X1 = initialPt.X;
                    objLine.Y1 = initialPt.Y;

                    Point currentPt = e.GetPosition(relativeTo: canvas);
                    objLine.X2 = currentPt.X;
                    objLine.Y2 = currentPt.Y;
                    canvas.Children.Add(objLine);
                    initialPt = currentPt;
                }
            }
        }
        private void mouseUp(object sender, MouseButtonEventArgs e)
        {
            objLine = null;
            paintStarted = false;
        }
    }
}
