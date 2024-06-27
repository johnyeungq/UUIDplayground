using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
namespace playground
{
    public partial class Form1 : Form
    {
        private void UUIDimportBTN_Click(object sender, EventArgs e)
        {

        }
        public Form1()
        {
            InitializeComponent();
        }
        private void UUIDConvertBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] cellValues = textBox1.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder convertedValues = new StringBuilder();

            foreach (string value in cellValues)
            {
                string convertedValue = ApplyFormula(value);
                convertedValues.AppendLine(convertedValue);
            }

            textBox2.Text = convertedValues.ToString();
        }

        private string ApplyFormula(string value)
        {
            string convertedValue = "";

            if (value.Length == 32)
            {
                // Apply the formula to convert the UUID
                convertedValue = $"{value.Substring(6, 2).ToUpper()}{value.Substring(4, 2).ToUpper()}{value.Substring(2, 2).ToUpper()}{value.Substring(0, 2).ToUpper()}-" +
                    $"{value.Substring(10, 2).ToUpper()}{value.Substring(8, 2).ToUpper()}-" +
                    $"{value.Substring(14, 2).ToUpper()}{value.Substring(12, 2).ToUpper()}-" +
                    $"{value.Substring(16, 4).ToUpper()}-" +
                    $"{value.Substring(20, 12).ToUpper()}";
            }
            else
            {
                convertedValue = "Invalid UUID";
            }

            return convertedValue;
        }

        private string ConvertUuid(string uuid)
        {
            if (uuid.Length != 32)
            {
                // Invalid UUID length
                return "Invalid UUID";
            }

            // Define the positions of hyphens
            int[] hyphenPositions = { 8, 13, 18, 23 };

            // Create a StringBuilder to build the converted UUID
            StringBuilder convertedUuid = new StringBuilder(uuid);

            // Insert hyphens at the specified positions in reverse order
            foreach (int position in hyphenPositions.Reverse())
            {
                convertedUuid.Insert(position, "-");
            }

            return convertedUuid.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
