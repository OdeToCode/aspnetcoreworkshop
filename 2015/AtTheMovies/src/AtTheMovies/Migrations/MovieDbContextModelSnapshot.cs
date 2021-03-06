﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AtTheMovies.Data;

namespace AtTheMovies.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtTheMovies.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Length");

                    b.Property<DateTime>("ReleaseOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
        }
    }
}
