using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasID
{
    public class Zipper
    {
        private BinTree _currentTree;  
        private Zipper? _parent;       
        private bool _isLeft;          

        private Zipper(BinTree currentTree, Zipper? parent, bool isLeft)
        {
            _currentTree = currentTree;
            _parent = parent;
            _isLeft = isLeft;
        }

        public static Zipper FromTree(BinTree tree)
        {
            return new Zipper(tree, null, false);
        }

        public Zipper? Left()
        {
            if (_currentTree.Left == null) return null;
            return new Zipper(_currentTree.Left, this, true);
        }

        public Zipper? Right()
        {
            if (_currentTree.Right == null) return null;
            return new Zipper(_currentTree.Right, this, false);
        }

        public Zipper? Up()
        {
            if (_parent == null) return null;

            BinTree updatedTree;
            if (_isLeft)
            {
                updatedTree = new BinTree(_parent._currentTree.Value, _currentTree, _parent._currentTree.Right);
            }
            else
            {
                updatedTree = new BinTree(_parent._currentTree.Value, _parent._currentTree.Left, _currentTree);
            }

            return new Zipper(updatedTree, _parent._parent, _parent._isLeft);
        }

        public Zipper SetValue(int newValue)
        {
            _currentTree = new BinTree(newValue, _currentTree.Left, _currentTree.Right);
            return this;
        }

        public Zipper SetLeft(BinTree? binTree)
        {
            _currentTree = new BinTree(_currentTree.Value, binTree, _currentTree.Right);
            return this;
        }

        public Zipper SetRight(BinTree? binTree)
        {
            _currentTree = new BinTree(_currentTree.Value, _currentTree.Left, binTree);
            return this;
        }

        public BinTree ToTree()
        {
            if (_parent == null) return _currentTree;
            return Up()!.ToTree();  // Recursively move up and rebuild the tree
        }

        public int Value()
        {
            return _currentTree.Value;
        }

        // Equality override
        public override bool Equals(object? obj)
        {
            if (obj is Zipper zipper)
            {
                return _currentTree.Equals(zipper._currentTree);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _currentTree.GetHashCode();
        }
    }

}
