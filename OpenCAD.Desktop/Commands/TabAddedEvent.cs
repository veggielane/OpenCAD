﻿using System.Collections.Specialized;
using System.Linq;

namespace OpenCAD.Desktop.Commands
{
    internal class TabAddedEvent
    {
        public NotifyCollectionChangedEventArgs Args { get; set; }

        public override string ToString()
        {
            return string.Format("Added {0} Tab(s)", Args.NewItems.Cast<object>().Count());
        }
    }
}