namespace IO
{
    public interface IGameObject
    {
        int Guid { get; }
        IVector Location { get; set; }
        string Model { get; set; }
        double Size { get; set; }
    }
}