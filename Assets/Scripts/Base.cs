using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class Base
{
    public void Assign(BaseStrat strat)
    {
        _strat = strat;
    }

    BaseStrat _strat;

    Option[] Options
    {
        get { return _strat.Options(); }
    }

    public string text_0; //  {  get { return Options[0].Text; } }
    public string text_1;
    public string text_2;
    public string text_3;
    public string text_4;
    public string text_5;

    // public class Option { public int VideoId; public string Title; }
    // Array<Option> _listOptions
    public bool IsLeafNode;
    public int VideoId;

    public UnityAction o0;//=  -> { VideoId =  Options[0].VideoId; DoAction(); }
    public UnityAction o1;// () { OpenNode(1); }
    public UnityAction o2;
    public UnityAction o3;
    public UnityAction o4;
    public UnityAction o5;

    void OpenNode(int index)
    {
        var option = Options[index];
        //
    }

    
    private Action _action;
    public void SetAction(Action action)
    {
        _action = action;
    }

    public abstract void Start();

    public void DoAction()
    {
        _action();
    }
}

