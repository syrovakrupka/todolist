using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace todolist
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            var db = new SQLiteConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("todoSQLite.db3"));
            db.CreateTable<ToDoItem>();
            db.CreateTable<Categories>();



            if (db.Table<Categories>().Count() == 0)
            {
                var newStock = new Categories() { Name = "nakup" };
                db.Insert(newStock);

            }

            var kokajnus = db.Query<Categories>("SELECT * FROM Categories");

            listView.ItemsSource = kokajnus;



        }


        private void OnItemSelected(object sender, EventArgs e)
        {
            var sendr = ((ListView)sender);

            var skrr = ((Categories)sendr.SelectedItem);

            


            Navigation.PushAsync(new Itemy());
            



            
        }

	}





    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public bool Done { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Categories
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
