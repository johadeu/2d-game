using Godot;

public static class NodeUtils 
{
    public static T GetNode<T>(this Node node, string path) where T : Node
    {
        return node.GetNode(path) as T;
    } 
}