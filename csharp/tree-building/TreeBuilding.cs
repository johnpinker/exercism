using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;

    public Tree GetNode(int id)
    {
        Tree retVal;
        if (id == this.Id)
            return this;
        else 
            return Children.Where(t => t.Id == id).First();
    }
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        /* 
        var ordered = new SortedList<int, TreeBuildingRecord>();
 
        foreach (var record in records)
        {
            ordered.Add(record.RecordId, record);
        }

        records = ordered.Values;
*/
        if (records.Count() == 0)
        {
            throw new ArgumentException();
        }
        records = records.OrderBy(t => t.RecordId);

        //var trees = new List<Tree>();
        //var previousRecordId = -1;

        Tree rootNode = new Tree();
        TreeBuildingRecord tr = records.ElementAt(0);
 
        if (tr.ParentId !=0 || tr.RecordId != 0)
            throw new ArgumentException();
        rootNode.Id = tr.RecordId;
        int lastNodeId = rootNode.Id;
        rootNode.Children = new List<Tree>();

        for (int i=1; i< records.Count(); i++)
        {
            TreeBuildingRecord tbr = records.ElementAt(i);
            if ((tbr.ParentId == tbr.RecordId) || tbr.ParentId > tbr.RecordId || tbr.RecordId != lastNodeId+1)
                throw new ArgumentException();
            Tree tmpRoot = rootNode.GetNode(tbr.ParentId);
            Tree tmpNode = new Tree();
            tmpNode.Id = tbr.RecordId;
            lastNodeId = tmpNode.Id;
            tmpNode.ParentId = tbr.RecordId;
            tmpNode.Children = new List<Tree>();
            tmpRoot.Children.Add(tmpNode);


        }
/* 
        foreach (var record in records)
        {   
            var t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId };
            trees.Add(t);

            if ((t.Id == 0 && t.ParentId != 0) ||
                (t.Id != 0 && t.ParentId >= t.Id) ||
                (t.Id != 0 && t.Id != previousRecordId + 1))
            {
                throw new ArgumentException();
            }

            ++previousRecordId;
        }
        */
        //if (trees.Count == 0)

/* 
        for (int i = 1; i < trees.Count; i++)
        {
            var t = trees.First(x => x.Id == i);
            var parent = trees.First(x => x.Id == t.ParentId);
            parent.Children.Add(t);
        }
*/
        //var r = trees.First(t => t.Id == 0);
        //return r;
        return rootNode;
    }
}