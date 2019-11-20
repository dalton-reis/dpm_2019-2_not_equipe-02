using System;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class EventLogger
{

    private static EventLogger eventLogger;
    
    private FirebaseDatabase database;
    private DatabaseReference eventData;

    private EventLogger(string executionId, FirebaseDatabase database) {
        this.database = database;
        eventData = this.database.RootReference.Child("events").Child(executionId);
    }

    public void Log(string value)
    {
        var messagesReference = eventData.Child("messages");
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
                    logOnDatabase(messagesReference, messages, value);
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
            var executionId = Guid.NewGuid().ToString().Substring(0, 6);
            eventLogger = new EventLogger(executionId, FirebaseDatabase.DefaultInstance);
        }
        return eventLogger;
    }

}
