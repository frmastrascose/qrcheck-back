namespace Data.MongoDB.Configuration
{
    public abstract class Connection
    {
        public abstract string ConnectionString { get; }

        public abstract string Path { get; }

        private UriBuilder? Builder { get; set; }

        public Uri? Uri
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ConnectionString))
                {
                    Builder ??= new UriBuilder(ConnectionString);
                }

                return Builder.Uri;
            }
        }
    }
}
