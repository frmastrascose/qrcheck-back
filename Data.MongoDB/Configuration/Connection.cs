namespace Data.MongoDB.Configuration
{
    public abstract class Connection
    {
        public abstract string ConnectionString { get; }

        public abstract string Protocol { get; }

        public abstract string Host { get; }

        public abstract string Path { get; }

        public abstract int Port { get; }

        public abstract string Username { get; }

        public abstract string Password { get; }

        private UriBuilder? Builder { get; set; }

        public Uri? Uri
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ConnectionString))
                {
                    Builder ??= new UriBuilder(ConnectionString);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Host)) return null;

                    Builder ??= new UriBuilder(
                        Protocol,
                        Host,
                        Port,
                        Path)
                    {
                        UserName = Username,
                        Password = Password
                    };
                }

                return Builder.Uri;
            }
        }
    }
}
