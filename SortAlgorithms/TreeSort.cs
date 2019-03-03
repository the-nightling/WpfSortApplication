using System;
using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worst: O(n^2)
	/// - Average: Θ(nlog(n))
	/// - Best: Ω(nlog(n))
	/// Space Complexity: O(n)
	/// 
	/// Stable
	/// Requires memory to be allocated on the heap
	/// 
	/// </summary>
	public class TreeSort : SortAlgorithm
	{
		private Node tree;

		public TreeSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{
			this.tree = new Node();
		}

		public override void Sort()
		{
			for (int i = 0; i < Items.Count; i++)
				InsertIntoTree(Items[i], this.tree);

			Items.Clear();
			InOrderTraversal(this.tree, Items);
		}

		public override void SortStep()
		{
			throw new NotImplementedException();
		}

		private void InsertIntoTree(Item item, Node subTree)
		{
			if (subTree.Item == null)
			{
				subTree.Item = item;
				subTree.LeftSubTree = new Node();
				subTree.RightSubTree = new Node();
			}
			else if (item.Value < subTree.Item.Value)
			{
				InsertIntoTree(item, subTree.LeftSubTree);
			}
			else if (item.Value > subTree.Item.Value)
			{
				InsertIntoTree(item, subTree.RightSubTree);
			}
		}

		private void InOrderTraversal(Node tree, ObservableCollection<Item> sortedItems)
		{
			if (tree.Item == null)
				return;

			InOrderTraversal(tree.LeftSubTree, sortedItems);

			sortedItems.Add(tree.Item);

			InOrderTraversal(tree.RightSubTree, sortedItems);
		}

		private class Node
		{
			public Item Item { get; set; }
			public Node LeftSubTree { get; set; }
			public Node RightSubTree { get; set; }
		}
	}
}
