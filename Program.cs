

// Question 1: Implement Doubly Circular Linked List
Playlist myPlaylist = new Playlist();

myPlaylist.AddSong("Song 1");
myPlaylist.AddSong("Song 2");
myPlaylist.AddSong("Song 3");
myPlaylist.AddSong("Song 4");

Console.WriteLine("**********Output of Doubly Circular Linked List**********");
Console.WriteLine("Playlist:");
myPlaylist.DisplayPlaylist();

//**************************************************//
// Question 2: Implement Delegate and Print Message
Console.WriteLine("**********Output of Delegate**********");
MessageDelegate messageDelegate = PrintMessage;
messageDelegate("Call from delegate");
Console.WriteLine();

static void PrintMessage(string message)
{
    Console.WriteLine(message);
}

//***************************************************//
// Question 3: Group By Query Table Customer and Order

var customers = new List<Customer>
        {
            new Customer { CustomerId = 1, CustomerName = "Jatin" },
            new Customer { CustomerId = 2, CustomerName = "Dhrvuin" },
            new Customer { CustomerId = 3, CustomerName = "Sarvesh" }
        };

var orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 1, OrderAmount = 100 },
            new Order { OrderId = 2, CustomerId = 2, OrderAmount = 200 },
            new Order { OrderId = 3, CustomerId = 1, OrderAmount = 300 },
            new Order { OrderId = 4, CustomerId = 3, OrderAmount = 400 },
            new Order { OrderId = 5, CustomerId = 2, OrderAmount = 500 }
        };

var data = orders.Join(customers, (order => order.CustomerId), (customer => customer.CustomerId),
                      (order, customer) => new { customer.CustomerName, order.OrderAmount })
                  .GroupBy(x => x.CustomerName)
                  .Select(x => new { CustomerName = x.Key, Total = x.Sum(x => x.OrderAmount) });

Console.WriteLine("**********Output of Group By Query**********");

foreach (var item in data)
{
    Console.WriteLine($"Customer Name: {item.CustomerName}");
    Console.WriteLine($"Tota: {item.Total}");
    Console.WriteLine();
}


//***************************************************//
public class Node
{
    public string Song { get; set; }
    public Node? Next { get; set; }
    public Node? Previous { get; set; }

    public Node(string song)
    {
        Song = song;
        Next = null;
        Previous = null;
    }
}
public class Playlist
{
    private Node? head;

    public Playlist()
    {
        head = null;
    }

    public void AddSong(string song)
    {
        Node newNode = new Node(song);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            newNode.Previous = head;
        }
        else
        {
            if(head.Previous != null)
            {
                Node lastNode = head.Previous;

                if (lastNode != null)
                {
                    lastNode.Next = newNode;
                    newNode.Previous = lastNode;
                }
                newNode.Next = head;
                head.Previous = newNode;
            }
        }
    }

    public void DisplayPlaylist()
    {
        if (head == null)
        {
            Console.WriteLine("Playlist is empty.");
            return;
        }

        Node current = head;
        do
        {
            Console.WriteLine(current?.Song);
            if (current?.Next != null)
            {
                current = current.Next;
            }
        } while (current != head);
    }
}

//Declare delegate
public delegate void MessageDelegate(string message);

public class Customer
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal OrderAmount { get; set; }
}