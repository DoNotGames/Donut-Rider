public class Spikes : Trap
{
    public override void React(Donut donut)
    {
        donut.TakeDamage();
    }
}
