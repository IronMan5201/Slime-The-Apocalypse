using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public enum NodeState { RUNNING, SUCCESS, FAILURE }

    public class BTNode
    {
        protected NodeState state;

        public BTNode parent;
        public List<BTNode> children = new List<BTNode>();
        private Dictionary<string, object> data = new Dictionary<string, object>();

        public BTNode()
        {
            parent = null;
        }

        public BTNode(List<BTNode> children)
        {
            foreach (BTNode node in children)
            {
                Attach(node);
            }
        }

        private void Attach(BTNode node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public void SetData(string key, object value)
        {
            data[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (data.TryGetValue(key, out value))
                return value;

            //recurssion 
            BTNode node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.parent;
            }
            return null;
            
        }

        public bool ClearData(string key)
        {
            object value = null;
            if (data.ContainsKey(key))
            {
                data.Remove(key);
                return true;
            }

            //recurssion 
            BTNode node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;

        }
    }

    public abstract class Tree : MonoBehaviour
    {
        private BTNode root = null;

        protected void Start()
        {
            root = SetUpTree();
        }

        private void Update()
        {
            if (root != null)
                root.Evaluate();
        }

        protected abstract BTNode SetUpTree();
    }

    public class Sequence : BTNode
    {
        public override NodeState Evaluate()
        {
            bool anyChildRunning = false;
            foreach (BTNode child in children)
            {
                switch (child.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = anyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }

    public class Selector : BTNode
    {
        public override NodeState Evaluate()
        {
            foreach (BTNode child in children)
            {
                switch (child.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }
            state = NodeState.FAILURE;
            return state;
        }
    }
}
