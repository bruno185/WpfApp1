using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string machaine = "ABCD";
     
        public MainWindow()
        {
            InitializeComponent();
            UpdatLabel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            while (lb.Items.Count != 100)
            { 
                DoAlea();
            }
            UpdatLabel();
            //int entier = aleatoire.next(); //Génère un entier aléatoire positif
            //int entierUnChiffre = aleatoire.next(10); //Génère un entier compris entre 0 et 9
            //int mois = aleatoire.Next(1, 13); // Génère un entier compris entre 1 et 12
        }

        private void DoAlea()
        {
            // init.
                string s;
                Random aleatoire = new Random();
                lb.Items.Clear();    
            // traitement
                int alea = aleatoire.Next(1, 101);
                for (int i=1; i<=alea; i++) {
                        s = i.ToString() + " - " + machaine;
                        lb.Items.Add(s);
                    }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lb.Items.Clear();
            UpdatLabel();

        }

        private void UpdatLabel()
        {
            lab1.Content = lb.Items.Count.ToString() + " éléments.";
        }

        private void DrawPolygon()
        {
            // https://www.c-sharpcorner.com/UploadFile/mahesh/polygon-in-wpf/ 
            // et articles suivants
            // Create a blue and a black Brush  
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            // Create a Polygon  
            Polygon yellowPolygon = new Polygon();
            yellowPolygon.Stroke = blackBrush;
            yellowPolygon.Fill = yellowBrush;
            yellowPolygon.StrokeThickness = 1;
            // Create a collection of points for a polygon  
            System.Windows.Point Point1 = new System.Windows.Point(50, 100);
            System.Windows.Point Point2 = new System.Windows.Point(200, 100);
            System.Windows.Point Point3 = new System.Windows.Point(200, 200);
            System.Windows.Point Point4 = new System.Windows.Point(300, 30);
            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(Point1);
            polygonPoints.Add(Point2);
            polygonPoints.Add(Point3);
            polygonPoints.Add(Point4);
            // Set Polygon.Points properties  
            yellowPolygon.Points = polygonPoints;
            // Add Polygon to the page  
            canvas1.Children.Add(yellowPolygon);
        }

        private void DrawClick(object sender, RoutedEventArgs e)
        {
            int coef = 7;
            // NB : Cf. XAML : 2 canvas imbriqués pour faire le clipping 
            // Cf : https://stackoverflow.com/questions/6684904/how-can-i-get-wpfs-cliptobounds-to-work

            Line l = new Line();
            l.Stroke = Brushes.Red;
            l.StrokeThickness = 1;
            l.X1 = 0;
            l.Y1 = 0;
            l.X2 = canvas1.ActualWidth;
            l.Y2 = canvas1.ActualHeight;
            canvas1.Children.Add(l);

            for (int x = 0; x < 1000; x++)
            {
                l = new Line();
                l.Stroke = Brushes.Black;
                l.StrokeThickness = 1;
                l.X1 = x * coef;
                l.Y1 = 0;
                l.X2 = canvas1.ActualWidth;
                l.Y2 = canvas1.ActualHeight;
                canvas1.Children.Add(l);
            }

            DrawPolygon();
        }
    }
}
