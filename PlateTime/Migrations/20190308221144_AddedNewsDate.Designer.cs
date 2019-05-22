﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlateTimeApp.Models;

namespace PlateTimeApp.Migrations
{
    [DbContext(typeof(NewsFeedContext))]
    [Migration("20190308221144_AddedNewsDate")]
    partial class AddedNewsDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("PlateTimeApp.Models.NewsFeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("NewsDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("NewsFeeds");

                    b.HasData(
                        new { Id = 1, Description = "News API has been initialized", NewsDate = new DateTime(2018, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Random Title 1" },
                        new { Id = 2, Description = "User Profile page has been initialized", NewsDate = new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Random Title 2" },
                        new { Id = 3, Description = "Random data testing LoremIpsum", NewsDate = new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Random Title 3" },
                        new { Id = 4, Description = "<p>ut dolore laoreet tincidunt ut tincidunt erat magna ipsum aliquam sed aliquam erat ut diam nonummy amet laoreet lorem laoreet consectetuer nonummy. consectetuer consectetuer ut lorem ut ipsum dolor sit dolor euismod tincidunt amet sed sit sit nonummy ipsum euismod adipiscing ipsum amet ipsum. tincidunt sed consectetuer elit erat nonummy sit euismod sed ipsum magna amet nibh diam aliquam ut erat aliquam laoreet magna laoreet laoreet. consectetuer ut consectetuer consectetuer adipiscing ut tincidunt elit diam amet consectetuer sit euismod adipiscing ut adipiscing dolor euismod lorem diam sit nibh. elit amet euismod tincidunt nibh elit tincidunt elit consectetuer elit consectetuer magna sit nonummy dolor tincidunt sit diam erat lorem euismod tincidunt. </p>", NewsDate = new DateTime(2019, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>euismod nonummy aliquam nonummy ut euismod. ut ut nonummy euismod ipsum nibh. </p>" },
                        new { Id = 5, Description = "<p>magna magna amet consectetuer sit magna lorem elit euismod diam aliquam laoreet diam nibh ipsum aliquam euismod ipsum tincidunt euismod amet amet sit erat. euismod adipiscing nibh diam euismod lorem laoreet sed euismod magna aliquam elit nonummy amet dolore dolor adipiscing adipiscing euismod elit amet sed nibh dolor. nonummy laoreet aliquam consectetuer consectetuer dolore dolor euismod tincidunt amet tincidunt magna adipiscing nonummy laoreet euismod ut diam sit nibh tincidunt ut sed elit. consectetuer nibh consectetuer aliquam euismod dolore laoreet sit ut sed aliquam magna ipsum nonummy dolor laoreet laoreet consectetuer tincidunt consectetuer nibh aliquam dolore dolore. </p>", NewsDate = new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>euismod laoreet dolor euismod. ut ipsum lorem ut. </p>" },
                        new { Id = 6, Description = "<p>nibh sed adipiscing laoreet aliquam tincidunt ipsum consectetuer lorem erat consectetuer erat nonummy magna euismod dolore euismod lorem erat magna sit aliquam sit sit sed magna nonummy dolor. adipiscing adipiscing magna ipsum erat sed sed dolore nibh sed sed sed aliquam adipiscing diam erat laoreet erat nonummy ut dolor elit elit adipiscing nibh ipsum nibh tincidunt. consectetuer dolor adipiscing ipsum dolor erat erat ut ipsum amet erat dolor diam dolore consectetuer sit euismod nibh aliquam dolore sed sit sed sed adipiscing laoreet erat erat. aliquam nibh diam aliquam dolore laoreet nonummy sed ipsum elit consectetuer erat elit ut aliquam nibh erat sed consectetuer adipiscing dolor sit tincidunt lorem dolor laoreet amet dolor. ut aliquam ut elit erat erat dolore nonummy ut ipsum consectetuer ut consectetuer dolore ipsum consectetuer consectetuer erat sed ut amet magna sed magna diam tincidunt dolore laoreet. </p>", NewsDate = new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>tincidunt tincidunt ut dolor. consectetuer lorem euismod sit. </p>" },
                        new { Id = 7, Description = "<p>ut euismod amet diam sit ipsum diam erat sed adipiscing sit amet aliquam sed nonummy elit dolor adipiscing erat lorem euismod dolor consectetuer sit nonummy tincidunt. magna diam adipiscing nibh nonummy laoreet elit euismod ut adipiscing amet nonummy diam sit sit ut dolore ut sit euismod magna nibh sit adipiscing diam amet. adipiscing dolore magna nibh elit lorem erat diam sit lorem euismod dolore dolore elit magna consectetuer tincidunt amet sit nibh magna laoreet dolore aliquam adipiscing nonummy. lorem magna dolore adipiscing adipiscing lorem dolor adipiscing sed nonummy laoreet dolor erat sit nibh erat lorem sit ipsum lorem aliquam laoreet laoreet nibh magna erat. dolor magna adipiscing nibh lorem aliquam consectetuer dolore lorem ipsum tincidunt magna ut nibh tincidunt diam aliquam adipiscing diam nonummy amet lorem erat aliquam laoreet tincidunt. </p>", NewsDate = new DateTime(2018, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>erat adipiscing consectetuer laoreet. adipiscing adipiscing laoreet lorem. </p>" },
                        new { Id = 8, Description = "<p>euismod dolor dolore sed sit nibh consectetuer sed ut magna ipsum laoreet lorem sit erat dolor dolor amet dolore dolor dolore aliquam adipiscing sed adipiscing adipiscing tincidunt dolore dolor. aliquam sit dolore magna euismod dolor dolore erat diam ut adipiscing sed lorem consectetuer consectetuer consectetuer sed aliquam amet dolore ut adipiscing nibh sit nibh lorem tincidunt laoreet sed. ipsum magna magna diam adipiscing laoreet ut amet magna elit ipsum dolor sit euismod diam nonummy tincidunt laoreet tincidunt ipsum dolor aliquam sed sed erat elit euismod nibh tincidunt. consectetuer euismod sed lorem nonummy sed magna sed erat ut diam nibh lorem nonummy nonummy dolor tincidunt nibh tincidunt ipsum euismod aliquam amet lorem ut consectetuer sit diam diam. diam aliquam sit dolor nonummy euismod ut euismod dolor euismod amet euismod dolor ut lorem sit nonummy ipsum elit magna adipiscing adipiscing laoreet aliquam diam ipsum elit sed sed. </p>", NewsDate = new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>erat nibh nibh diam. euismod euismod elit elit. </p>" },
                        new { Id = 9, Description = "<p>ipsum nonummy adipiscing ipsum ut lorem nibh nibh erat laoreet dolore tincidunt ipsum ipsum nonummy diam euismod lorem elit dolor elit tincidunt ipsum amet laoreet lorem dolor nonummy. dolor tincidunt laoreet consectetuer elit erat magna dolore ut ut sed nonummy amet amet ut erat nonummy erat nibh sed sit ut nibh sed euismod elit sed sed. diam ipsum consectetuer tincidunt magna lorem sed consectetuer lorem nonummy consectetuer ipsum amet ut ut magna euismod dolore magna sit erat ipsum tincidunt laoreet diam ut elit elit. dolor adipiscing euismod erat nibh diam adipiscing euismod diam ut tincidunt amet laoreet sed erat erat ut diam amet sed erat ut dolore dolore nonummy consectetuer diam elit. </p>", NewsDate = new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>laoreet sit dolor nonummy magna magna sed. dolor magna amet euismod diam dolore elit. </p>" },
                        new { Id = 10, Description = "<p>ut nibh dolore amet consectetuer lorem adipiscing lorem lorem amet dolor consectetuer ipsum nibh elit erat sed ipsum erat aliquam nonummy tincidunt laoreet aliquam ut nibh magna nibh ipsum. nibh amet diam amet amet nibh nibh nonummy laoreet magna dolore aliquam laoreet magna amet laoreet amet dolor sed lorem dolore euismod tincidunt euismod nonummy adipiscing lorem laoreet aliquam. nonummy ut sit laoreet aliquam sed erat euismod lorem magna erat laoreet sed tincidunt sit dolor erat laoreet laoreet nibh dolor diam sed sed nonummy amet erat nonummy magna. ut aliquam nonummy dolore euismod amet sit tincidunt sit dolore sed amet sit amet consectetuer diam amet sed aliquam nonummy nonummy nibh nibh consectetuer sit laoreet lorem consectetuer ut. </p>", NewsDate = new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "<p>erat dolor laoreet ut. dolor nonummy consectetuer aliquam. </p>" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}