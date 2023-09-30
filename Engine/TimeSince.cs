//todo TimeSince class
namespace Engine;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
 
public class TimeSince
{

    long _time;
    public TimeSince()
    {
        _time = DateTime.Now.Ticks;
    }

    public TimeSince(float d)
    {
        _time = DateTime.Now.Ticks;
        SetDelta(d);
    }

    public void Reset()
    {

    }
    public float GetDelta() 
    {
        return (float)TimeSpan.FromTicks(DateTime.Now.Ticks - _time).TotalSeconds;
    }
    public void SetDelta(float delt) 
    {
        _time = DateTime.Now.Ticks + (TimeSpan.FromSeconds((double)delt).Ticks);
    }
    public static implicit operator float(TimeSince d) => d.GetDelta();
    public static implicit operator TimeSince(float b) => new TimeSince((float)b);
    public static implicit operator TimeSince(int b) => new TimeSince((float)b);
}
 