using UnityEngine;
using System;

[Serializable]
public struct TelemetryEvent<T>
{
    // Handles showing errors about non-serializable types, only once each.
    static bool _hasCheckedSerialization;

    public bool NeedsSerializationCheck() {
        if (_hasCheckedSerialization) return false;
        _hasCheckedSerialization = true;
        return true;
    }

    public string sessionKey;
    public string section;
    public string eventType;

    public int sequence;

    public long timecode;
    public DateTimeOffset time {
        get {
            return DateTimeOffset.FromUnixTimeMilliseconds(timecode);
        }
        set {
            timecode = ToTimeCode(value);
        }
    }
    static long ToTimeCode(DateTimeOffset time) {
        return time.ToUnixTimeMilliseconds();
    }

    public T data;
    
    public TelemetryEvent(string eventType, T data = default) {
        sessionKey = null;
        section = null;        
        this.eventType = eventType;
        this.data = data;
        sequence = -1;

        timecode = ToTimeCode(DateTimeOffset.UtcNow);
    }
}