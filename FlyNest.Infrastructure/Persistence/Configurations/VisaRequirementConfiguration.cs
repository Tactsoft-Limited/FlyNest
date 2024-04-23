using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class VisaRequirementConfiguration : IEntityTypeConfiguration<VisaRequirement>
{
    public void Configure(EntityTypeBuilder<VisaRequirement> builder)
    {
        builder.ToTable(nameof(VisaRequirement));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.VisaRequirements).HasForeignKey(x => x.CountryId);
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.Validity).HasMaxLength(85);
        builder.Property(x => x.MaxStay).HasMaxLength(85);
        builder.HasData(new VisaRequirement
        {
            Id = 1,
            CountryId = 12,
            BasicDocument = "Seven (07) Months Valid Passport with the last one Old Passport if have one (if an OLD passport is Lost then a GD copy with a translated notary must be required). Recent 2 copy photographs taken in the last 6 months (white background only, photo size 35 mm X 45 mm). Personal / Company Bank statement of the last 06 months with Bank Solvency Certificate (Minimum balance BDT 60,000 for each applicant). Visiting Card.",
            ForBusinessPerson = "Renewal Trade license copy with notary public (English Translated). Memorandum for Limited Company. Office Pad / Company Letter Head Pad.",
            ForJobHolder = "No Objection Certificate (NOC) from Employer (with an official Cell phone and TnT numbers). Visiting card. Mandatory official ID card copy. In the case of a Personal Account Statement (Savings Account) - need to provide the Salary Certificate/Payslip last 03 months. BMDC certificate for Doctor. BAR Council Certificate for Advocate. Retirement certificate for Retired Person. For Govt. employees - GO is required with an English translation notary must be required.",
            ForStudent = "Student ID card copy.Birth Certificate (Only for Child & infant).Travel Letter or Leave Letter from the Educational Institute.",
            ForMedical = " In case of medical treatment, a copy of the appointment letter from a hospital in Thailand and if applicable, an original letter from a local doctor/hospital if the applicant is a first-time traveler. Recent case summary of the patient’s medical reports issued by the local hospital. Copy of recent certificate of acceptance for treatment/invitation letter from the receiving hospital in Thailand confirming the patient’s condition and the necessity of transfer to Thailand. The letter should mention the accompanying person's name(s) & relation, who will travel with the patient by Air Ambulance. Booking confirmation letter (such as Med letter & Action Plan) of an Air Ambulance.",
            VisaFee = "BDT 4,900 (Non-refundable)",
            Others = "Note: Marriage Certificate Copy or Nikahnama or the contract of marriage (if the spouse's name is not mentioned in the Applicant's passport). Note: Delivery Time (8 to 15) working days (Depend on Embassy). Note: Visa validity 3 months, single entry. Note: Visa rate can be changed without prior notice. Note: Visa issuance rights reserved by the Embassy.",
            Validity = "90 Days",
            MaxStay = "30 Days",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow
        }, new VisaRequirement
        {
            Id = 2,
            CountryId = 16,
            BasicDocument = "Seven (07) Months Valid Passport with Old Passport if have one. Visiting Card. Recent 2 copy photographs taken in the last 3 months (white background only, photo size 35 mm X 50 mm, Matt paper). Bank Statements last six months with a bank solvency certificate (Minimum balance BDT 60,000 for each applicant). Vaccine certificate copy (double dose). Hotel Booking Copy. Air Ticket Booking Copy.",
            ForBusinessPerson = "Renewal Trade license copy with notary public ( English Translated ). Memorandum for Limited Company. The blank page of the office pad.",
            ForJobHolder = "No Objection Certificate (NOC). BMDC certificate for Doctor. BAR Council Certificate for Advocate.",
            ForStudent = " Student ID card Photo Copy. Birth Certificate ( Only for Child & Infant).",
            ForMedical = string.Empty,
            VisaFee = "BDT 3,900 ( Non-refundable )",
            Others = "Note: Marriage Certificate Copy (For family application only) One Country Visit is required - Except India, Nepal, Sri Lanka, Maldives, Bhutan, and UAE. Note: Delivery Time (25 to 30) working days Minimum. Note: Visa validity 6 months, Single entry - E-Visa. Note: Visa rate can be changed without prior notice. Note: Visa issuance rights are reserved by the Embassy.",
            Validity = "90 Days",
            MaxStay = "30 Days",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow
        }, new VisaRequirement
        {
            Id = 3,
            CountryId = 17,
            BasicDocument = "Recent Valid Passport & All Previous passports. Last Indian visa copy (if any). NID copy (Both Side). Recent 1 Copy Photo (2\"x2\", white background, glossy/matte paper). Latest Utility (Electricity/Gas/Water) bill copy. NOC from the company - (If doing any job). Salary Certificate. Trade License- If Business. Visiting card/Employee ID card (Both Side). Bank statement of last 06 months/Dollar endorsement certificate (at least USD $200). Student ID Card copy (Both Side) and Birth Certificate (If Student). Previous SAARC visited country name  & year of visit - if any. Previous NON-SAARC visited country name - if any.",
            ForBusinessPerson = " Profession proof. Tin, Tax certificate. Invitation letter. IRC/ERC. LC / Dual party Agreement. Association certificate.",
            ForJobHolder = string.Empty,
            ForStudent = string.Empty,
            ForMedical = "Medical Invitation letter from India with a specific date. All Medical original documents. Profession proof.",
            VisaFee = "ST processing & Embassy BDT 1,500/-",
            Others = string.Empty,
            Validity = "90 Days",
            MaxStay = "30 Days",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow
        }, new VisaRequirement
        {
            Id = 4,
            CountryId = 7,
            BasicDocument = "Valid passport copy (Must be clear). Confirm Air Ticket. Confirm Hotel.",
            ForBusinessPerson = string.Empty,
            ForJobHolder = string.Empty,
            ForStudent = string.Empty,
            ForMedical = string.Empty,
            VisaFee = "Per person BDT 3,400/- (Non-refundable)",
            Others = "Note: Delivery time (1-2 Working days)",
            Validity = "90 Days",
            MaxStay = "30 Days",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow
        }, new VisaRequirement
        {
            Id = 5,
            CountryId = 15,
            BasicDocument = "Seven (07) months valid passport with an old passport if you have one. Visiting card. NID / Birth certificate copy. Recent 2 copy photographs taken in the last 3 months (matt paper, white background only). 35 mm in width x 45mm in height. For First time visit to Singapore - Bank Statement and Solvency certificate are required (with a minimum BDT 80,000 ending balance). V39A Invitation. Confirmed Hotel booking copy. Air ticket booking copy.",
            ForBusinessPerson = "Renewal trade license copy with notary public ( English Translated ). Memorandum for limited company / Form XII. The blank page of office pad.",
            ForJobHolder = "No objection certificate (NOC). BMDC certificate for Doctor . BAR Council certificate for Advocate. Retirement document for Retired Person.",
            ForStudent = "Student ID card Photo Copy. NOC from College/University. Birth certificate (Only for Child & infant).",
            ForMedical = string.Empty,
            VisaFee = "Visa Fee Per Person: BDT 3,900 (Without LOI support) and BDT 4,100 with LOI support. (Non-refundable)",
            Others = "Note: Marriage certificate copy (if spouse's name is not mentioned in the Passport). Note: Visa rate can change without prior notice. Note: Delivery time (7 to 10) working days. Note: Visa validity is 60 days. Note: Visa issuance rights are reserved by the Embassy.",
            Validity = "90 Days",
            MaxStay = "30 Days",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow
        });
    }
}
