using Android.App;
using Android.Widget;
using Android.OS;
using Com.Unnamed.B.Atv.Model;
using Com.Unnamed.B.Atv.View;

namespace XamarinTreeView
{
    [Activity(Label = "XamarinTreeView", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //create root
            TreeNode root = TreeNode.InvokeRoot();
            TreeNode parent = new TreeNode("parent");
            TreeNode child0 = new TreeNode("ChildNode0");
            TreeNode child1 = new TreeNode("ChildNode1");

            TreeItem item = new TreeItem() { text = "abc" };
            TreeNode child10 = new TreeNode(item).SetViewHolder(new MyHolder(this));
            child1.AddChild(child10);
            parent.AddChildren(child0, child1);
            root.AddChild(parent);

            AndroidTreeView atv = new AndroidTreeView(this, root);

            LinearLayout rootlayout = FindViewById<LinearLayout>(Resource.Id.rootlayout);
            rootlayout.AddView(atv.View);

            rootlayout.Invalidate();
        }
    }

    public class TreeItem : Java.Lang.Object
    {
        public string text;
    }
}