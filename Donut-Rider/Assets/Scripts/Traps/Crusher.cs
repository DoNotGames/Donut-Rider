public class Crusher : Trap
{
    public override void React(Donut donut)
    {
        donut.TakeDamage();
    }
}
