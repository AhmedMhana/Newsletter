using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
