﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChronometerSoftUni
{
    public interface IChronometer
    {
        string GetTime { get; }

        List<string> Laps { get; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
