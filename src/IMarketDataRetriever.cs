﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MarketSimulator
{
    /// <summary>
    /// IMarketDataRetriever
    /// </summary>
    public interface IMarketDataRetriever
    {
        List<MarketData> Retrieve(string symbol);
    }
}
