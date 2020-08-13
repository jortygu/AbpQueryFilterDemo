namespace AbpQueryFilterDemo
{
    public class CurrentActive : ICurrentActive
    {
        public bool Active { get; set; }

        public CurrentActive()
        {
            Active = true;
        }
    }
}
