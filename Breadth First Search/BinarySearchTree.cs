

public class BinarySearchTree
{
    public TreeNode? Root { get; set; }
    public BinarySearchTree()
    {
        Root = null;
    }
    public BinarySearchTree(int rootData)
    {
        Root = new TreeNode(rootData);
    }

    public void Add(int data)
    {
        
        if (Root == null)
        {
            Root = new TreeNode(data);
            return;
        }

        TreeNode? cur = Root, pre = null;
        while (cur != null)
        {
            if (cur.Data == data) return;

            pre = cur;

            if (data < cur.Data) cur = cur.Left;
            else cur = cur.Right;
        }

        var newNode = new TreeNode(data);
        if (data < pre.Data) pre.Left = newNode;
        else  pre.Right = newNode;
    }

    public void Remove(int data)
    {
        
        if (Root == null) return;

        TreeNode? cur = Root, pre = null;
        while (cur != null)
        {
            if (cur.Data == data) break;

            pre = cur;

            if (data < cur.Data) cur = cur.Left;
            else cur = cur.Right;
        }

        if (cur == null) return;
        

        if (cur.Left == null || cur.Right == null)
        {
            
            var child = cur.Left ?? cur.Right;
            
            if (cur != Root)
            {
                if (cur == pre.Left) pre.Left = child;
                else pre.Right = child;
            }
            else 
            {
                Root = child;
            }
        }
        else
        {
            var temp = cur.Right;
            while (temp.Left != null)
            {
                temp = temp.Left;
            }

            Remove(temp.Data);
            cur.Data = temp.Data;
            
        }
    } 
}