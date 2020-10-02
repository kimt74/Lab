using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Database database;
        private static List<Data> list_database;
        public MainWindow()
        {
            InitializeComponent();

            database = new Database();
            database.Load("database.db");

            list_database = database.ToList();
            DATAS.ItemsSource = list_database;
        }

        private void DATAS_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction != DataGridEditAction.Commit) return;
            var what_editing = (string)e.Column.Header;

            if (what_editing == "Identifier")
            {
                var Identifier = ((TextBox)e.EditingElement).Text;
                var edited_index = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(e.Row);
                var id_index = database.IndexOf(Identifier.ToUpper());
                //it should be 6 length with first 3 is letter and last 3 is number 
                if (!isAvailableIdentifier(Identifier))
                {
                    MessageBox.Show("Error! Identifier must be 3 letters about airline code + 3 digits.");
                    //list_database.Remove((Data)e.Row.Item);
                    DATAS.CancelEdit();
                    e.Cancel = true;
                }
                else if (id_index != -1)
                {
                    if (id_index != edited_index)
                    {
                        MessageBox.Show("Error! This identifier is already used.");
                        //list_database.Remove((Data)e.Row.Item);
                        DATAS.CancelEdit();
                        e.Cancel = true;
                    } else ((Data)DATAS.SelectedItem).Identifier = Identifier;
                }
                else ((Data)DATAS.SelectedItem).Identifier = Identifier;
            }
            else if (what_editing == "Origin")
            {
                var Origin = ((TextBox)e.EditingElement).Text;
                if (Origin.Length != 4)
                {
                    MessageBox.Show("Error! Origin must be 4 letters.");
                    DATAS.CancelEdit();
                    e.Cancel = true;
                } else ((Data)DATAS.SelectedItem).Origin = Origin;
            }
            else if (what_editing == "Destination")
            {
                var Destination = ((TextBox)e.EditingElement).Text;
                if (Destination.Length != 4)
                {
                    MessageBox.Show("Error! Destination must be 4 letters.");
                    DATAS.CancelEdit();
                    e.Cancel = true;
                } else ((Data)DATAS.SelectedItem).Destination = Destination;
            }
            else if (what_editing == "Passengers")
            {
                var Passengers = ((TextBox)e.EditingElement).Text;
                int int_Passengers;
                if (!int.TryParse(Passengers, out int_Passengers))
                {
                    MessageBox.Show("Error! Passengers must be integer.");
                    DATAS.CancelEdit();
                    e.Cancel = true;
                } else
                    ((Data)DATAS.SelectedItem).Passengers = int_Passengers;
            }
            database = ListToDatabase(list_database);
            database.Save("database.db");
        }

        private bool isAvailableIdentifier(string s)
        {
            if (s.Length != 6 || !char.IsLetter(s[0])
                              || !char.IsLetter(s[1])
                              || !char.IsLetter(s[2])
                              || !char.IsDigit (s[3])
                              || !char.IsDigit (s[4])
                              || !char.IsDigit (s[5])
               )
            {
                return false;
            }
            return true;
        }

        private Database ListToDatabase(List<Data> dblist)
        {
            var db = new Database();
            foreach(var data in dblist)
            {
                db.Add(data);
            }
            return db;
        }

        //Before delete row
        private void DATAS_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Command == DataGrid.DeleteCommand)
            {
                if (MessageBox.Show(String.Format("Would you like to delete {0}?", (grid.SelectedItem as Data).Identifier), "Confirm Delete", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                    e.Handled = true;
                else
                {
                    list_database.Remove(grid.SelectedItem as Data);
                    DATAS.Items.Refresh();
                    database = ListToDatabase(list_database);
                    database.Save("database.db");
                }
            }
        }

        private void DATAS_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var bindingGroup = e.Row.BindingGroup;
                if (bindingGroup != null && bindingGroup.CommitEdit())
                {
                    var item = (Data)e.Row.Item;
                    if (string.IsNullOrWhiteSpace(item.Identifier))
                    {
                        e.Cancel = true;
                        ((DataGrid)sender).CancelEdit();
                    }
                }
            }
        }
    }
}
