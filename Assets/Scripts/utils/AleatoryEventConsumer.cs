using System.Timers;
using UnityEngine;

public class AleatoryEventConsumer
{

    private float consumeFactor;
    private float value = 0;
    private Timer timer = new Timer();
    private int valueRange;

    public AleatoryEventConsumer(int valueRange) : this(valueRange, 20000) {}

    public AleatoryEventConsumer(int valueRange, float interval) : this(valueRange, interval, 5) { }

    public AleatoryEventConsumer(int valueRange, float interval, float consumeFactor)
    {
        this.valueRange = valueRange;
        this.consumeFactor = consumeFactor;
        timer.Interval = interval;
        timer.Elapsed += SortValue;
        timer.Enabled = true;
    }

    private void SortValue(object source, ElapsedEventArgs e)
    {
        System.Random rdn = new System.Random();
        var randValue = rdn.Next(-valueRange, valueRange);
        // Debug.Log("Random value sorted: " + randValue);
        value += randValue;
    }

    public void Kill()
    {
        timer.Enabled = false;
    }

    public float ConsumeValue()
    {
        if (value == 0)
        {
            return 0;
        }
        bool decrease = value > 0;
        float consumeFactor = (decrease ? -this.consumeFactor : this.consumeFactor) * Time.deltaTime;

        float newValue = value + consumeFactor;
        if (decrease)
        {
            newValue = newValue < 0 ? 0 : newValue;
        } else
        {
            newValue = newValue > 0 ? 0 : newValue;
        }
        float consumeValue = value - newValue;
        value = newValue;
        return consumeValue;
    }

}