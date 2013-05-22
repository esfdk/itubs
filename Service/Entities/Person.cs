namespace BookITService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.Protocols;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    using BookITService.Enums;

    [DataContract(IsReference = true)]
    [KnownType(typeof(Booking))]
    [KnownType(typeof(Role))]
    public sealed class Person
    {
        public Person()
        {
            this.Bookings = new List<Booking>();
            this.Roles = new List<Role>();
        }

        public static IEnumerable<Person> All
        {
            get
            {
                return BookITContext.Db.People.Include("Bookings").Include("Roles").ToList();
            }
        }

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public ICollection<Booking> Bookings { get; set; }
        [DataMember]
        public ICollection<Role> Roles { get; set; }

        #endregion Properties

        #region Static Methods

        /// <summary>Logs the user into the system.</summary>
        /// <param name="username">The username to use in for login.</param>
        /// <param name="password">The password to use in for login.</param>
        /// <returns>The logged in person. Null if wrong username/password.</returns>
        public static Person Login(string username, string password)
        {
            if (username.Equals(Configuration.AdminEmail) && password.Equals(Configuration.AdminPassword))
            {
                var person = All.FirstOrDefault(p => p.Email.Equals(Configuration.AdminEmail));
                if (person != null)
                {
                    person.Token = GenerateToken();
                    BookITContext.Db.SaveChanges();
                    return person;
                }

                return null;
            }

            if (username.Equals(Configuration.TestEmail) && password.Equals(Configuration.TestPassword))
            {
                var person = All.FirstOrDefault(p => p.Email.Equals(Configuration.TestEmail));
                if (person != null)
                {
                    person.Token = GenerateToken();
                    BookITContext.Db.SaveChanges();

                    return person;
                }

                return null;
            }

            var ldap = new LdapConnection(Configuration.LDAPServer) { Credential = new NetworkCredential(username.Substring(0, username.IndexOf("@")), password) };
            try
            {
                ldap.Bind();
            }
            catch (COMException)
            {
                return new Person { ID = -1 };
            }
            catch (Exception e)
            {
                return e.Message.Contains("available") ? new Person { ID = -1 } : null;
            }

            var dsFilter = "(mail=" + username + ")";
            var de = new DirectoryEntry("LDAP://" + Configuration.LDAPServer, username.Substring(0, username.IndexOf("@")), password);
            var ds = new DirectorySearcher(de)
                        {
                            Filter = dsFilter
                        };

            SearchResult result = null;
            try
            {
                result = ds.FindOne();
            }
            catch (COMException)
            {
                return new Person { ID = -1 };
            }

            if (result == null)
            {
                return null;
            }

            if (!result.Properties.Contains("ituAffiliation") || !result.Properties.Contains("mail"))
            {
                return new Person { Email = string.Empty, Name = string.Empty, Token = string.Empty };
            }

            if (All.Any(p => p.Email.Equals(result.Properties["mail"][0].ToString())))
            {
                var person = All.First(p => p.Email.Equals(result.Properties["mail"][0].ToString()));
                person.Token = GenerateToken();
                BookITContext.Db.SaveChanges();
                return person;
            }
            else
            {
                var person = new Person
                    {
                        Email = result.Properties["mail"][0].ToString(),
                        Name = result.Properties["displayName"][0].ToString()
                    };
                person.Roles.Add(new Role { RoleName = result.Properties["ituAffiliation"][0].ToString() });
                person.Token = GenerateToken();
                BookITContext.Db.People.Add(person);
                BookITContext.Db.SaveChanges();
                return All.FirstOrDefault(p => p.Email.Equals(person.Email));
            }
        }

        /// <summary>
        /// Resets a token so that it is no longer valid.
        /// </summary>
        /// <param name="token">
        /// The token to reset.
        /// </param>
        /// <returns>
        /// The <see cref="RequestStatus"/>.
        /// </returns>
        public static RequestStatus Logout(string token)
        {
            var person = All.First(p => p.Token == token);
            if (person == null)
            {
                return RequestStatus.InvalidInput;
            }

            person.Token = string.Empty;
            BookITContext.Db.SaveChanges();
            return RequestStatus.Success;
        }

        public static Person GetByEMail(string email)
        {
            return All.FirstOrDefault(p => p.Email.Equals(email));
        }

        public static Person GetByToken(string token)
        {
            return All.FirstOrDefault(p => p.Token.Equals(token));
        }

        public bool IsAdmin()
        {
            return this.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole));
        }

        /// <summary>
        /// Generate a login token.
        /// </summary>
        /// <returns>Login token.</returns>
        private static string GenerateToken()
        {
            string token;

            do
            {
                long i = 1;

                foreach (byte b in Guid.NewGuid().ToByteArray())
                {
                    i *= b + 1;
                }

                token = string.Format("{0:x}", i - DateTime.Now.Ticks);
            }
            while (All.Any(p => p.Token == token));

            return token;
        }

        #endregion
    }
}
