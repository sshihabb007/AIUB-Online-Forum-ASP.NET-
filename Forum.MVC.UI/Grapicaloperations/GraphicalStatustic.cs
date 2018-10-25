using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Newtonsoft.Json;

namespace Forum.MVC.UI.Grapicaloperations
{
    public class GraphicalStatustic
    {
        public String CreateUsersPie(String item1,String Item2, int student,int morderator)
        {
            List<GraphicalView> graphicalViews = new List<GraphicalView>();
            graphicalViews.Add(new GraphicalView(item1, student));
            graphicalViews.Add(new GraphicalView(Item2, morderator));
            return JsonConvert.SerializeObject(graphicalViews);
        }

    }
}