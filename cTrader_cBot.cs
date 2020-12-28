using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;
using LinkersX;

//This is an example of a fully event driven multi barType & timeframe && multi Instrument 
//fully backtestable cTrader Robot using LinkersX Trading API
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
        private SwingX gusw1; 
        private SwingX guswm5;
        //MarketProfilesX is a custom driven, memory wise unrestricted version of BarsX BarSeries container
        // for storing independent BarX Market Profile Bars
        private MarketProfilesX mpgu1; 
        
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
            
            //
            gusw1 = new BarX(gum1, 1); // attach SwingX High Low algorythm to gum1 1min chart
            guswm5 = new BarX(gum5, 1);

            gum1.OnEvent += onEvent;
            gum5.OnEvent += onEvent;
            gum15.OnEvent += onEvent;
            gum60.OnEvent += onEvent;
            gum240.OnEvent += onEvent;
            gurr10.OnEvent += onEvent;
            gut56.OnEvent += onEvent;
            guur200.OnEvent += onEvent; // BarX will notify us when the Bar is done.
        }

         // various event types examples... All subscribed events will execute on onEvent
        public void onEvent(EventX e)
        {
                   
          if(e.firstTickOfBar && e.bars.barType == BarType.Tick && e.bars.barsPeriod == 56)
          {
            //we got a firstTickOfBar event from the Tick.56 object x-> do something :-)
          }
          // same just easier
          if(e.firstTickOfBar && e.id == gut56.id) // check if first tick of bar and bar object is tick.56
          {
            //we got a firstTickOfBar event from the Tick.56 object x-> do something :-)
          }
          
          if(e.id == guur200.id)
          {
           //our guur200 200pips in size Ultimate Renko BarX object declared in the future has just finished the bar object x-> do something :-)
            mpgu1.add(guur200); // add the guur200 BarX object to the MarketProfilesX DataSeries Container.
              Print("UltimateRenko 200 pips BarX object just finished!" 
                    + " Point of Control by Time Profile is:" + guur200.levels.POC_byTime() 
                    + " Point of Control by volume:" +  guur200.levels.POC_byVolume()
                    + " Point of Control by Tick Count:" +  guur200.levels.POC_byTick())
          }
          
          if(e.newBarHigh && e.id == gum15.id)
          {
           //our 15 minutes GBPUSD Bar is making new Highs x-> do something :-)
          }
          
          //if 2 bars ago on a 1 minute bar series volume at Ask was bigger than same bar Volume at Bid
          if(e.bars.id == gum1.id && e.bars[e.index-2].volumeAtAsk > e.bars[e.index-2].volumeAtBid)
          {
           e.bars[e.index-2].eraseBar(); //erase bar from chart for the market profile we gonna draw)
           e.bars[e.index-2].drawMarketProfile();  // just draw a market profile Bar to the chart instead of the erased MTF bar
          }
          
          if(e._non_Farm_Employment_Change)
          {
           // watch out! Non-Farm Employment Change event in Play!
          }
         
          if(e.id == gum5.id && e.bars[e.index -3].candlestick.doji)
          {
           //if 3 bars ago on a 5 minute BarSeries the candlestick type was Doji 
          }
          
          if(e.id == gum60.id && e.ticks[e.ticks.index -5].price > e.ticks.daily[2].high)
          {
           // if the barseries is minute60 and 5 ticks ago  the tick price was higher than daily high 2 days ago
           // Since we can access the Open, Close, High and Low Times, Ask and Bid , we gonna print high price and actual time of the tick
           //   that was of the daily high 2 days ago
           Print("High of a day 2 days ago Price:" + e.daily[2].high + " Time of the days High" + e.daily[2].highTime);
          }
          
          if(e.dailyHigh  && e.bars.symbolName == "GBPUSD")
          {
          // if event is new daily high and symbol name is "GBPUSD" then print out new daily high
          Print (e.bars.symbolName + " new Daily high :" + e.bars[e.index].ClosePrices);
          }
          
          if(e.id == gum5.id && e.newSwingHigh && e.swing[0].swingHighRetracement(50))
          {
           //if event is new swing high and barseries is 5min gum5 and retracement from last swing up on a 5min chart is 50 percent
          }
          //-----------
        }
    }
}
