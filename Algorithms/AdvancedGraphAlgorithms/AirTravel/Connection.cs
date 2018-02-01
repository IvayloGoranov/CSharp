
public class Connection
{
    public Connection(Node node, long travellingTime, long departure, long timeBetweenFlights)
    {
        this.Node = node;
        this.TravellingTime = travellingTime;
        this.DepartureTime = departure;
        this.Period = timeBetweenFlights;
    }

    public Node Node { get; set; }

    public long TravellingTime { get; set; }

    public long DepartureTime { get; set; }

    public long Period { get; set; }
}
