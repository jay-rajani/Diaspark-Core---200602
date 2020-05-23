using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diaspark.Models
{
    public partial class MainEntities : DbContext
    {
        public MainEntities()
        {
        }

        public MainEntities(DbContextOptions<MainEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<diintrtransdtl> diintrtransdtls { get; set; }
        public virtual DbSet<diintrtranshd> diintrtranshds { get; set; }
        public virtual DbSet<invntrtransdtl> invntrtransdtls { get; set; }
        public virtual DbSet<invntrtranshd> invntrtranshds { get; set; }
        public virtual DbSet<saoitrinvdtl> saoitrinvdtls { get; set; }
        public virtual DbSet<saoitrinvhd> saoitrinvhds { get; set; }
        public virtual DbSet<sysmmsmodulelink> sysmmsmodulelinks { get; set; }
        public virtual DbSet<faartrpaymentdtl> faartrpaymentdtls { get; set; }
        public virtual DbSet<faartrinvhd> faartrinvhds { get; set; }
        public virtual DbSet<saoimsterms> saoimstermses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=jeweldb2014;Database=jewel_demonew;User ID=jewelerp;Password=Diaspark200");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<diintrtransdtl>(entity =>
            {
                entity.ToTable("diintrtransdtl");
                entity.HasKey(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.serial_no, e.company_id });

                entity.HasIndex(e => new { e.memo_flag, e.packet_no, e.trans_bk })
                    .HasName("IX_diintrtransdtl_3");

                entity.HasIndex(e => new { e.item_type, e.item_category, e.item_id, e.packet_no })
                    .HasName("diintrtransdtl_x2");

                entity.HasIndex(e => new { e.item_type, e.item_id, e.item_category, e.packet_no, e.account_period })
                    .HasName("IX_diintrtransdtl_003");

                entity.HasIndex(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.serial_no, e.company_id })
                    .HasName("diintrtransdtl_x")
                    .IsUnique();

                entity.HasIndex(e => new { e.company_id, e.trans_dt, e.item_type, e.item_category, e.item_id, e.packet_no })
                    .HasName("diintrtransdtl_index03");

                entity.HasIndex(e => new { e.item_id, e.post_flag, e.packet_no, e.company_id, e.item_type, e.item_category, e.account_period })
                    .HasName("IX_diintrtransdtl_005");

                entity.HasIndex(e => new { e.item_type, e.item_id, e.rec_wt, e.iss_wt, e.item_category, e.packet_no, e.memo_flag, e.trans_bk })
                    .HasName("IX_diintrtransdtl_2");

                entity.HasIndex(e => new { e.item_id, e.rec_pcs, e.rec_wt, e.iss_pcs, e.iss_wt, e.item_category, e.packet_no, e.memo_flag, e.item_type, e.account_period })
                    .HasName("IX_diintrtransdtl_002");

                entity.HasIndex(e => new { e.item_type, e.item_id, e.rec_pcs, e.iss_pcs, e.rec_amt, e.iss_amt, e.company_id, e.item_category, e.packet_no, e.memo_flag, e.account_period })
                    .HasName("IX_diintrtransdtl_004");

                entity.HasIndex(e => new { e.trans_dt, e.item_type, e.item_id, e.rec_pcs, e.rec_wt, e.iss_pcs, e.iss_wt, e.company_id, e.item_category, e.packet_no, e.memo_flag })
                    .HasName("IX_diintrtransdtl_001");

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.serial_no)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.account_period)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.action_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.apply_pcs)
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.apply_wt)
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.approval_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.approved_by)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.approved_dt).HasColumnType("datetime");

                entity.Property(e => e.avg_cost).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.barcode_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.barcode_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.cert_no)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.clear_pcs)
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.clear_wt)
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.color)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.descrip)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.diamond_qlty)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.envelope_no)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.gia_grading)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.iss_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.iss_pcs).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.iss_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.iss_unit)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.iss_wt).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.item_category)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_cost).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.item_id)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_dt).HasColumnType("datetime");

                entity.Property(e => e.memo_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_sno)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.metal_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.packet_no)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.post_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.price).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.prod_so_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.rap_discount).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.rap_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.rec_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.rec_pcs).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.rec_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.rec_unit)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.rec_wt).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.ref_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_serial_no)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.remark)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ri_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.size).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.stone_qlty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stone_shape)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stone_size)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stone_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.style_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_dt).HasColumnType("datetime");

                entity.Property(e => e.wb_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_serial_no)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<diintrtranshd>(entity =>
            {
                entity.ToTable("diintrtranshd");
                entity.HasKey(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.company_id });

                entity.HasIndex(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.company_id })
                    .HasName("diintrtranshd_x")
                    .IsUnique();

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.account_period)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.action_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.post_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.qty_filled).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.rec_location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_no)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.remarks)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ri_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.store_id)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.style_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.transfer_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_dt).HasColumnType("datetime");

                entity.Property(e => e.wb_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<invntrtransdtl>(entity =>
            {
                entity.ToTable("invntrtransdtl");
                entity.HasKey(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.serial_no, e.company_id });

                entity.HasIndex(e => new { e.item_type, e.prod_so_type })
                    .HasName("IX_invntrtransdtl_for_stock_rep");

                entity.HasIndex(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.serial_no, e.company_id })
                    .HasName("invntrtransdtl_x")
                    .IsUnique();

                entity.HasIndex(e => new { e.trans_no, e.trans_dt, e.serial_no, e.company_id, e.account_period, e.trans_bk })
                    .HasName("IX_invntrtransdtl_style_posting2");

                entity.HasIndex(e => new { e.item_type, e.item_id, e.company_id, e.item_category, e.account_period, e.prod_so_type, e.trans_bk })
                    .HasName("IX_invntrtransdtl_style_posting1");

                entity.HasIndex(e => new { e.item_id, e.rec_pcs, e.rec_wt, e.iss_pcs, e.iss_wt, e.item_category, e.item_cost, e.item_type, e.trans_dt })
                    .HasName("IX_stock_summary");

                entity.HasIndex(e => new { e.item_id, e.rec_pcs, e.rec_wt, e.iss_pcs, e.iss_wt, e.item_category, e.prod_so_type, e.item_cost, e.memo_flag, e.trans_bk, e.trans_dt, e.item_type })
                    .HasName("IX_stock_summary1");

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.serial_no)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.account_period)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.action_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.barcode_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.barcode_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.clear_qty).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.color)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.diamond_qlty)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.iss_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.iss_pcs).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.iss_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.iss_unit)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.iss_wt).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.item_category)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_cost).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.item_id)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.metal_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.old_item_category)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.old_item_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.open_pcs).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.packet_no)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.post_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.prod_so_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.rec_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.rec_pcs).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.rec_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.rec_unit)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.rec_wt).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.ref_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_serial_no)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ri_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.size).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.stage_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stock_pcs).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.stone_qlty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stone_shape)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stone_size)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.stone_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.style_bagno)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.style_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_dt).HasColumnType("datetime");

                entity.Property(e => e.wb_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_serial_no)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<invntrtranshd>(entity =>
            {
                entity.ToTable("invntrtranshd");
                entity.HasKey(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.company_id });

                entity.HasIndex(e => new { e.trans_bk, e.trans_no, e.trans_dt, e.company_id })
                    .HasName("invntrtranshd_x")
                    .IsUnique();

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.account_period)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.action_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.memo_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.packet_no)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.post_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.qty_filled).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.rec_location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_no)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.remarks)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ri_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.style_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wb_dt).HasColumnType("datetime");

                entity.Property(e => e.wb_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wip_posted_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<saoitrinvdtl>(entity =>
            {
                entity.ToTable("saoitrinvdtl");
                
                entity.HasKey(e => new { e.company_id, e.trans_bk, e.trans_no, e.trans_dt, e.serial_no });

                entity.HasIndex(e => e.item_id)
                    .HasName("IX_saoitrinvdtl_2");

                entity.HasIndex(e => new { e.item_category, e.item_id })
                    .HasName("IX_saoitrinvdtl_3");

                entity.HasIndex(e => new { e.trans_bk, e.trans_flag })
                    .HasName("IX_saoitrinvdtl_4");

                entity.HasIndex(e => new { e.ref_type, e.ref_no, e.ref_serial_no, e.trans_bk })
                    .HasName("IX_saoitrinvdtl_1");

                entity.HasIndex(e => new { e.trans_no, e.trans_dt, e.serial_no, e.item_cost, e.trans_bk })
                    .HasName("IX_saoitrinvdtl_001");

                entity.HasIndex(e => new { e.company_id, e.trans_no, e.trans_dt, e.serial_no, e.ref_no, e.ref_dt, e.ref_serial_no, e.item_cost, e.trans_bk, e.ref_type })
                    .HasName("IX_saoitrinvdtl_002");

                entity.HasIndex(e => new { e.trans_bk, e.serial_no, e.size, e.net_amt, e.packet_no, e.clear_qty, e.location, e.prod_so_type, e.company_id, e.trans_no, e.trans_dt, e.item_id, e.trans_qty, e.item_flag, e.item_category })
                    .HasName("IX_for_SO_tracking");

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.serial_no)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Item_master_discount_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.approval_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.barcode_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.child_category)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.child_catgory)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.child_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.clear_qty).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.clear_qty_inv).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.clear_qty_ret).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.color)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.colorstone_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.comments)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.cstone_qlty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.cstone_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.diamond_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.diamond_qlty)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.diamond_wt).HasColumnType("numeric(7, 3)");

                entity.Property(e => e.discount_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.discount_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.gold_increment).HasColumnType("numeric(9, 7)");

                entity.Property(e => e.gold_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.item_amt).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.item_barcode)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_category)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_cost).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.item_description)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_master_cost).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.item_master_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.item_price).HasColumnType("numeric(16, 4)");

                entity.Property(e => e.item_tot_cost).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.labor_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.long_remark)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.mape_trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.mape_trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.mape_trans_serial_no)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.metal_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.net_amt).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.old_item_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.other_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.packet_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.planship_dt).HasColumnType("datetime");

                entity.Property(e => e.po_dt).HasColumnType("datetime");

                entity.Property(e => e.po_no)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.price_flag)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.price_level)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.prod_so_type)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.prod_stage_id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_item_id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_no)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_price).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.ref_qty).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ref_serial_no)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.remarks)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.return_qty).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.salescomm_amt).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.salescomm_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.sell_unit)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.size).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.sku_no)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.tax_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.temp_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.template_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_qty).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.trans_qty2).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.trans_qty_pc).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.trans_qty_wt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.upc_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wt).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.wt_unit)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wtd_cost).HasColumnType("numeric(12, 2)");
            });

            modelBuilder.Entity<saoitrinvhd>(entity =>
            {
                entity.ToTable("saoitrinvhd");
                entity.HasKey(e => new { e.company_id, e.trans_bk, e.trans_no, e.trans_dt });

                entity.HasIndex(e => new { e.account_id, e.trans_period })
                    .HasName("IX_saoitrinvhd_1");

                entity.HasIndex(e => new { e.trans_period, e.trans_type })
                    .HasName("IX_saoitrinvhd_2");

                entity.HasIndex(e => new { e.trans_period, e.company_id, e.trans_no, e.trans_dt, e.trans_type })
                    .HasName("IX_saoitrinvhd_style_posting");

                entity.HasIndex(e => new { e.trans_bk, e.ship_id, e.ref_dt, e.po_no, e.po_dt, e.ship_dt, e.company_id, e.trans_type, e.trans_flag, e.trans_no, e.trans_dt, e.account_id, e.trans_period, e.sales_person, e.trans_for_flag })
                    .HasName("IX_for_SO_tracking");

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.ac_amount1).HasColumnType("numeric(16, 2)");

                entity.Property(e => e.ac_amount2).HasColumnType("numeric(16, 2)");

                entity.Property(e => e.ac_amount3).HasColumnType("numeric(16, 2)");

                entity.Property(e => e.ac_amount4).HasColumnType("numeric(16, 2)");

                entity.Property(e => e.ac_percent1).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.ac_percent2).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.ac_percent3).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.ac_percent4).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.account_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.action_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.adv_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.adv_check_dt).HasColumnType("datetime");

                entity.Property(e => e.adv_check_no)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.adv_type)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.authorisation_no)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.balance_due_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.bank_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.credit_exceeded_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.credit_limit_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.cust_type1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.cust_type2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.dc_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.dc_trfr_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.discount_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.discount_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.discount_terms)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.doc_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.doc_type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.due_dt).HasColumnType("datetime");

                entity.Property(e => e.gold_price).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.gold_price_dt).HasColumnType("datetime");

                entity.Property(e => e.insurance_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.insurance_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.insurance_terms)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.inv_print_no)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_amt).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.location)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.master_po_no)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.message_id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.net_amt).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.old_id)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.order_dttime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.other_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.palladium_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.pl_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.pl_dt).HasColumnType("datetime");

                entity.Property(e => e.pl_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.platinum_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.po_dt).HasColumnType("datetime");

                entity.Property(e => e.po_no)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.post_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.price_level)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.price_update)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.price_update_by)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.price_update_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_dt).HasColumnType("datetime");

                entity.Property(e => e.ref_no)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.sale_dt).HasColumnType("datetime");

                entity.Property(e => e.sales_person)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.salescomm_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.salescomm_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ship_address1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ship_address2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ship_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ship_city)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ship_contact_nm)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ship_country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ship_dt).HasColumnType("datetime");

                entity.Property(e => e.ship_fax1)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ship_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ship_nm)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ship_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ship_phone1)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ship_state)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ship_terms)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ship_via)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ship_zip)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.silver_price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.tax_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.tax_per).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.tax_terms)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.terms)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.tracking_no)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_for_flag)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.trans_period)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_qty_pc).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.trans_qty_wt).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.trans_type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.wip_posted_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<sysmmsmodulelink>(entity =>
            {
                entity.ToTable("sysmmsmodulelink");
                entity.HasKey(e => new { e.from_module_id, e.to_module_id });

                entity.HasIndex(e => new { e.from_module_id, e.to_module_id })
                    .HasName("sysmmsmodulelink_x")
                    .IsUnique();

                entity.Property(e => e.from_module_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.to_module_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.link)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.online)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<faartrpaymentdtl>(entity =>
            {
                entity.ToTable("faartrpaymentdtl");
                entity.HasKey(e => new { e.company_id, e.trans_bk, e.trans_no, e.trans_dt, e.serial_no });

                entity.HasIndex(e => new { e.inv_no, e.inv_dt })
                    .HasName("IX_faartrpaymentdtl_1");

                entity.HasIndex(e => new { e.company_id, e.voucher_no, e.voucher_dt, e.trans_dt })
                    .HasName("ix_faartrpaymentdtl_bda1");

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.serial_no)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.apply_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.apply_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.apply_to)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.balance_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.disctaken_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.disctaken_amt1).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.disctaken_amt2).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.due_dt).HasColumnType("datetime");

                entity.Property(e => e.gl_account)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.gl_account1)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.gl_account2)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.inv_dt).HasColumnType("datetime");

                entity.Property(e => e.inv_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.original_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ref_no)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.voucher_dt).HasColumnType("datetime");

                entity.Property(e => e.voucher_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<faartrinvhd>(entity =>
            {
                entity.ToTable("faartrinvhd");
                entity.HasKey(e => new { e.company_id, e.trans_bk, e.trans_no, e.trans_dt });

                entity.HasIndex(e => e.account_id)
                    .HasName("IX_faartrinvhd_1");

                entity.HasIndex(e => new { e.action_flag, e.account_id })
                    .HasName("IX_faartrinvhd_2");

                entity.HasIndex(e => new { e.trans_period, e.account_id })
                    .HasName("IX_faartrinvhd_3");

                entity.HasIndex(e => new { e.company_id, e.trans_dt, e.trans_period, e.trans_bk, e.trans_no })
                    .HasName("faartrinvhd_index1");

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_bk)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_dt).HasColumnType("datetime");

                entity.Property(e => e.account_id)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.action_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.approval_date).HasColumnType("datetime");

                entity.Property(e => e.approval_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.approval_user_cd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.balance_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.clear_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.clear_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.comments)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.description)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.disc_amt).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.disc_dt).HasColumnType("datetime");

                entity.Property(e => e.disc_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.disctaken_amt).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.due_dt).HasColumnType("datetime");

                entity.Property(e => e.interest_dt).HasColumnType("datetime");

                entity.Property(e => e.inv_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.inv_dt).HasColumnType("datetime");

                entity.Property(e => e.inv_no)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.inv_type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.item_qty).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.old_id)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.paid_amt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.parent_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.post_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.qb_date).HasColumnType("datetime");

                entity.Property(e => e.qb_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ref_trans_no)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.sale_dt).HasColumnType("datetime");

                entity.Property(e => e.sales_person)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.soldto_id)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.terms)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_period)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.trans_typ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<saoimsterms>(entity =>
            {
                entity.ToTable("saoimsterms");
                entity.HasIndex(e => e.id)
                    .HasName("saoimsterms_x")
                    .IsUnique();

                entity.Property(e => e.id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.company_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.disc_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.disc_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.pay10_date).HasColumnType("datetime");

                entity.Property(e => e.pay10_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay10_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay11_date).HasColumnType("datetime");

                entity.Property(e => e.pay11_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay11_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay12_date).HasColumnType("datetime");

                entity.Property(e => e.pay12_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay12_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay1_date).HasColumnType("datetime");

                entity.Property(e => e.pay1_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay1_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay2_date).HasColumnType("datetime");

                entity.Property(e => e.pay2_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay2_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay3_date).HasColumnType("datetime");

                entity.Property(e => e.pay3_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay3_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay4_date).HasColumnType("datetime");

                entity.Property(e => e.pay4_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay4_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay5_date).HasColumnType("datetime");

                entity.Property(e => e.pay5_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay5_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay6_date).HasColumnType("datetime");

                entity.Property(e => e.pay6_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay6_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay7_date).HasColumnType("datetime");

                entity.Property(e => e.pay7_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay7_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay8_date).HasColumnType("datetime");

                entity.Property(e => e.pay8_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay8_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.pay9_date).HasColumnType("datetime");

                entity.Property(e => e.pay9_days).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.pay9_per).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.trans_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.update_dt).HasColumnType("datetime");

                entity.Property(e => e.update_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.user_cd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
