 using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MealMate.Models;
using Action = MealMate.Models.Action;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Data
{
    public partial class MealMateNewContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public MealMateNewContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Desease> Desease { get; set; }
        public virtual DbSet<DeseaseFlagBlacklist> DeseaseFlagBlacklist { get; set; }
        public virtual DbSet<DeseaseIngredientBlacklist> DeseaseIngredientBlacklist { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<Diet> Diet { get; set; }
        public virtual DbSet<DietFlagBlacklist> DietFlagBlacklist { get; set; }
        public virtual DbSet<DietIngredientBlacklist> DietIngredientBlacklist { get; set; }
        public virtual DbSet<Flag> Flag { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientDetailTable> IngredientDetailTable { get; set; }
        public virtual DbSet<IngredientFlag> IngredientFlag { get; set; }
        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LocalizationTable> LocalizationTable { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Meal> Meal { get; set; }
        public virtual DbSet<MealPartecipants> MealPartecipants { get; set; }
        public virtual DbSet<MealRecipes> MealRecipes { get; set; }
        public virtual DbSet<Pantry> Pantry { get; set; }
        public virtual DbSet<PantryIngredient> PantryIngredient { get; set; }
        public virtual DbSet<PantryOvercard> PantryOvercard { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<ProductLocation> ProductLocation { get; set; }
        public virtual DbSet<ProductPricelog> ProductPricelog { get; set; }
        public virtual DbSet<ProductTable> ProductTable { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeFlag> RecipeFlag { get; set; }
        public virtual DbSet<RecipeRating> RecipeRating { get; set; }
        public virtual DbSet<RecipeSimpleIngredients> RecipeSimpleIngredients { get; set; }
        public virtual DbSet<RecipeSimpleInstrument> RecipeSimpleInstrument { get; set; }
        public virtual DbSet<RecipeStep> RecipeStep { get; set; }
        public virtual DbSet<RecipeStepFlag> RecipeStepFlag { get; set; }
        public virtual DbSet<RecipeStepIngredient> RecipeStepIngredient { get; set; }
        public virtual DbSet<RecipeStepInstrument> RecipeStepInstrument { get; set; }
        public virtual DbSet<RecipeStepOrder> RecipeStepOrder { get; set; }
        public virtual DbSet<ShoppingList> ShoppingList { get; set; }
        public virtual DbSet<ShoppingListElement> ShoppingListElement { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }
        public virtual DbSet<UserFamily> UserFamily { get; set; }
        public virtual DbSet<UserFamilyDesease> UserFamilyDesease { get; set; }
        public virtual DbSet<UserFamilyDiet> UserFamilyDiet { get; set; }
        public virtual DbSet<UserFamilyDietFlag> UserFamilyDietFlag { get; set; }
        public virtual DbSet<UserFamilyDietIngr> UserFamilyDietIngr { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("MMDefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("user");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("action");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.ActDescriptionLongId)
                    .HasColumnName("act_description_long_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActDescriptionShortId)
                    .HasColumnName("act_description_short_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActNameId)
                    .HasColumnName("act_name_id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.DefCulture).HasColumnName("def_culture");

                entity.Property(e => e.DefLanguage).HasColumnName("def_language");

                entity.Property(e => e.Iso)
                    .IsRequired()
                    .HasColumnName("iso")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.HasOne(d => d.DefCultureNavigation)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.DefCulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_country_culture");

                entity.HasOne(d => d.DefLanguageNavigation)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.DefLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_country_language");
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("culture");

                entity.Property(e => e.CultureId).HasColumnName("culture_id");

                entity.Property(e => e.CulNameId)
                    .HasColumnName("cul_name_id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Desease>(entity =>
            {
                entity.ToTable("desease");

                entity.Property(e => e.DeseaseId)
                    .HasColumnName("desease_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeseaseNameId)
                    .HasColumnName("desease_name_id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<DeseaseFlagBlacklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("desease_flag_blacklist");

                entity.Property(e => e.DeseaseId).HasColumnName("desease_id");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.HasOne(d => d.Desease)
                    .WithMany()
                    .HasForeignKey(d => d.DeseaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_desease_flag_blacklist_desease");

                entity.HasOne(d => d.Flag)
                    .WithMany()
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_desease_flag_blacklist_flag");
            });

            modelBuilder.Entity<DeseaseIngredientBlacklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("desease_ingredient_blacklist");

                entity.Property(e => e.DeseaseId).HasColumnName("desease_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.HasOne(d => d.Desease)
                    .WithMany()
                    .HasForeignKey(d => d.DeseaseId)
                    .HasConstraintName("FK_desease_ingredient_blacklist_desease");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_desease_ingredient_blacklist_ingredient");
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Diet>(entity =>
            {
                entity.ToTable("diet");

                entity.Property(e => e.DietId)
                    .HasColumnName("diet_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DietNameId)
                    .HasColumnName("diet_name_id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<DietFlagBlacklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("diet_flag_blacklist");

                entity.Property(e => e.DietId).HasColumnName("diet_id");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.HasOne(d => d.Diet)
                    .WithMany()
                    .HasForeignKey(d => d.DietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_diet_flag_blacklist_diet");

                entity.HasOne(d => d.Flag)
                    .WithMany()
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_diet_flag_blacklist_flag");
            });

            modelBuilder.Entity<DietIngredientBlacklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("diet_ingredient_blacklist");

                entity.Property(e => e.DietId).HasColumnName("diet_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.HasOne(d => d.Diet)
                    .WithMany()
                    .HasForeignKey(d => d.DietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_diet_ingredient_blacklist_diet");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_diet_ingredient_blacklist_ingredient1");
            });

            modelBuilder.Entity<Flag>(entity =>
            {
                entity.ToTable("flag");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.Property(e => e.FlagDescriptionId)
                    .HasColumnName("flag_description_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FlagNameId)
                    .HasColumnName("flag_name_id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("ingredient");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.DetailTableId).HasColumnName("detail_table_id");

                entity.Property(e => e.IngDescriptionLongId)
                    .HasColumnName("ing_description_long_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IngDescriptionShortId)
                    .HasColumnName("ing_description_short_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IngNameId)
                    .HasColumnName("ing_name_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductTableId).HasColumnName("product_table_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_ingredient_ingredient");

                entity.HasOne(d => d.ProductTable)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.ProductTableId)
                    .HasConstraintName("FK_ingredient_product_table");
            });

            modelBuilder.Entity<IngredientDetailTable>(entity =>
            {
                entity.HasKey(e => e.DetailTableId);

                entity.ToTable("ingredient_detail_table");

                entity.HasComment("Average days of life in optimal conditions");

                entity.Property(e => e.DetailTableId)
                    .HasColumnName("detail_table_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvgLife).HasColumnName("avg_life");

                entity.Property(e => e.PropCalcium).HasColumnName("prop_calcium");

                entity.Property(e => e.PropCarbohydrate).HasColumnName("prop_Carbohydrate");

                entity.Property(e => e.PropCholesterol).HasColumnName("prop_cholesterol");

                entity.Property(e => e.PropFatSaturated).HasColumnName("prop_fat_saturated");

                entity.Property(e => e.PropFatTotal).HasColumnName("prop_fat_total");

                entity.Property(e => e.PropFatUnsaturatedMono).HasColumnName("prop_fat_unsaturated_mono");

                entity.Property(e => e.PropFatUnsaturatedPoly).HasColumnName("prop_fat_unsaturated_poly");

                entity.Property(e => e.PropFiber).HasColumnName("prop_fiber");

                entity.Property(e => e.PropIron).HasColumnName("prop_iron");

                entity.Property(e => e.PropPotasium).HasColumnName("prop_potasium");

                entity.Property(e => e.PropProtein).HasColumnName("prop_protein");

                entity.Property(e => e.PropSodium).HasColumnName("prop_sodium");

                entity.Property(e => e.PropVitAIu).HasColumnName("prop_vitA_IU");

                entity.Property(e => e.PropVitARe).HasColumnName("prop_vitA_RE");

                entity.Property(e => e.PropVitB1).HasColumnName("prop_vitB_1");

                entity.Property(e => e.PropVitB2).HasColumnName("prop_vitB_2");

                entity.Property(e => e.PropVitB3).HasColumnName("prop_vitB_3");

                entity.Property(e => e.PropVitC).HasColumnName("prop_vitC");

                entity.Property(e => e.PropWater).HasColumnName("prop_water");

                entity.Property(e => e.SpecificWeight).HasColumnName("specific_weight");

                entity.Property(e => e.UnitType)
                    .HasColumnName("unit_type")
                    .HasDefaultValueSql("((3))");

                entity.HasOne(d => d.DetailTable)
                    .WithOne(p => p.IngredientDetailTable)
                    .HasForeignKey<IngredientDetailTable>(d => d.DetailTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredient_detail_table_ingredient");

                entity.HasOne(d => d.UnitTypeNavigation)
                    .WithMany(p => p.IngredientDetailTable)
                    .HasForeignKey(d => d.UnitType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredient_detail_table_unit_type");
            });

            modelBuilder.Entity<IngredientFlag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ingredient_flag");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.HasOne(d => d.Flag)
                    .WithMany()
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredient_flag_flag");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredient_flag_ingredient");
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.ToTable("instrument");

                entity.Property(e => e.InstrumentId).HasColumnName("instrument_id");

                entity.Property(e => e.InsDescriptionLongId)
                    .HasColumnName("ins_description_long_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDescriptionShortId)
                    .HasColumnName("ins_description_short_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsNameId)
                    .HasColumnName("ins_name_id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LocalizationTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("localization_table");

                entity.Property(e => e.ElementId).HasColumnName("element_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Localization).HasColumnName("localization");

                entity.HasOne(d => d.Language)
                    .WithMany()
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_localization_table_language");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("locations");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnName("zip_code")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_locations_country");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("meal");

                entity.Property(e => e.MealId).HasColumnName("meal_id");

                entity.Property(e => e.Daybanch).HasColumnName("daybanch");

                entity.Property(e => e.PlanedFor)
                    .HasColumnName("planed_for")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<MealPartecipants>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meal_partecipants");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.MealId).HasColumnName("meal_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Meal)
                    .WithMany()
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_meal_partecipants_meal");
            });

            modelBuilder.Entity<MealRecipes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meal_recipes");

                entity.Property(e => e.MealId).HasColumnName("meal_id");

                entity.Property(e => e.PersonsServed).HasColumnName("persons_served");

                entity.Property(e => e.Portions).HasColumnName("portions");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Meal)
                    .WithMany()
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_meal_recipes_meal");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_meal_recipes_recipe");
            });

            modelBuilder.Entity<Pantry>(entity =>
            {
                entity.ToTable("pantry");

                entity.Property(e => e.PantryId).HasColumnName("pantry_id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pantry)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pantry_user");
            });

            modelBuilder.Entity<PantryIngredient>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pantry_ingredient");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.PantryOcId).HasColumnName("pantry_oc_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pantry_ingredient_ingredient");

                entity.HasOne(d => d.PantryOc)
                    .WithMany()
                    .HasForeignKey(d => d.PantryOcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pantry_ingredient_pantry_overcard");
            });

            modelBuilder.Entity<PantryOvercard>(entity =>
            {
                entity.ToTable("pantry_overcard");

                entity.Property(e => e.PantryOvercardId)
                    .HasColumnName("pantry_overcard_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.PantryId).HasColumnName("pantry_id");

                entity.HasOne(d => d.Pantry)
                    .WithMany(p => p.PantryOvercard)
                    .HasForeignKey(d => d.PantryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pantry_overcard_pantry");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK_brand");

                entity.ToTable("producer");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandName)
                    .HasColumnName("brand_name")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.MainCountry).HasColumnName("main_country");
            });

            modelBuilder.Entity<ProductLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("product_location");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredient_location_locations");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredient_location_ingredient");
            });

            modelBuilder.Entity<ProductPricelog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("product_pricelog");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_pricelog_country");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_pricelog_product_table");
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.ToTable("product_table");

                entity.Property(e => e.ProductTableId).HasColumnName("product_table_id");

                entity.Property(e => e.ProducerId).HasColumnName("producer_id");

                entity.Property(e => e.UnitType)
                    .HasColumnName("unit_type")
                    .HasDefaultValueSql("((3))");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.ProductTable)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_table_brand");

                entity.HasOne(d => d.UnitTypeNavigation)
                    .WithMany(p => p.ProductTable)
                    .HasForeignKey(d => d.UnitType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_table_unit_type");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipe");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.CreatedByUser)
                    .HasColumnName("created_byUser")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedInDate)
                    .HasColumnName("created_inDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CultureId).HasColumnName("culture_id");

                entity.Property(e => e.DifficultyRating)
                    .HasColumnName("difficulty_rating")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.IsPublic)
                    .IsRequired()
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RecDescriptionLongId)
                    .HasColumnName("rec_description_long_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RecDescriptionShortId)
                    .HasColumnName("rec_description_short_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RecNameId)
                    .HasColumnName("rec_name_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TotalTimeCook).HasColumnName("total_time_cook");

                entity.Property(e => e.TotalTimeWait).HasColumnName("total_time_wait");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.CultureId)
                    .HasConstraintName("FK_recipe_culture");
            });

            modelBuilder.Entity<RecipeFlag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("recipe_flag");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Flag)
                    .WithMany()
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_flag_flag");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_flag_recipe");
            });

            modelBuilder.Entity<RecipeRating>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.ToTable("recipe_rating");

                entity.Property(e => e.RatingId)
                    .HasColumnName("rating_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.Liked)
                    .IsRequired()
                    .HasColumnName("liked")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRating)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_rating_recipe");
            });

            modelBuilder.Entity<RecipeSimpleIngredients>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("recipe_simple_ingredients");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_simple_ingredients_ingredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_simple_ingredients_recipe");
            });

            modelBuilder.Entity<RecipeSimpleInstrument>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("recipe_simple_instrument");

                entity.Property(e => e.InstrumentId).HasColumnName("instrument_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Instrument)
                    .WithMany()
                    .HasForeignKey(d => d.InstrumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_simple_instrument_instrument");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_simple_instrument_recipe");
            });

            modelBuilder.Entity<RecipeStep>(entity =>
            {
                entity.HasKey(e => e.StepId);

                entity.ToTable("recipe_step");

                entity.Property(e => e.StepId).HasColumnName("step_id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.OutputIngredientId).HasColumnName("output_ingredient_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.TimeCook).HasColumnName("time_cook");

                entity.Property(e => e.TimeWait).HasColumnName("time_wait");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.RecipeStep)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_action");

                entity.HasOne(d => d.OutputIngredient)
                    .WithMany(p => p.RecipeStep)
                    .HasForeignKey(d => d.OutputIngredientId)
                    .HasConstraintName("FK_recipe_step_ingredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeStep)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_recipe");
            });

            modelBuilder.Entity<RecipeStepFlag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("recipe_step_flag");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.Property(e => e.RecipeStepId).HasColumnName("recipe_step_id");

                entity.HasOne(d => d.Flag)
                    .WithMany()
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_note_Note");

                entity.HasOne(d => d.RecipeStep)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_note_recipe_step");
            });

            modelBuilder.Entity<RecipeStepIngredient>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("recipe_step_ingredient");

                entity.Property(e => e.IngredientAmount)
                    .HasColumnName("ingredient_amount")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.RecipeStepId).HasColumnName("recipe_step_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_ingredient_ingredient");

                entity.HasOne(d => d.RecipeStep)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_ingredient_recipe_step");
            });

            modelBuilder.Entity<RecipeStepInstrument>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("recipe_step_instrument");

                entity.Property(e => e.RecipeStepId).HasColumnName("recipe_step_id");

                entity.Property(e => e.RecipeStepInstrument1).HasColumnName("recipe_step_instrument");

                entity.HasOne(d => d.RecipeStep)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_instrument_recipe_step");

                entity.HasOne(d => d.RecipeStepInstrument1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeStepInstrument1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_instrument_instrument");
            });

            modelBuilder.Entity<RecipeStepOrder>(entity =>
            {
                entity.HasKey(e => e.RecipeStepId);

                entity.ToTable("recipe_step_order");

                entity.Property(e => e.RecipeStepId)
                    .HasColumnName("recipe_step_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.VetexRecipeStepId).HasColumnName("vetex_recipe_step_id");

                entity.HasOne(d => d.RecipeStep)
                    .WithOne(p => p.RecipeStepOrderRecipeStep)
                    .HasForeignKey<RecipeStepOrder>(d => d.RecipeStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_order_recipe_step2");

                entity.HasOne(d => d.VetexRecipeStep)
                    .WithMany(p => p.RecipeStepOrderVetexRecipeStep)
                    .HasForeignKey(d => d.VetexRecipeStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipe_step_order_recipe_step3");
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.ToTable("shopping_list");

                entity.Property(e => e.ShoppingListId).HasColumnName("shopping_list_id");

                entity.Property(e => e.CompletedAtDate)
                    .HasColumnName("completed_atDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAtDate)
                    .HasColumnName("created_atDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ShoppingListElement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shopping_list_element");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.IsFullfilled).HasColumnName("is_fullfilled");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShoppingListId).HasColumnName("shopping_list_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shopping_list_element_ingredient");

                entity.HasOne(d => d.ShoppingList)
                    .WithMany()
                    .HasForeignKey(d => d.ShoppingListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shopping_list_element_shopping_list");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("unit_type");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unit_name")
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserFamily>(entity =>
            {
                entity.HasKey(e => e.FamilyMember);

                entity.ToTable("user_family");

                entity.Property(e => e.FamilyMember).HasColumnName("family_member");

                entity.Property(e => e.CultureId).HasColumnName("culture_id");

                entity.Property(e => e.IsGuest).HasColumnName("isGuest");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.SecondName)
                    .HasColumnName("second_name")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.UserFamily)
                    .HasForeignKey(d => d.CultureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_culture");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFamily)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_family_user");
            });

            modelBuilder.Entity<UserFamilyDesease>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_family_desease");

                entity.Property(e => e.DeseaseId).HasColumnName("desease_id");

                entity.Property(e => e.UserFamilyMemberId).HasColumnName("user_family_member_id");

                entity.HasOne(d => d.Desease)
                    .WithMany()
                    .HasForeignKey(d => d.DeseaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_desease_desease");

                entity.HasOne(d => d.UserFamilyMember)
                    .WithMany()
                    .HasForeignKey(d => d.UserFamilyMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_desease_user_family");
            });

            modelBuilder.Entity<UserFamilyDiet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_family_diet");

                entity.Property(e => e.DietId).HasColumnName("diet_id");

                entity.Property(e => e.UserFamilyMemberId).HasColumnName("User_family_member_id");

                entity.HasOne(d => d.Diet)
                    .WithMany()
                    .HasForeignKey(d => d.DietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_diet_diet");

                entity.HasOne(d => d.UserFamilyMember)
                    .WithMany()
                    .HasForeignKey(d => d.UserFamilyMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_diet_user_family");
            });

            modelBuilder.Entity<UserFamilyDietFlag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_family_diet_flag");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.FlagId).HasColumnName("flag_id");

                entity.HasOne(d => d.FamilyMember)
                    .WithMany()
                    .HasForeignKey(d => d.FamilyMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_diet_flag_user_family");

                entity.HasOne(d => d.Flag)
                    .WithMany()
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_diet_flag_flag");
            });

            modelBuilder.Entity<UserFamilyDietIngr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_family_diet_ingr");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.HasOne(d => d.FamilyMember)
                    .WithMany()
                    .HasForeignKey(d => d.FamilyMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_diet_ingr_user_family");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_family_diet_ingr_ingredient");
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_settings");

                entity.Property(e => e.DefCountryId)
                    .HasColumnName("def_country_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ExpAllarm)
                    .IsRequired()
                    .HasColumnName("exp_allarm")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsPublic)
                    .IsRequired()
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.NewRecSugg)
                    .IsRequired()
                    .HasColumnName("new_rec_sugg")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NoPantry).HasColumnName("no_pantry");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Language)
                    .WithMany()
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_settings_language");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_settings_user");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
