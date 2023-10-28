namespace csharp;

public class TreeNode {
     public int val;
     public TreeNode? left;
     public TreeNode? right;
     public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
}

public class _0515_find_largest_value_in_each_tree_row {
    public IList<int> LargestValues(TreeNode root)
    {
        var r = new List<int>();
        var c = new List<TreeNode>() { root }.Where(x => x != null).ToList();
        while (c.Count > 0)
        {
            r.Add(c.Select(x => x.val).Max());
            c = c.SelectMany(x => new[] {x.left, x.right}).Where(x => x != null).ToList();
        }
        return r;
    } 
}
