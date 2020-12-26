using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;
using LinkersX;

namespace cAlgo.Robots
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.FullAccess)]
    public class cTrader_cBot : Robot
    {
        private TicksX gu1;
        private BarsX gum1;
        private BarsX gum5;
        private BarsX gum15;
        private BarsX gum60;
        private BarsX gum240;
        private BarsX gurr10;
        private BarsX gut56;
        [Parameter(DefaultValue = 0.0)]
        public double Parameter { get; set; }

        protected override void OnStart()
        {
            gu1 = new TicksX("GBPUSD", 1, this);
            gum1 = new BarsX(ref gu1, BarType.Minute, 1);
            gum5 = new BarsX(ref gu1, BarType.Minute, 5);
            gum15 = new BarsX(ref gu1, BarType.Minute, 15);
            gum60 = new BarsX(ref gu1, BarType.Minute, 60);
            gum240 = new BarsX(ref gu1, BarType.Minute, 240);
            gurr10 = new BarsX(ref gu1, BarType.RomanRenko, 10);
            gut56 = new BarsX(ref gu1, BarType.Tick, 56);

            gum1.OnEvent += onEvent;
            gum5.OnEvent += onEvent;
            gum15.OnEvent += onEvent;
            gum60.OnEvent += onEvent;
            gum240.OnEvent += onEvent;
            gurr10.OnEvent += onEvent;
            gut56.OnEvent += onEvent;
        }

        public void onEvent(EventX e)
        {
          //Your event driven strategy fully backtestable multi instrument & timeframe
          //cTrader strategy starts here :-)
        }
    }
}
