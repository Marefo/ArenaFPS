using _CodeBase.ShooterCode.Data;

namespace _CodeBase.ShooterCode
{
  public interface IHealthDamageable
  {
    void ReceiveHealthDamage(int damage, DamageType damageType);
  }
}