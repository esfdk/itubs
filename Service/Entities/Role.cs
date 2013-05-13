namespace BookITService.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;


    [DataContract(IsReference = true)]
    [KnownType(typeof(Person))]
    public class Role
    {
        public Role()
        {
            this.People = new List<Person>();
        }

        public static IEnumerable<Role> All
        {
            get
            {
                return BookITContext.Db.Roles.Include("People").ToList();
            }
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public virtual ICollection<Person> People { get; set; }
    }
}
