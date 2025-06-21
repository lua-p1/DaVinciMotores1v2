using System.Collections;
public interface IBoostedMass
{
    public abstract IEnumerator ChangeMass(float buff, float notBuff, float time);
    public abstract void StartMassBuff(float buff, float notBuff, float time);
}
