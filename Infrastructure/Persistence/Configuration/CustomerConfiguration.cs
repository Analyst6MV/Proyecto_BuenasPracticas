using Domain.Customer;
using Domain.ValueObject;


namespace Infrastructure.Persistence.Configuration
{
    internal class CustomerConfiguration //: IEntityTypeConfiguration<Customer>
    {
        //public void Configure(EntityTypeBuilder<Customer> builder)
        //{
      

        //    builder.HasKey(c => c.Id);
        //    builder.Property(c => c.Id).HasConversion(
        //        customerId => customerId.Value,
        //        value => new CustomerId(value)
        //        );
        //    builder.Property(c => c.PrimerNombre).HasMaxLength(50);
        //    builder.Property(c => c.SegundoNombre).HasMaxLength(50);
        //    builder.Property(c => c.PrimerApellido).HasMaxLength(50);
        //    builder.Property(c => c.SegundoApellido).HasMaxLength(50);

        //    builder.Property(c => c.Email).HasMaxLength(255);
        //    builder.HasIndex(c => c.Email).IsUnique();
        //    builder.Property(c => c.Password).HasMaxLength(100);

        //    builder.Property(c => c.IndicativoCelular);

        //    builder.Property(c => c.NumeroCelular).HasConversion(
        //                numeroCelular => numeroCelular.Value,
        //                value => NumeroCelular.Create(value)!
        //                ).HasMaxLength(20);

        //    builder.Property(c => c.IndicativoWhatsapp);

        //    builder.Property(c => c.NumeroWhatsapp).HasConversion(
        //                numeroWhatsapp => numeroWhatsapp.Value,
        //                value => NumeroCelular.Create(value)!
        //                ).HasMaxLength(20);


        //    builder.Property(c => c.TipoDocumento);

        //    builder.Property(c => c.NumeroDocumento);


        //    builder.OwnsOne(c => c.Direccion, DirecionBuilder =>
        //    {
                
        //        DirecionBuilder.Property(c => c.IdTipoVia);
        //        DirecionBuilder.Property(c => c.TipoVia);
        //        DirecionBuilder.Property(c => c.NumeroVia);
        //        DirecionBuilder.Property(c => c.ApendiceVia);
        //        DirecionBuilder.Property(c => c.NumeroCruce);
        //        DirecionBuilder.Property(c => c.ApendiceCruce);
        //        DirecionBuilder.Property(c => c.MetrosEsquina);
        //        DirecionBuilder.Property(c => c.DescripcionAdicional).HasMaxLength(80).IsRequired(false);
        //        DirecionBuilder.Ignore(c => c.DireccionCompleta);
        //        DirecionBuilder.Property(c => c.CodigoPostal);
        //        DirecionBuilder.Property(c => c.IdPais);
        //        DirecionBuilder.Property(c => c.IdDepartamento);
        //        DirecionBuilder.Property(c => c.IdCiudad);


        //    });

        //    builder.Property(c => c.TokenAcceso);
        //    builder.Property(c => c.FechaCreacionTokenAcceso);
        //    builder.Property(c => c.CodigoValidacion);
        //    builder.Property(c => c.FechaCreacionCodigoValidacion);
        //    builder.Property(c => c.EstadoUsuario);
        //    builder.Property(c => c.SesionActiva);

        //}
    }
}
