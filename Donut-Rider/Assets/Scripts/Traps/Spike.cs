public class Spike : Trap
{
    public override void React(Donut donut)
    {
        donut.TakeDamage();
    }
}
