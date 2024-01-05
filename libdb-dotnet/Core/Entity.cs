namespace libdb_dotnet.Core
{
    public class Entity
    {
        public Guid ID { get; }

        public Entity()
        {
            ID = Guid.NewGuid();
        }
    }
}