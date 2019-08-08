using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PokemonFightClub
{
    [Activity(Label = "TabLib")]
    public class TabLib : Activity
    {
        Fragment[] _fragmentsArray;
        DBHelper myDbInstance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            this.ActionBar.SetDisplayShowHomeEnabled(false);
            this.ActionBar.SetDisplayShowTitleEnabled(false);
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.mainLib);
            myDbInstance = new DBHelper(this);
            _fragmentsArray = new Fragment[]
            {
                new FirstGeneration(this,myDbInstance),
                new SecondGeneration(this,myDbInstance),

            };

            AddTabToActionBar("First generation"); //First Tab
            AddTabToActionBar("Second generation"); //Second Tab
        }

        void AddTabToActionBar(string tabTitle)
        {
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}