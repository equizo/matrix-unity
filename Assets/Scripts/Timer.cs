using System;

public class Timer
{
  private readonly float _period;
  private float _time;

  public event Action OnTick = () => { };

  public Timer(float period) =>
    _period = period;

  public void Update(float deltaTime)
  {
    _time += deltaTime;
    if (_time < _period) {
      return;
    }

    _time = 0f;
    OnTick.Invoke();
  }
}