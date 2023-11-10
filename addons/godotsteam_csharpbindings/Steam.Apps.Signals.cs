using System;
using Godot;

namespace GodotSteam;

public static partial class Steam
{
    public delegate void DlcInstalledEventHandler(long app);
    private static event DlcInstalledEventHandler DlcInstalledEvent;
    static Action<long> _dlcInstalledAction = (app) =>
    {
        DlcInstalledEvent?.Invoke(app);
    };
    public static event DlcInstalledEventHandler DlcInstalled
    {
        add
        {
            if(DlcInstalledEvent == null)
            {
                GetInstance().Connect(Signals.DlcInstalled, Callable.From(_dlcInstalledAction));
            }
            DlcInstalledEvent += value;
        }
        remove 
        { 
            DlcInstalledEvent -= value; 
            if(DlcInstalledEvent == null)
            {
                GetInstance().Disconnect(Signals.DlcInstalled, Callable.From(_dlcInstalledAction));
            }
        }
    }
    
    public delegate void FileDetailsResultEventHandler(long result, long fileSize, long fileHash, long flags);
    private static event FileDetailsResultEventHandler FileDetailsResultEvent;
    static Action<long, long, long, long> _fileDetailsResultAction = (result, fileSize, fileHash, flags) =>
    {
        FileDetailsResultEvent?.Invoke(result, fileSize, fileHash, flags);
    };
    public static event FileDetailsResultEventHandler FileDetailsResult
    {
        add
        {
            if(FileDetailsResultEvent == null)
            {
                GetInstance().Connect(Signals.FileDetailsResult, Callable.From(_fileDetailsResultAction));
            }
            FileDetailsResultEvent += value;
        }
        remove 
        { 
            FileDetailsResultEvent -= value; 
            if(FileDetailsResultEvent == null)
            {
                GetInstance().Disconnect(Signals.FileDetailsResult, Callable.From(_fileDetailsResultAction));
            }
        }
    }
    
    private static event Action NewLaunchUrlParametersEvent;
    static Action _newLaunchUrlParametersAction = () =>
    {
        NewLaunchUrlParametersEvent?.Invoke();
    };
    public static event Action NewLaunchUrlParameters
    {
        add
        {
            if(NewLaunchUrlParametersEvent == null)
            {
                GetInstance().Connect(Signals.NewLaunchUrlParameters, Callable.From(_newLaunchUrlParametersAction));
            }
            NewLaunchUrlParametersEvent += value;
        }
        remove 
        { 
            NewLaunchUrlParametersEvent -= value; 
            if(NewLaunchUrlParametersEvent == null)
            {
                GetInstance().Disconnect(Signals.NewLaunchUrlParameters, Callable.From(_newLaunchUrlParametersAction));
            }
        }
    }
    
    public delegate void TimedTrialStatusEventHandler(uint appId, bool isOffline, long secondsAllowed, long secondsPlayed);
    private static event TimedTrialStatusEventHandler TimedTrialStatusEvent;
    static Action<uint, bool, long, long> _timeTrialStatusAction = (appId, isOffline, secondsAllowed, secondsPlayed) =>
    {
        TimedTrialStatusEvent?.Invoke(appId, isOffline, secondsAllowed, secondsPlayed);
    };
    public static event TimedTrialStatusEventHandler TimedTrialStatus
    {
        add
        {
            if(TimedTrialStatusEvent == null)
            {
                GetInstance().Connect(Signals.TimedTrialStatus, Callable.From(_timeTrialStatusAction));
            }
            TimedTrialStatusEvent += value;
        }
        remove 
        { 
            TimedTrialStatusEvent -= value; 
            if(TimedTrialStatusEvent == null)
            {
                GetInstance().Disconnect(Signals.TimedTrialStatus, Callable.From(_timeTrialStatusAction));
            }
        }
    }
}