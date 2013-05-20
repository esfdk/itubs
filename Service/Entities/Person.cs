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

            // Create new LDAP connection with the users credentials
            var ldap = new LdapConnection(Configuration.LDAPServer) { Credential = new NetworkCredential(username.Substring(0, username.IndexOf("@")), password) };
            try
            {
                // Attempt to bind the connection
                ldap.Bind();
            }
            catch (COMException)
            {
                // If communication exception is thrown, return -1
                return new Person { ID = -1 };
            }
            catch (Exception e)
            {
                // If exception specifies that the LDAP server is not available, return -1
                // Any other exception, return null
                return e.Message.Contains("available") ? new Person { ID = -1 } : null;
            }

            // Create directory search filter based on email
            var dsFilter = "(mail=" + username + ")";

            // Use username and password to create new directory entry
            var de = new DirectoryEntry("LDAP://" + Configuration.LDAPServer, username.Substring(0, username.IndexOf("@")), password);

            // Use directory entry and filter to create a searcher for the directory
            var ds = new DirectorySearcher(de)
                        {
                            Filter = dsFilter
                        };

            SearchResult result = null;

            // Try to find an element in the directory with the users email
            try
            {
                result = ds.FindOne();
            }
            catch (COMException)
            {
                // If communication exception, return -1
                return new Person { ID = -1 };
            }


            // Return null if no user is found in the AD (unlikely, but possible)
            if (result == null)
            {
                return null;
            }


            // Return person with empty mail, name and token if user found has no ituAffiliation
            if (!result.Properties.Contains("ituAffiliation") || !result.Properties.Contains("mail"))
            {
                return new Person { Email = string.Empty, Name = string.Empty, Token = string.Empty };
            }


            // If there exists any user in the database with the same email as result,
            // generate token for the person, save changes and return the found person
            if (All.Any(p => p.Email.Equals(result.Properties["mail"][0].ToString())))
            {
                var person = All.First(p => p.Email.Equals(result.Properties["mail"][0].ToString()));
                person.Token = GenerateToken();

                BookITContext.Db.SaveChanges();

                return person;
            }
            else
            {
                // If no such user exists, create new user in database with email and name equal to result
                // then generate token, add the person to the database, save changes and return the new person
                // from the database
                var person = new Person
                    {
                        Email = result.Properties["mail"][0].ToString(),
                        Name = result.Properties["displayName"][0].ToString()
                    };
                person.Roles.Add(new Role() { RoleName = result.Properties["ituAffiliation"][0].ToString() });
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
