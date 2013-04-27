namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Role
    {
        public Role()
        {
            People = new List<Person>();
        }

        public static IEnumerable<Role> All
        {
            get
            {
                return ItubsContext.Db.Roles.Include("People").ToList();
            }
        }

        public int ID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
