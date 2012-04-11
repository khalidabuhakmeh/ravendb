﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RavenFS.Studio.Infrastructure
{
    public class DataFetchErrorEventArgs : EventArgs
    {
        public Exception Error { get; private set; }

        public DataFetchErrorEventArgs(Exception error)
        {
            Error = error;
        }
    }
}
