namespace Domain.Base
{
    public sealed class Config
    {
        private static Config instance;
        private static readonly object lockObject = new();

        public string ConnectionString { get; set; }

        private Config()
        {
        }

        public static Config Instance
        {
            get
            {
                // Bloqueo doble para garantizar la seguridad de hilos
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new Config();
                    }
                }
                return instance;
            }
        }
    }
}