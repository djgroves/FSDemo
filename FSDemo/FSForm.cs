using System;
using System.Windows.Forms;

namespace FSDemo
{
    public partial class FSForm : Form
    {
        private Enterprise enterprise;

        private FSPBXController controller;

        private int nextid = 1;

        private string newid()
        {
            return nextid++.ToString();
        }

        public FSForm()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            enterprise = new Enterprise();
            controller = new FSPBXController(this, enterprise);
            var Agents = enterprise.GetAgents();
            foreach (var a in Agents)
            {
                var item = lvAgents.Items.Add(a);
                item.Name = a;
                item.SubItems.Add(enterprise.GetAgentStateName(a));
                item.SubItems.Add("-");
            }
            enterprise.AgentStateChanged += Enterprise_AgentStateChanged;
            enterprise.NewTask += Enterprise_NewTask;
            enterprise.TaskGone += Enterprise_TaskGone;
            enterprise.TaskChanged += Enterprise_TaskChanged;
        }

        private delegate void logdelegate(string v);

        internal void log(string v)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new logdelegate(log), new object[] { v });
            }
            else
            {
                txtLog.Text = txtLog.Text + v + "\r\n";
            }
        }

        private void Enterprise_TaskChanged(string id, string state, string agentname)
        {
            var items = lvTasks.Items.Find(id, false);
            foreach (var item in items)
            {
                item.SubItems[1].Text = state;
                item.SubItems[2].Text = agentname;
            }
        }

        private void Enterprise_TaskGone(string id)
        {
            var items = lvTasks.Items.Find(id, false);
            foreach (var item in items)
            {
                lvTasks.Items.Remove(item);
            }
        }

        private void Enterprise_NewTask(string id)
        {
            var item = lvTasks.Items.Add(id);
            item.Name = id;
            item.SubItems.Add("Waiting");
            item.SubItems.Add("-");
        }

        private void Enterprise_AgentStateChanged(string name, string state, string taskid)
        {
            var items = lvAgents.Items.Find(name, false);
            foreach (var item in items)
            {
                item.SubItems[1].Text = state;
                item.SubItems[2].Text = taskid;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAgents.SelectedItems)
            {
                enterprise.AgentLogin(item.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAgents.SelectedItems)
            {
                enterprise.AgentAvailable(item.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAgents.SelectedItems)
            {
                enterprise.AgentNotAvailable(item.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAgents.SelectedItems)
            {
                enterprise.AgentComplete(item.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAgents.SelectedItems)
            {
                enterprise.AgentLogout(item.Text);
            }
        }
    }
}
