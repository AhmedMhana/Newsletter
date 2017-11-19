using Models;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseLayer.Mapping
{
    public class SubscriberMap : EntityTypeConfiguration<Subscriber>
    {
        public SubscriberMap()
        {
            //Table
            ToTable("Subscribers");

            //Key
            HasKey(c => c.Id);

            //Properites
            //Property(c => c.ReasonForSignup).HasMaxLength(300);

            //Ignore

            //Relationship
        }
    }
}
