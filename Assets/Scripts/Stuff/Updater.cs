﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Updater : MonoSingleton<Updater>
{
    public static Thread MainThread = null;

    public event Action OnUpdate;
    public event Action OnLateUpdate;
    private List<Action> NextFrameList
    {
        get;
        set;
    }

    public Updater()
    {
        NextFrameList = new List<Action>();
    }

    protected override void Awake()
    {
        base.Awake();
        MainThread = Thread.CurrentThread;
    }

    void Update()
    {
        // Execute On Main Thread
        RunNextFrameList();

        // do updater
        if (OnUpdate != null)
        {
            OnUpdate();
        }
    }

    void LateUpdate()
    {
        // do updater
        if (OnLateUpdate != null)
        {
            OnLateUpdate();
        }
    }

    /*
     * Call this method from other thread to run UI and other stuff on mainthread, will be executed at the end of next frame
     * Use it like -> 
     *      Updater.Instance.ExecuteNextFrame(() => {
     *          [...]
     *      });
     * or
     *      ExecuteNextFrame(delegate { [...] });
     */
    public void ExecuteNextFrame(Action method)
    {
        NextFrameList.Add(method);
    }

    // execute methods
    private void RunNextFrameList()
    {
        // only run if list is not empty
        if (NextFrameList.Count == 0)
            return;

        for (int i = NextFrameList.ToList().Count - 1; i >= 0; i--)
        {
            var method = NextFrameList[i];
            if (method != null)
                method();
            else
                UnityEngine.Debug.LogWarning("Timer Callback Method is null");
            NextFrameList.RemoveAt(i);
        }
    }

}
