namespace HTTPServer.ByTheCakeApplication.Utilities
{
    public static class Config
    {
        public static readonly string ConnectionString = @"Server = .;
                                        Database = ByTheCake;
                                        Trusted_Connection = True; ";

        public static readonly int FieldMinLength = 3;

        public static readonly int FieldMaxLength = 50;
    }
}