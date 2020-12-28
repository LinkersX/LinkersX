using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;
using LinkersX;

//This is an example of a fully event driven cTrader Robot using LinkersX Trading API
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
        private BarsX guur200;
        
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
            
            // declare ONE BarX bar starting from startTime in the Future
            // UltimateRenko BarType 200 pips in size.
            guur200 = new BarX(ref gu1, startTime, BarType.UltimateRenko, 200); 

            gum1.OnEvent += onEvent;
            gum5.OnEvent += onEvent;
            gum15.OnEvent += onEvent;
            gum60.OnEvent += onEvent;
            gum240.OnEvent += onEvent;
            gurr10.OnEvent += onEvent;
            gut56.OnEvent += onEvent;
            guur200.OnEvent += onEvent; // BarX will notify us when the Bar is done.
        }

         // various event types... All subscribed events will execute on onEvent
        public void onEvent(EventX e)
        {
          if(e.firstTickOfBar && e.bars.barType == BarType.Tick && e.bars.barsPeriod == 56)
          {
            //we got a firstTickOfBar event from the Tick.56 object x-> do something :-)
          }
          // same just easier
          if(e.firstTickOfBar && e.bars.id == gut56.id) // check if first tick of bar and bar object is tick.56
          {
            //we got a firstTickOfBar event from the Tick.56 object x-> do something :-)
          }
          
          if(e.bar.id == guur200.id)
          {
           //our guur200 200pips in size Ultimate Renko BarX object declared in the future has just finished the bar object x-> do something :-)
          }
          
          if(e.newBarHigh &&  == e.bars.id == gum15.id)
          {
           //our 15 minutes GBPUSD Bar is making new Highs x-> do something :-)
          }
        }
    }
}
