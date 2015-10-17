using System;
using System.Collections.Generic;
using System.Linq;
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

using System.Globalization;

namespace WpfApplication1
{
    public enum TableSize
    {
        FourXFour = 4,
        EightXEight = 8
    }

    public partial class MainWindow : Window
    {
        DrawingGroup drawingGroup;
        public MainWindow()
        {
            InitializeComponent();

            drawingGroup = new DrawingGroup();

            // Создаем объект для описания геометрической фигуры
            GeometryDrawing geometryDrawing = new GeometryDrawing();

            // Описываем и сохраняем геометрию квадрата
            RectangleGeometry rectGeometry = new RectangleGeometry();
            rectGeometry.Rect = new Rect(0, 0, 10, 10);
            geometryDrawing.Geometry = rectGeometry;

            // Настраиваем перо и кисть
            geometryDrawing.Pen = new Pen(Brushes.Red, 0.005);// Перо рамки
            geometryDrawing.Brush = Brushes.LightBlue;// Кисть закраски

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);





           

            GeometryDrawing ellipsgeomy = new GeometryDrawing();

            EllipseGeometry elgeometry = new EllipseGeometry(new Point(5, 5), 2, 2);

            ellipsgeomy.Geometry = elgeometry;

            ellipsgeomy.Brush = Brushes.White;

            drawingGroup.Children.Add(ellipsgeomy);





            
        }

        private void FourRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CreateTable(TableSize.FourXFour);
        }

        private void EightRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CreateTable(TableSize.EightXEight);
        }

        private void CreateTable(TableSize tableSize)
        {
            canvas.Children.Clear();
            int lineSize = (int)tableSize;

            for (int i = 0; i < lineSize; i++)
            {
                for (int j = 0; j < lineSize; j++)
                {
                    const int squareSize = 50;
                    const int padding = 1;
                    //Rectangle rect = new Rectangle { Width = squareSize, Height = squareSize, Stroke = Brushes.Black, Fill = Brushes.Brown };

                    Image img = new Image { Width = squareSize, Height = squareSize };

                    img.Source = new DrawingImage(drawingGroup);
                    

                    Canvas.SetLeft(img, i * (img.Width + padding));
                    Canvas.SetTop(img, j * (img.Height + padding));
                    canvas.Children.Add(img);
                }
            }
        }

    }
}
