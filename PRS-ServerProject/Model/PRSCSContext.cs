﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRS_ServerProject.Model;

namespace PRS_ServerProject.Model {
    public class PRSCSContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestLine> RequestLines { get; set; }

        
        public PRSCSContext(DbContextOptions<PRSCSContext> context): base(context) {
            
        }

        public PRSCSContext() {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<User>(entity => {

                entity.HasIndex(u => u.Username)
                .HasName("IDX_Username")
                    .IsUnique();
            });
        }



    }
}
