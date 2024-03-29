﻿using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class MedicalExaminationResultEntityTypeConfiguration : IEntityTypeConfiguration<MedicalExaminationResult>
    {
        public void Configure(EntityTypeBuilder<MedicalExaminationResult> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.MedicalExamination)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
