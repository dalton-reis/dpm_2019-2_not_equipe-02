using System;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class EventLogger
{

    private static EventLogger eventLogger;
    
    private FirebaseDatabase database;
    private DatabaseReference messagesReference;

    private EventLogger(string executionId, FirebaseDatabase database) {
        this.database = database;
        messagesReference = this.database.RootReference.Child("events").Child(executionId).Child("messages");
        var initMessages = JsonHelper.ToJson(new List<string>().ToArray());
        messagesReference.SetValueAsync(initMessages);
    }

    public void Log(EventModel eventModel)
    {
        messagesReference
            .GetValueAsync()
            .ContinueWith(task =>  {
                if (task.IsFaulted)
                {
                    Debug.Log("Error on Get Messages from Firebase");
                    Debug.Log(task.Exception);
                }
                else if (task.IsCompleted)
                {
                    List<string> messages = new List<string>();
                    if (task.Result.Value != null)
                    {
                        string[] primitiveArray = JsonHelper.FromJson<string>((string) task.Result.Value);
                        messages.AddRange(primitiveArray);
                    }
                    logOnDatabase(messagesReference, messages, eventModel.toJson());
                }
            }).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("Error on send event log.");
                    Debug.Log(task.Exception);
                }
            });
    }

    private void logOnDatabase(DatabaseReference messagesReference, List<string> currentMessages, string value)
    {
        currentMessages.Add(value);
        var databaseValue = JsonHelper.ToJson(currentMessages.ToArray());
        messagesReference.SetValueAsync(databaseValue)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("Error on save on Firebase");
                    Debug.Log(task.Exception);
                }
            });
    }

    public static EventLogger Get()
    {
        if (eventLogger == null)
        {
            Start();
        }
        return eventLogger;
    }

    public static void Start()
    {
        var executionId = Guid.NewGuid().ToString().Substring(0, 3);
        eventLogger = new EventLogger(executionId, FirebaseDatabase.DefaultInstance);
    }

}
