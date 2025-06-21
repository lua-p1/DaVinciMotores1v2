using System.Collections;
public interface IBoostedJump
{
    public abstract IEnumerator ChangeJump(float buff, float notBuff, float time);
    public abstract void StartJumpBuff(float buff, float notBuff, float time);
}
