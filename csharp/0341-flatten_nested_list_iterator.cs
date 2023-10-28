namespace csharp;

public interface NestedInteger {
   // @return true if this NestedInteger holds a single integer, rather than a nested list.
   bool IsInteger();

   // @return the single integer that this NestedInteger holds, if it holds a single integer
   // Return null if this NestedInteger holds a nested list
   int GetInteger();

   // @return the nested list that this NestedInteger holds, if it holds a nested list
   // Return null if this NestedInteger holds a single integer
   IList<NestedInteger> GetList();
}

public class reallyNested : NestedInteger
{
    private Object _obj;

    public reallyNested(int obj)
    {
        _obj = obj;
    }

    public reallyNested(List<reallyNested> obj)
    {
        _obj = obj;
    }
    
    public bool IsInteger()
    {
        return _obj is int;
    }

    public int GetInteger()
    {
        return (int)_obj;
    }

    public IList<NestedInteger> GetList()
    {
        var x = (List<reallyNested>)_obj;
        return x.Select(y => (NestedInteger)y).ToList();
    }
}

public class _0341_flatten_nested_list_iterator
{
   private Stack<(int, IList<NestedInteger>)> _stack = new();
   private IList<NestedInteger> _nestedIntegers;
   private int _cur;
   
   public _0341_flatten_nested_list_iterator(IList<NestedInteger> nestedList)
   {
       _nestedIntegers = nestedList;
       _cur = 0;
   }

   public bool HasNext() {
       while (_cur < _nestedIntegers.Count)
       {
           if (_stack.Count == 0)
           {
               if (_nestedIntegers[_cur].IsInteger())
               {
                   return true;
               }
               _stack.Push((0, _nestedIntegers[_cur].GetList()));
               continue;
           }

           while (_stack.Count > 0 && _stack.Peek().Item1 == _stack.Peek().Item2.Count)
           {
               _stack.Pop();
           }

           if (_stack.Count == 0)
           {
               _cur++;
               continue;
           }

           if (_stack.Peek().Item2[_stack.Peek().Item1].IsInteger())
           {
               return true;
           }

           var (idx, ls) = _stack.Pop();
           _stack.Push((idx + 1, ls));
           _stack.Push((0, ls[idx].GetList()));
       }

       return false;
   }
   

   public int Next() {
       if (_stack.Count == 0)
       {
           return _nestedIntegers[_cur++].GetInteger();
       }

       var (idx, ls) = _stack.Pop();
       _stack.Push((idx + 1, ls));
       return ls[idx].GetInteger();
   } 
}