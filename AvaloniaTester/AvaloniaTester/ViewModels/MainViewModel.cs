﻿using Avalonia.Platform;
using NavGraphTools;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace AvaloniaTester.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Fields
    private int _LoopCount = 0;
    private long _ElapsedTime = 0, _AvgElapsed = 0;
    private List<long> Times = new List<long>();
    private string _ButtonContent = "Start";
    private Thread? TRunner = null;
    private bool _RunFlag = false;
    private static ReadonlyNavGraph? NG = null;
    #endregion

    #region Properties
    public int LoopCount
    {
        get => _LoopCount;
        set => this.RaiseAndSetIfChanged(ref _LoopCount, value);
    }

    public string ElapsedTime
    {
        get => $"{_ElapsedTime:n2}ms";
        set => this.RaiseAndSetIfChanged
            (ref _ElapsedTime, long.Parse(value));
    }

    public string ButtonContent
    {
        get => _ButtonContent;
        set => this.RaiseAndSetIfChanged(ref _ButtonContent, value);
    }

    private bool RunFlag
    {
        get => _RunFlag;
        set
        {
            _RunFlag = value;

            ButtonContent = _RunFlag ? "Stop" : "Start";
        }
    }

    public long AvgElapsed
    {
        get => _AvgElapsed;
        set => this.RaiseAndSetIfChanged(ref _AvgElapsed, value);
    }
    #endregion


    public void Command_StartStop()
    {
        if (TRunner == null || RunFlag == false)
        {
            TRunner = new Thread(Run);
            RunFlag = true;
            TRunner.Start();
        }
        else
        {
            RunFlag = false;
            AvgElapsed = Average();
        }
    }

    private async void Run()
    {
        Stopwatch SW = new Stopwatch();

        while (_RunFlag)
        {
            NG = new ReadonlyNavGraph();

            SW.Restart();

            Uri T = new Uri("avares://AvaloniaTester/Assets/Johnstone.ajson");

            if (AssetLoader.Exists(T))
            {
                using (var Stm = AssetLoader.Open(T))
                {
                    if (Stm != null)
                    { NG.Deserialise(Stm); }
                }
            }

            SW.Stop();

            Times.Add(SW.ElapsedMilliseconds);
            ElapsedTime = SW.ElapsedMilliseconds.ToString();

            LoopCount += 1;

            NG = null;
        }
    }

    private long Average()
    {
        long Val = 0;

        foreach (var T in Times)
        { Val += T; }

        return Val / Times.Count;
    }
}
