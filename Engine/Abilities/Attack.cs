using System;
using Engine.Systems;
using Engine.Objects;
using Engine;

public class Attack : Ability
{
    public override int Cooldown
    {
        get
        {
            return 1000;
        }
    }

    public Attack()
        : base(SpellType.PointTarget)
    {
        this.Name = "Attack";
        this.Description = "Attacks in the given direction. ";
    }


    public override void OnCast(Vector pos)
    {
        const float dist = 1f;
        const int angle = 25;
        Console.WriteLine("FUCKING ATAK WE! :D");
        
        //var units = Map.GetUnitsInACone(Hero.X, Hero.Y, x, y, dist, angle);

        //var target = units
        //    .RankBy(t => t.DistanceTo(Hero))
        //    .First();

        //Hero.DamageTarget(target);
    }
}