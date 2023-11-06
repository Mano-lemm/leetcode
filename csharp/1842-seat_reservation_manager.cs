namespace csharp;

public class _1842_seat_reservation_manager
{
    private int _top = 0;
    private readonly PriorityQueue<int, int> _free = new();
    public _1842_seat_reservation_manager(int n) { }
    
    public int Reserve()
    {
        return _free.Count == 0 ? _top++ : _free.Dequeue();
    }
    
    public void Unreserve(int seatNumber) {
        if (seatNumber == _top - 1)
        {
            _top--;
            return;
        }
        _free.Enqueue(seatNumber, seatNumber);
    }
}
