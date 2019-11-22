using System;
using UnityEngine;

[Serializable]
public class EventModel
{

    public LogEventType type;
    public string[] data;

    public EventModel(LogEventType type, params string[] data)
    {
        this.type = type;
        this.data = data ?? new string[] {};
    }

    public string toJson()
    {
        return "{ \"type\": \"" + type.ToString() + "\", \"data\": " + JsonHelper.ToJson(data) + "}";
    }

}
