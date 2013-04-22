namespace ITubsService.Entities
{
    using System.Collections.Generic;

    public partial class Role
    {
        public Role()
        {
            this.People = new List<Person>();
        }

        public int ID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
