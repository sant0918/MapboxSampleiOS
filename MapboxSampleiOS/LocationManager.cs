using System;
using System.Collections.Generic;
using System.Text;
using CoreLocation;
using Foundation;

namespace StateMaps
{
    public class LocationManager
    {
        protected CLLocationManager locMgr;

        public LocationManager()
        {
            this.locMgr = new CLLocationManager();
            this.locMgr.PausesLocationUpdatesAutomatically = false;

           if(UI)
        }

    }
}
