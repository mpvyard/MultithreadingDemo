﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingDemo.EventGenerator
{
    /// <summary>
    /// A stateful generator capable of producing FIX messages representing orders being entered/modified/closed in the market.
    /// 
    /// This class is *NOT* thread-safe.
    /// </summary>
    /// <remarks>
    /// </remarks>
    internal class EventProducer
    {
        private const int MAX_TRADER_COUNT = 5;
        private const int MAX_PRODUCT_COUNT = 2;

        private const double PERCENTAGE_CHANCE_CHANGE_ORDER_INSTEAD_OF_NEW = 0.6;

        private const double PERCENTAGE_CHANCE_FILL_EXISTING_ORDER = 0.2; 
        private const double PERCENTAGE_CHANCE_MODIFY_EXISTING_ORDER = 0.5;
        // Remainder is PERCENTAGE_CHANCE_CANCEL_EXISTING_ORDER = 0.3;

        private const double PERCENTAGE_CHANCE_PARTIAL_FILL = 0.5;
                
        private readonly int _maximum_concurrent_orders;
        private readonly System.Random _random;

        private List<object> _openOrders = new List<object>();

        public EventProducer(int maximum_concurrent_orders, int random_seed)
        {
            this._maximum_concurrent_orders = maximum_concurrent_orders;
            this._random = new System.Random(random_seed);
        }

        public string GenerateNextEvent()
        {
            if (_openOrders.Count == 0)
            {
                return GenerateEventForNewOrder();
            }
            if (_openOrders.Count >= this._maximum_concurrent_orders)
            {
                return GenerateEventForExistingOrder();
            }

            // Otherwise, randomly create a new, or change an existing orders.
            if (this._random.NextDouble() < PERCENTAGE_CHANCE_CHANGE_ORDER_INSTEAD_OF_NEW)
            {
                return GenerateEventForExistingOrder();
            }
            else
            {
                return GenerateEventForNewOrder();
            }  
        }

        public string[] GenerateFinalEvents()
        {
            var results = new List<string>();

            while (this._openOrders.Count > 0)
            {
                results.Add(GenerateEventToCloseOrder());
            }

            return results.ToArray();
        }

        private string GenerateEventForNewOrder()
        {
            // ---- TODO
            return "TODO";
        }

        private string GenerateEventForExistingOrder()
        {
            // ---- TODO
            return "TODO";
        }

        private string GenerateEventToCloseOrder()
        {
            // ---- TODO
            this._openOrders.RemoveAt(0);
            return "TODO";
        }

    }
}
