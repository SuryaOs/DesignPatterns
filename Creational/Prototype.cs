namespace Creational;
// cloning exsiting object instead of creating new on from scratch
public abstract class Enemy
{
    private int health;
    private int speed;
    private string weapon;
    public Enemy(int health, int speed, string weapon)
    {
        this.health = health;
        this.speed = speed;
        this.weapon = weapon;
    }
    public abstract Enemy Clone();
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public override string ToString()
    {
        return $"{typeof(Enemy)} spawned with XP{this.health} Speed{this.speed} Weapon{this.weapon}";
    }
}
public class FlyingEnemy : Enemy
{

    public FlyingEnemy(int health, int speed, string weapon) : base(health, speed, weapon)
    {

    }
    public override Enemy Clone()
    {
        return (FlyingEnemy)MemberwiseClone();
    }
}
public class ArmoredEnemy : Enemy
{
    public ArmoredEnemy(int health, int speed, string weapon) : base(health, speed, weapon)
    {
    }
    public override Enemy Clone()
    {
        return (ArmoredEnemy)MemberwiseClone();
    }
}
