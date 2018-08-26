using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vote.Entities;

namespace Vote.Data
{
    public class VoteDbContext : IdentityDbContext<User>
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Event> Events { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<PollQuestion> PollQuestions { get; set; }

        public DbSet<PollAnswer> PollAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Event>().HasKey(e => e.Id);
            mb.Entity<Event>().HasIndex(e => e.Code);
            mb.Entity<Event>().HasOne(e => e.Creator)
                              .WithMany(u => u.CreatedEvents)
                              .HasForeignKey(e => e.CreatorId)
                              .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Question>().HasKey(q => q.Id);
            mb.Entity<Question>().HasOne(q => q.Event)
                                 .WithMany(e => e.Questions)
                                 .HasForeignKey(q => q.EventId)
                                 .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Reply>().HasKey(r => r.Id);
            mb.Entity<Reply>().HasOne(r => r.Question)
                              .WithMany(q => q.Replies)
                              .HasForeignKey(r => r.QuestionId)
                              .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Poll>().HasKey(p => p.Id);
            mb.Entity<Poll>().HasOne(p => p.Event)
                             .WithMany(e => e.Polls)
                             .HasForeignKey(p => p.EventId)
                             .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<PollQuestion>().HasKey(pq => pq.Id);
            mb.Entity<PollQuestion>().HasOne(pq => pq.Poll)
                                     .WithOne(p => p.PollQuestion)
                                     .HasForeignKey<Poll>(p => p.PollQuestionId)
                                     .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<PollAnswer>().HasKey(pa => pa.Id);
            mb.Entity<PollAnswer>().HasOne(pa => pa.Poll)
                                   .WithMany(p => p.PollAnswers)
                                   .HasForeignKey(pa => pa.PollId)
                                   .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(mb);
        }
    }
}
