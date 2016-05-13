﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class TupleExpressionNode : InternalNode
    {
        public TupleExpressionNode(Node innerNode, bool isAbstract) : base(innerNode, isAbstract)
        {
        }

        public TupleExpressionNode(Node innerNode, bool isAbstract, int editId) : base(innerNode, isAbstract, editId)
        {
        }

        protected override bool IsEqualToInnerNode(Node node)
        {
            var comparedNode = node as TupleExpression;
            if (comparedNode == null) return false;
            return true;
        }

        protected override Tuple<bool, Node> CompareChildren(Node node, Node binding)
        {
            var convertedNode = node as TupleExpression;
            if (convertedNode == null) return Tuple.Create<bool, Node>(false, null);

            if (convertedNode.Items.Count != Children.Count)
                return Tuple.Create<bool, Node>(false, null);

            for (var i = 0; i < Children.Count; i++)
            {
                var result = Children[i].Match(convertedNode.Items[i]);
                if (!result.Item1)
                    return Tuple.Create<bool, Node>(false, null);
                binding = AddBindingNode(binding, result.Item2);
            }
            return Tuple.Create<bool, Node>(true, binding);
        }
    }
}
