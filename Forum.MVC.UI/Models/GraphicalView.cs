using System;
using System.Runtime.Serialization;

namespace Forum.MVC.UI.Models
{
    [DataContract]
    public class GraphicalView
    {
        public GraphicalView(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }
        [DataMember(Name = "label")]
        //Explicitly setting the name to be used while serializing to JSON.
        public string Label = "";
        [DataMember(Name = "y")]
        //Explicitly setting the name to be used while serializing to JSON.
        public Nullable<double> Y = null;
    }
}