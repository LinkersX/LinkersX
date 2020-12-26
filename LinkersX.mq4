//+------------------------------------------------------------------+
//|                                                     LinkersX.mq4 |
//|                                             LinkersX Trading API |
//|                                                                  |
//+------------------------------------------------------------------+
#property copyright "LinkersX Trading API"
#property link      ""
#property version   "1.00"
#property strict
#property indicator_chart_window

#import "LinkersX.mqh"

        TicksX gu1;
        BarsX gum1;
        BarsX gum5;
        BarsX gum15;
        BarsX gum60;
        BarsX gum240;
        BarsX gurr10;
        BarsX gut56;
//+------------------------------------------------------------------+
//| Custom indicator initialization function                         |
//+------------------------------------------------------------------+
int OnInit()
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
   
   return(INIT_SUCCEEDED);
  }
        
        public void onEvent(EventX e)
        {
          //Your event driven strategy fully backtestable multi instrument & timeframe
          //Metatrader Tick based strategy starts here :-)
        }