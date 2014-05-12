using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using Windows.UI.Popups;
using Microsoft.Phone.Maps;
using Microsoft.Phone.Maps.Services;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace MilbatProject
{

    public partial class StoresPage : PhoneApplicationPage
    {
        private GeoCoordinate MyCoordinate = null;


        private double _accuracy = 0.0;    
        public StoresPage()
        {
            
            InitializeComponent();
            MyMap.Center = new GeoCoordinate(32.0051322, 34.8841922);
            MyMap.SetView(new GeoCoordinate(32.0051322, 34.8841922), 11);
            MapLayer mapLayer = new MapLayer();

            if (MyCoordinate != null)
                {
                    DrawAccuracyRadius(mapLayer);
                    DrawMapMarker(MyCoordinate, Colors.Red, mapLayer);
                }
            for (int i = 0; i < StoresMainPage.VM.StoresCollection.Count; i++)
            {
                double longt = StoresMainPage.VM.StoresCollection[i].Posx;
                double langt = StoresMainPage.VM.StoresCollection[i].Posy;
                DrawMapMarker(new GeoCoordinate(longt, langt), Colors.Red, mapLayer);
            }
            MyMap.Layers.Add(mapLayer);
            //Map a = new Map();
            MyMap.Focus();
        }
    
    
    
    private ReverseGeocodeQuery MyReverseGeocodeQuery = null;

    
    
    private void DrawMapMarkers()
    {
        MyMap.Layers.Clear();
        MapLayer mapLayer = new MapLayer();
         
        // Draw marker for current position
        if (MyCoordinate != null)
        {
            DrawAccuracyRadius(mapLayer);
            DrawMapMarker(MyCoordinate, Colors.Red, mapLayer);
        }
         
        
         
        MyMap.Layers.Add(mapLayer);
    }

    private void DrawMapMarker(GeoCoordinate coordinate, Color color, MapLayer mapLayer)
    {
        // Create a map marker
        Polygon polygon = new Polygon();
        polygon.Points.Add(new Point(0, 0));
        polygon.Points.Add(new Point(0, 75));
        polygon.Points.Add(new Point(25, 0));
        polygon.Fill = new SolidColorBrush(color);
        Image img = new Image();

        // Enable marker to be tapped for location information
        polygon.Tag = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
        polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);
        

        // Create a MapOverlay and add marker
        MapOverlay overlay = new MapOverlay();
        overlay.Content = polygon;
        overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
        overlay.PositionOrigin = new Point(0.0, 1.0);
        mapLayer.Add(overlay);
    }
    private void DrawAccuracyRadius(MapLayer mapLayer)
    {
        // The ground resolution (in meters per pixel) varies depending on the level of detail
        // and the latitude at which it’s measured. It can be calculated as follows:
        double metersPerPixels = (Math.Cos(MyCoordinate.Latitude * Math.PI / 180) * 2 * Math.PI * 6378137) / (256 * Math.Pow(2, MyMap.ZoomLevel));
        double radius = _accuracy / metersPerPixels;

        Ellipse ellipse = new Ellipse();
        ellipse.Width = radius * 2;
        ellipse.Height = radius * 2;
        ellipse.Fill = new SolidColorBrush(Color.FromArgb(75, 200, 0, 0));

        MapOverlay overlay = new MapOverlay();
        overlay.Content = ellipse;
        overlay.GeoCoordinate = new GeoCoordinate(MyCoordinate.Latitude, MyCoordinate.Longitude);
        overlay.PositionOrigin = new Point(0.5, 0.5);
        mapLayer.Add(overlay);
    }
    
    
    
    private void Marker_Click(object sender, EventArgs e)
    {
        Polygon p = (Polygon)sender;
        GeoCoordinate geoCoordinate = (GeoCoordinate)p.Tag;
        MyReverseGeocodeQuery = new ReverseGeocodeQuery();
        MyReverseGeocodeQuery.GeoCoordinate = new GeoCoordinate(geoCoordinate.Latitude, geoCoordinate.Longitude);
        MyReverseGeocodeQuery.QueryCompleted += ReverseGeocodeQuery_QueryCompleted;
        MyReverseGeocodeQuery.QueryAsync();
    }
    
    private void ReverseGeocodeQuery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
    {
        if (e.Error == null)
        {
            if (e.Result.Count > 0)
            {
                MapAddress address = e.Result[0].Information.Address;
                String msgBoxText = "";
                string storeName = StoresMainPage.VM.GetName(e.Result[0].GeoCoordinate);
                if (address.Country.Length > 0) msgBoxText += "האם ברצונך לנווט לשם?";
                MessageBoxResult m = MessageBox.Show(msgBoxText, storeName, MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.OK)
                {
                    RequestDirections(e.Result[0].GeoCoordinate.Latitude.ToString(),
                        e.Result[0].GeoCoordinate.Longitude.ToString(),
                        storeName);
                }
            } 
            
        }
    }
    async void RequestDirections(string latitude, string longitude, string name)
    {

        // Assemble the Uri to launch.
        Uri uri = new Uri("ms-drive-to:?destination.latitude=" + latitude +
            "&destination.longitude=" + longitude + "&destination.name=" + name);
        // The resulting Uri is: "ms-drive-to:?destination.latitude=47.6451413797194
        //  &destination.longitude=-122.141964733601&destination.name=Redmond, WA")

        // Launch the Uri.
        var success = await Windows.System.Launcher.LaunchUriAsync(uri);

        if (success)
        {
            // Uri launched.
        }
        else
        {
            // Uri failed to launch.
        }
    }

    
        private void Return_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/StoresMainPage.xaml", UriKind.Relative));
        }
    }
}