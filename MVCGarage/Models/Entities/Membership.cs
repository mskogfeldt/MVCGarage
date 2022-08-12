namespace MVCGarage.Models.Entities
{
    public class Membership
    {
        public Membership(DateTime expireDate)
        {
            if (expireDate.Date >= DateTime.Now.Date)
                Type = MembershipType.Pro;
            else
                Type = MembershipType.Basic;
        }
        public MembershipType Type { get; set; }

        public enum MembershipType
        {
            Basic,
            Pro
        }
    }
}
