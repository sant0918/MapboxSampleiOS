using System;
using System.Collections.Generic;
using System.Text;
using CoreLocation;
using Foundation;
using UIKit;
namespace StateMaps
{
    public class LocationManager
    {
        protected CLLocationManager locMgr;
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

        public LocationManager()
        {
            this.locMgr = new CLLocationManager();
            this.locMgr.PausesLocationUpdatesAutomatically = false;

             // event for the location changing
            

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization();
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(9,0))
            {
                locMgr.AllowsBackgroundLocationUpdates = true;
            }

            LocationUpdated += PrintLocation;
        }
       
        public CLLocationManager LocMgr
        {
            get
            {
                return this.LocMgr;
            }
        }

        public void StartLocationUpdates()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                LocMgr.DesiredAccuracy = 1;
                LocMgr.LocationsUpdated += (sender, e) =>
                {
                    LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length -1]));
                };

                LocMgr.StartUpdatingLocation();
            }
            else
            {
                // TODO: Stop user from using app. - Javier
            }
        }

        //This will keep going in the background and the foreground
        public void PrintLocation(object sender, LocationUpdatedEventArgs e)
        {
            CLLocation location = e.Location;
            Console.WriteLine("Altitude: " + location.Altitude + " meters");
            Console.WriteLine("Longitude: " + location.Coordinate.Longitude);
            Console.WriteLine("Latitude: " + location.Coordinate.Latitude);
            Console.WriteLine("Course: " + location.Course);
            Console.WriteLine("Speed: " + location.Speed);
        }


    }

    public class LocationUpdatedEventArgs : EventArgs
    {
        CLLocation location;

        public LocationUpdatedEventArgs(CLLocation location)
        {
            this.location = location;
        }

        public CLLocation Location
        {
            get { return location; }
        }
    }
}
