namespace PGSWebsite.Configuration.TestDataSection
{
    using System.Configuration;

    /// <summary>
    /// This class keeps all possible properties for test data entries in config file. If you need any additional property just add it here in the same manner as others
    /// </summary>
    public class TestData : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public virtual string Id
        {
            get
            {
                return (string)this["id"];
            }
        }

        [ConfigurationProperty("username", IsRequired = false, IsKey = false)]
        public virtual string Username
        {
            get
            {
                return (string)this["username"];
            }
        }

        [ConfigurationProperty("password", IsRequired = false, IsKey = false)]
        public virtual string Password
        {
            get
            {
                return (string)this["password"];
            }
        }

        [ConfigurationProperty("firstName", IsRequired = false, IsKey = false)]
        public virtual string FirstName
        {
            get
            {
                return (string)this["firstName"];
            }
        }

        [ConfigurationProperty("surname", IsRequired = false, IsKey = false)]
        public virtual string Surname
        {
            get
            {
                return (string)this["surname"];
            }
        }

        [ConfigurationProperty("datOfBirth", IsRequired = false, IsKey = false)]
        public virtual string DateOfBirth
        {
            get
            {
                return (string)this["datOfBirth"];
            }
        }

        [ConfigurationProperty("name", IsRequired = false, IsKey = false)]
        public virtual string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        [ConfigurationProperty("phone", IsRequired = false, IsKey = false)]
        public virtual string PhoneNumber
        {
            get
            {
                return (string)this["phone"];
            }
        }

        [ConfigurationProperty("message", IsRequired = false, IsKey = false)]
        public virtual string Message
        {
            get
            {
                return (string)this["message"];
            }
        }

        [ConfigurationProperty("email", IsRequired = false, IsKey = false)]
        public virtual string Email
        {
            get
            {
                return (string)this["email"];
            }
        }
    }
}
