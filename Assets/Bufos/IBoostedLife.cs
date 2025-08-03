using System.Collections;
public interface IBoostedLife
{
    public abstract IEnumerator ChangeLife(bool buff, bool notBuff, float time);
    public abstract void StartLifeBuff(bool buff, bool notBuff, float time);
}
