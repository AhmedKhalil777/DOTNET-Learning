# Interval Operator

> create an Observable that emits a sequence of integers spaced by a given time interval.

![interval Operator](20220625123813.png)

- The Interval operator returns an Observable that emits an infinite sequence of ascending integers, with a constant interval of time of your choosing between emissions.

```{c#}
m_alarmsTimeIntervalSubscription = Observable.Interval(m_bufferTimeSpan).Subscribe(p =>
{
    if (m_alarmsLines.Count > 0)
    {
        WriteInfluxDbLines(m_alarmsLines);
        m_alarmsLines.Clear();
        m_alarmsTimeIntervalSubscription?.Dispose();
        m_alarmsTimeIntervalSubscription = null;
    }
});
```