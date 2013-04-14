using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Domain.Entities
{
    public class EasyuiTree
    {
        public EasyuiTree(string id,string text,string state,Hashtable attributes,IList<EasyuiTree> children) {
            this.id = id;
            this.text = text;
            this.state = state;
            this.attributes = attributes;
            this.children = children;
        }
        public string id { get; set; }

        public string text { get; set; }

        public string state { get; set; }

        public Hashtable attributes { get; set; }

        public IList<EasyuiTree> children { get; set; }
    }
}
