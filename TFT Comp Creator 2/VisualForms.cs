using System.Windows.Forms;

namespace TFT_Comp_Creator_2
{
    class VisualForms
    {

        public static void moveData(object data, ListBox From, ListBox To)
        {
            if (data != null)
            {
                int Select = From.SelectedIndex;
                From.Items.Remove(data);
                To.Items.Add(data);

                if (From.Items.Count > Select) { From.SelectedIndex = Select; }
                else if (From.Items.Count == 0) { From.SelectedIndex = -1; }
                else if (From.Items.Count <= Select) { From.SelectedIndex = Select - 1; }

            }
        }
    }
}
