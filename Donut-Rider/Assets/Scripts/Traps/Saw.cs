public class Saw : Trap
{
    public override void React(Donut donut)
    {
        donut.TakeDamage();
    }
}
