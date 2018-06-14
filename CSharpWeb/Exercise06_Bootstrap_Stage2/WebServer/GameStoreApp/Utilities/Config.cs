namespace HTTPServer.GameStoreApp.Utilities
{
    public static class Config
    {
        public static readonly string ConnectionString = @"Server =.;
                                        Database = GameStore;
                                        Trusted_Connection = True; ";

        public static readonly string DefaultPath = @"..\..\..\GameStoreApp\Resources\{0}.html";

        public static readonly int FieldMinLength = 3;

        public static readonly int FieldMaxLength = 50;

        public static readonly string FormEmail = "email";

        public static readonly string FormFullName = "fullName";

        public static readonly string FormPassword = "password";

        public static readonly string FormConfirmPass = "confirmPass";

        public static readonly string HideElement = "style=\"display: none\" ";
    }
}