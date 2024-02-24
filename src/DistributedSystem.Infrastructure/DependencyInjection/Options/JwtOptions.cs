namespace DistributedSystem.Infrastructure.DependencyInjection.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int ExpireMin { get; set; }
    }
}