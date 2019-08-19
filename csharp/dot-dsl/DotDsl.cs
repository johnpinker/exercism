using System.Collections.Generic;
using System.Collections;
public class Node: IEnumerable<Attr>
{
    private List<Attr> _attrs = new List<Attr>();
    public Attr[] Attrs {
        get{
            return _attrs.ToArray();
        }
        set{
            this._attrs = new List<Attr>(value);
        }
    }
    public string Name { get; set;}
    public Node(string name)
    {
        this.Name = name;
    }

    public void Add(Attr a)
    {
        _attrs.Add(a);
    }

    public void Add(string s1, string s2)
    {
        _attrs.Add(new Attr(s1, s2));
    }
    public override bool Equals(object obj)
    {
        Node n = (Node) obj;
        return (n.Name == this.Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<Attr> GetEnumerator()
    {
        return _attrs.GetEnumerator();
    }
}

public class Edge: IEnumerable<Attr>
{
    private List<Attr> _attrs = new List<Attr>();
    public Attr[] Attrs {
        get 
        {
            return _attrs.ToArray();
        }
        set{
            this._attrs = new List<Attr>(value);
        }
    }
    public string Edge1;
    public string Edge2;

    public Edge(string s1, string s2)
    {
        this.Edge1 = s1;
        this.Edge2 = s2;
    }

    public void Add(string s1, string s2)
    {
        this._attrs.Add(new Attr(s1, s2));
    }

    public override bool Equals(object obj)
    {
        Edge e = (Edge) obj;
        return ((this.Edge1==e.Edge1) && (this.Edge2==e.Edge2));
    }

    public override int GetHashCode()
    {
        return this.Edge1.GetHashCode() + this.Edge2.GetHashCode();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<Attr> GetEnumerator()
    {
        return _attrs.GetEnumerator();
    }
}

public class Attr
{
    public string Name;
    public string Value;

    public Attr(string s1, string s2)
    {
        Name = s1;
        Value = s2;
    }

    public override bool Equals(object obj)
    {
        Attr a = (Attr)obj;
        return ((this.Name == a.Name) && (this.Value == a.Value));
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Value.GetHashCode();
    }
}

public class Graph: IEnumerable<Node>
{
    private List<Node> _nodes = new List<Node>();
    public Node[] Nodes { 
        get {
            return _nodes.ToArray();
        }
        set {
            _nodes = new List<Node>(value);
        }
    }
    private List<Edge> _edges = new List<Edge>();
    public Edge[] Edges { 
        get
        {
            return _edges.ToArray();
        } 
        set
        {
            this._edges = new List<Edge>(value);
        }
    }
    private List<Attr> _attrs = new List<Attr>();
    public Attr[] Attrs 
    { 
        get
        {
            return _attrs.ToArray();
        } 
        set
        {
            this._attrs = new List<Attr>(value);
        }
    }

    public Graph()
    {
        //this.Nodes = new List<Node>();

        //this.Edges = new List<Edge>();
        //this.Attrs = new List<Attr>();
    }

    public override bool Equals(object obj)
    {
        Graph g = (Graph) obj;
        return _nodes.Equals(g._nodes);
    }

    public override int GetHashCode()
    {
        return _nodes.GetHashCode();
    }
    public void Add(Node n)
    {
        this._nodes.Add(n);
    }

    public void Add(Edge e)
    {
        this._edges.Add(e);
    }

    public void Add(Attr a)
    {
        this._attrs.Add(a);
    }

    public void Add(string s1, string s2)
    {
        this._attrs.Add(new Attr(s1, s2));
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<Node> GetEnumerator()
    {
        return _nodes.GetEnumerator();
    }

    

}