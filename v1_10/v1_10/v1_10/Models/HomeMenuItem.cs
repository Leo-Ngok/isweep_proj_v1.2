namespace v1_10.Models
{
    public enum MenuItemType
    {
        Browse,
        Home,
        Record,
        Weather,
        Interval_Timer,
        Configurations,
        Profile,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        
        public string Title { get; set; }
    }
}
