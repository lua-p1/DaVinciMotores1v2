using System.Collections;
public interface IBoostedSpeed
{
    public abstract IEnumerator ChangeSpeed(float buff, float notBuff, float time);
    public abstract void StartSpeedBuff(float buff, float notBuff, float time);
}
