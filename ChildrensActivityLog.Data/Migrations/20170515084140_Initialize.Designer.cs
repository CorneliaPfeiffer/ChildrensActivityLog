using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChildrensActivityLog.Data;
using ChildrensActivityLog.Domain;

namespace ChildrensActivityLog.Data.Migrations
{
    [DbContext(typeof(ChildrensActivityLogContext))]
    [Migration("20170515084140_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChildrensActivityLog.Domain.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("ChildrensActivityLog.Domain.ChildrensPlayEvents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildId");

                    b.Property<int>("PlayEventId");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("PlayEventId");

                    b.ToTable("ChildrensPlayEvents");
                });

            modelBuilder.Entity("ChildrensActivityLog.Domain.PlayEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("PlayEvents");
                });

            modelBuilder.Entity("ChildrensActivityLog.Domain.Sleep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildId");

                    b.Property<DateTime>("From");

                    b.Property<DateTime>("To");

                    b.Property<int>("TypeOfSleep");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("Sleeps");
                });

            modelBuilder.Entity("ChildrensActivityLog.Domain.ChildrensPlayEvents", b =>
                {
                    b.HasOne("ChildrensActivityLog.Domain.Child", "Child")
                        .WithMany("ChildrensPlayEvents")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChildrensActivityLog.Domain.PlayEvent", "PlayEvent")
                        .WithMany("ChildrensPlayEvents")
                        .HasForeignKey("PlayEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChildrensActivityLog.Domain.Sleep", b =>
                {
                    b.HasOne("ChildrensActivityLog.Domain.Child", "Child")
                        .WithMany("Sleeps")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
