using UnityEngine;
using System.Collections;
using System;

public class Option
{
    public int VideoId;
    public string Title;
}

public interface BaseStrat
{
    Option[] Options();
}

public class TakeDownStrat : BaseStrat
{
    Option[] options = new Option[] {
    };

    public Option[] Options()
    {
        return options;
    }
}

public class IntroStrat : BaseStrat
{
    Option[] options = new Option[] {
        new Option { Title = "What is Jiu Jitsu", VideoId = 373669869 },
        new Option { Title = "Principles", VideoId = 0 },
        new Option { Title = "Positions", VideoId = 0 },
        new Option { Title = "Basics", VideoId = 0 },
        new Option { Title = "Self Defense", VideoId = 0 },
        new Option { Title = "Other stuff", VideoId = 0 }
    };
    public Option[] Options()
    {
        return options;
    }
}


public class Intro : Base
{
    public override void Start()
    {
        text_0 = "What is Jiu Jitsu";
        text_1 = "Principles"; 
        text_2 = "Positions";
        text_3 = "Basics";
        text_4 = "Self Defense";
        text_5 = "Other stuff";
        o0 = WhatIsJiuJitsu;
        o1 = Principles;
        o2 = Positions;
        o3 = Basics;
        o4 = SelfDefense;
        o5 = OtherStuff;
    }

    void WhatIsJiuJitsu()
    {
        IsLeafNode = true;
        VideoId = 373669869;
        //Invoke the method from the base class
        DoAction();
    }

    void Principles() { }
    void Positions() { }
    void Basics() { }
    void SelfDefense() { }
    void OtherStuff() { }

}
