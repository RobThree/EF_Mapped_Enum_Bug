using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Mapped_Enum_Bug
{
    public class Customer
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public ApprovalStatus ApprovalStatus { get; init; }
    }

    public enum ApprovalStatus
    {
        New = 'N',
        Onboarding = 'O',
        Active = 'A',
        InActive = 'I'
    }

    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
            => entity.Property(v => v.ApprovalStatus)
                .HasConversion(MyValueConverters.ApprovalStatusConverter)
                .HasDefaultValue(ApprovalStatus.New);
    }

    internal class MyValueConverters
    {
        public static ValueConverter<ApprovalStatus, char> ApprovalStatusConverter
            => new ValueConverter<ApprovalStatus, char>(
                value => (char)value,
                value => (ApprovalStatus)value
            );
    }
}
