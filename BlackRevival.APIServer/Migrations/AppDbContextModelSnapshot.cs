﻿// <auto-generated />
using System;
using BlackRevival.APIServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BlackRevival.APIServer.Database.Character", b =>
                {
                    b.Property<long>("CharacterNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("ActiveCharacterSkinType")
                        .HasColumnType("int");

                    b.Property<bool>("ActiveLive2D")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CharacterClass")
                        .HasColumnType("int");

                    b.Property<int>("CharacterGrade")
                        .HasColumnType("int");

                    b.Property<int>("CharacterPurchaseType")
                        .HasColumnType("int");

                    b.Property<int>("CharacterStatus")
                        .HasColumnType("int");

                    b.Property<int>("EnhanceExp")
                        .HasColumnType("int");

                    b.Property<bool>("Host")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NormalPlayCount")
                        .HasColumnType("int");

                    b.Property<int>("NormalWinCount")
                        .HasColumnType("int");

                    b.Property<int>("Pfr")
                        .HasColumnType("int");

                    b.Property<int>("Pmn")
                        .HasColumnType("int");

                    b.Property<int>("PotentialSkillId")
                        .HasColumnType("int");

                    b.Property<int>("Psd")
                        .HasColumnType("int");

                    b.Property<int>("RankPlayCount")
                        .HasColumnType("int");

                    b.Property<int>("RankWinCount")
                        .HasColumnType("int");

                    b.Property<int>("TeamNumber")
                        .HasColumnType("int");

                    b.Property<int>("ToNormalRemainSeconds")
                        .HasColumnType("int");

                    b.Property<string>("UserNickname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("UserNum")
                        .HasColumnType("bigint");

                    b.HasKey("CharacterNum");

                    b.HasIndex("UserNum");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.InventoryGoods", b =>
                {
                    b.Property<long>("Num")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "n");

                    b.Property<bool>("Activated")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "a");

                    b.Property<DateTime>("ExpireDtm")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "ed");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("Relational:JsonPropertyName", "ia");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "c");

                    b.Property<long>("UserNum")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "un");

                    b.HasKey("Num");

                    b.HasIndex("UserNum");

                    b.ToTable("InventoryGoods");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.LabGoodsEntry", b =>
                {
                    b.Property<long>("labNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "lnm");

                    b.Property<string>("bgSubType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "sbt");

                    b.Property<string>("components")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "cps");

                    b.Property<bool>("isActivated")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("Relational:JsonPropertyName", "acti");

                    b.Property<int>("labType")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "ltp");

                    b.Property<long>("userNum")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "unm");

                    b.HasKey("labNum");

                    b.ToTable("LabGoodsEntries");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.MailEntry", b =>
                {
                    b.Property<long>("mailNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "mnm");

                    b.Property<long>("UserNum")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "reciever");

                    b.Property<long>("attachmentmailAttachmentNum")
                        .HasColumnType("bigint");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "ctt");

                    b.Property<DateTime>("createDtm")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "cdt");

                    b.Property<int>("eventNum")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "enm");

                    b.Property<DateTime>("expireDtm")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "epd");

                    b.Property<string>("publishId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "lnk");

                    b.Property<DateTime>("readDtm")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "rdt");

                    b.Property<string>("senderNickname")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "snk");

                    b.Property<int>("senderNum")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "snm");

                    b.Property<int>("status")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "sts");

                    b.Property<string>("subTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "sbt");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "tit");

                    b.Property<int>("type")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "typ");

                    b.Property<string>("webLink")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "wlnk");

                    b.HasKey("mailNum");

                    b.HasIndex("UserNum");

                    b.HasIndex("attachmentmailAttachmentNum");

                    b.ToTable("MailEntries");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.MailEntryAttachment", b =>
                {
                    b.Property<long>("mailAttachmentNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "man");

                    b.Property<long>("mailNum")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "mnm");

                    b.HasKey("mailAttachmentNum");

                    b.ToTable("MailEntryAttachments");

                    b.HasAnnotation("Relational:JsonPropertyName", "attachement");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.OwnedSkin", b =>
                {
                    b.Property<long>("OwnedSkinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("ActiveLive2D")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("Relational:JsonPropertyName", "live");

                    b.Property<int>("CharacterClass")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "cls");

                    b.Property<int>("CharacterSkinType")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "ckt");

                    b.Property<bool>("Owned")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("Relational:JsonPropertyName", "own");

                    b.Property<int>("SkinEnableType")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "setp");

                    b.Property<long>("UserNum")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "unm");

                    b.HasKey("OwnedSkinId");

                    b.HasIndex("UserNum");

                    b.ToTable("OwnedSkins");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.QuestProgress", b =>
                {
                    b.Property<long>("QuestProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "qpid");

                    b.Property<bool>("Cleared")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("Relational:JsonPropertyName", "c");

                    b.Property<long>("ExpireDtm")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "ed");

                    b.Property<int>("Progress")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "pg");

                    b.Property<int>("QuestId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "qd");

                    b.Property<int>("RenewalType")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "rt");

                    b.Property<bool>("Rewarded")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("Relational:JsonPropertyName", "r");

                    b.Property<long>("UserNum")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "unm");

                    b.HasKey("QuestProgressId");

                    b.HasIndex("UserNum");

                    b.ToTable("QuestProgresses");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.User", b =>
                {
                    b.Property<long>("UserNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("ActivatedPotentialSkillId")
                        .HasColumnType("int");

                    b.Property<long>("ActiveCharacterNum")
                        .HasColumnType("bigint");

                    b.Property<int>("AdViewCount")
                        .HasColumnType("int");

                    b.Property<string>("AppLanguageCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Aps")
                        .HasColumnType("int");

                    b.Property<bool>("Bgm")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreateDtm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FreeBearRouletteDtm")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Lastword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("League")
                        .HasColumnType("int");

                    b.Property<int>("LeaguePoint")
                        .HasColumnType("int");

                    b.Property<bool>("Lte")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Ltf")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Lto")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Ltr")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Ltt")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Ltv")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MatchingCardCode")
                        .HasColumnType("int");

                    b.Property<int>("MaxAdViewCount")
                        .HasColumnType("int");

                    b.Property<bool>("NewPostArrived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ReceivePushMsg")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ResearcherExp")
                        .HasColumnType("int");

                    b.Property<int>("ResearcherTitleCode")
                        .HasColumnType("int");

                    b.Property<string>("Rtn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Sigc")
                        .HasColumnType("int");

                    b.Property<int>("Sigg")
                        .HasColumnType("int");

                    b.Property<bool>("SoundEffect")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TermsAgree")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TutorialProgress")
                        .HasColumnType("int");

                    b.Property<string>("Watchword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("countryCode")
                        .HasColumnType("longtext");

                    b.HasKey("UserNum");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.UserAsset", b =>
                {
                    b.Property<long>("UserNum")
                        .HasColumnType("bigint");

                    b.Property<int>("AgliaScore")
                        .HasColumnType("int");

                    b.Property<int>("BearPoint")
                        .HasColumnType("int");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<int>("ExperimentMemory")
                        .HasColumnType("int");

                    b.Property<int>("Gem")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("LabyrinthPoint")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<int>("TournamentPoint")
                        .HasColumnType("int");

                    b.Property<int>("TournamentTicket")
                        .HasColumnType("int");

                    b.Property<int>("VoteStamp")
                        .HasColumnType("int");

                    b.Property<int>("VoteTicket")
                        .HasColumnType("int");

                    b.HasKey("UserNum");

                    b.ToTable("UserAssets");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.Character", b =>
                {
                    b.HasOne("BlackRevival.APIServer.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNum");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.InventoryGoods", b =>
                {
                    b.HasOne("BlackRevival.APIServer.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.MailEntry", b =>
                {
                    b.HasOne("BlackRevival.APIServer.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackRevival.APIServer.Database.MailEntryAttachment", "attachment")
                        .WithMany()
                        .HasForeignKey("attachmentmailAttachmentNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("attachment");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.OwnedSkin", b =>
                {
                    b.HasOne("BlackRevival.APIServer.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.QuestProgress", b =>
                {
                    b.HasOne("BlackRevival.APIServer.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.UserAsset", b =>
                {
                    b.HasOne("BlackRevival.APIServer.Database.User", "User")
                        .WithOne("UserAsset")
                        .HasForeignKey("BlackRevival.APIServer.Database.UserAsset", "UserNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackRevival.APIServer.Database.User", b =>
                {
                    b.Navigation("UserAsset")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
