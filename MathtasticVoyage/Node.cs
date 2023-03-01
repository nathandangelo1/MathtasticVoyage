namespace MathtasticVoyage;
class Node<T>
{
    // FIELDS
    private T _data = default(T);
    private Node<T> _next = null;
    public T Data
    {
        get { return _data; }
        set { _data = value; }
    }
    public Node<T> Next
    {
        get { return _next; }
        set { _next = value; }
    }
    public Node()
    {
    }
    public Node(T initialData)
    {
        Data = initialData;
    }

}// End class Node