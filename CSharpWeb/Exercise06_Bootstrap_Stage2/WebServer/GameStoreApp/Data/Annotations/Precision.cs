namespace HTTPServer.GameStoreApp.Data.Annotations
{
    using System;

    public class Precision : Attribute
    {
        public Precision(byte precision, byte scale)
        {
            this.precision = precision;
            this.scale = scale;
        }

        public byte precision { get; set; }

        public byte scale { get; set; }

        //public static void ConfigureModelBuilder(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Properties().Where(x => x.GetCustomAttributes(false).OfType<Precision>().Any())
        //        .Configure(c => c.HasPrecision(c.ClrPropertyInfo.GetCustomAttributes(false).OfType<Precision>().First()
        //            .precision, c.ClrPropertyInfo.GetCustomAttributes(false).OfType<Precision>().First().scale));
        //}
    }
}