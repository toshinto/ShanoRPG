using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptLib;

namespace AbilityIDE
{
    public partial class Form1 : Form
    {

        Dictionary<TreeNode, string> Files;

        public Form1()
        {
            InitializeComponent();
            Files = scenarioView1.LoadScenario(@"D:\Projects\C#\ShanoRPG\Engine\Abilities");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openDialog.RootFolder = Environment.SpecialFolder.
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Files = scenarioView1.LoadScenario(openDialog.SelectedPath);
            }
        }

        private void scenarioView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var n = e.Node;

            if (Files.ContainsKey(n))
            {
                var txt = Files[n];

                richTextBox1.Text = txt;
            }
        }

        ScenarioCompiler compiler = new ScenarioCompiler("wtf we");

        private int lastEdit = 0;

        private async void checkSyntax()
        {

            var ticket = Interlocked.Increment(ref lastEdit);

            await Task.Delay(500);

            if (lastEdit == ticket)
            {
                var result = compiler.CompileFiles(new[] { scenarioView1.SelectedNode.Name }, "kur.dll");

                if (result.Success)
                {

                }
                else
                {
                    foreach (var d in result.Diagnostics)
                    {
                        if (d.Location.IsInSource)
                        {
                            richTextBox1.Select(d.Location.SourceSpan.Start, d.Location.SourceSpan.End);
                            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            checkSyntax();
        }
    }
}
