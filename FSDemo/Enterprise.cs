using System;
using System.Collections.Generic;
using System.Threading;

namespace FSDemo
{
    public class Enterprise
    {
        private List<Task> Tasks;
        private Mutex mutex;
        private List<Agent> Agents;
        private PBXController controller;

        public delegate void AgentStateChangedDelegate(string name, string state, string taskid);

        private event AgentStateChangedDelegate agentStateChanged;

        public event AgentStateChangedDelegate AgentStateChanged
        {
            add { agentStateChanged += value; }
            remove { agentStateChanged -= value; }
        }

        public delegate void NewTaskDelegate(string id);
        private event NewTaskDelegate newtask;
        public event NewTaskDelegate NewTask
        {
            add { newtask += value; }
            remove { newtask -= value; }
        }

        public delegate void TaskGoneDelegate(string id);
        private event TaskGoneDelegate taskgone;
        public event TaskGoneDelegate TaskGone
        {
            add { taskgone += value; }
            remove { taskgone -= value; }
        }

        public delegate void TaskChangedDelegate(string id, string state, string agentname);
        private event TaskChangedDelegate taskchanged;
        public event TaskChangedDelegate TaskChanged
        {
            add { taskchanged += value; }
            remove { taskchanged -= value; }
        }

        public Enterprise()
        {
            mutex = new Mutex();
            Tasks = new List<Task>();
            Agents = new List<Agent>();
            Agents.Add(new Agent(this, "Agent1", "1001"));
            Agents.Add(new Agent(this, "Agent2", "1002"));
            Agents.Add(new Agent(this, "Agent3", "1003"));
            Agents.Add(new Agent(this, "Agent4", "1004"));
            Agents.Add(new Agent(this, "Agent5", "1005"));
        }

        public void SetPBXController(PBXController c)
        {
            controller = c;
        }

        public List<string> GetAgents()
        {
            List<string> agents = new List<string>();
            mutex.WaitOne();
            try
            {
                foreach (Agent a in Agents)
                {
                    agents.Add(a.Name);
                }
                return agents;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public string GetAgentStateName(string Name)
        {
            mutex.WaitOne();
            try
            {
                Agent a = findAgent(Name);
                return a.State.ToString();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public void NewCall(string id)
        {
            Task call = new Task(this, id);
            mutex.WaitOne();
            try
            {
                Tasks.Add(call);
                evtNewTask(id);
                allocateTask();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public void CallGone(string id)
        {
            mutex.WaitOne();
            try
            {
                Task t = FindTask(id);
                if (t.Status == TaskStatus.Connected)
                {
                    t.Agent.Task = null;
                    if (t.Agent.NAPending)
                    {
                        t.Agent.State = AgentState.NotAvailable;
                        t.Agent.NAPending = false;
                    }
                    else
                    {
                        t.Agent.State = AgentState.Waiting;
                    }
                }
                Tasks.Remove(t);
                evtTaskGone(t.Id);
                allocateTask();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        private Task FindTask(string id)
        {
            foreach (Task t in Tasks)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            throw new Exception("No such task");
        }

        internal void AgentComplete(string text)
        {
            mutex.WaitOne();
            try
            {
                Agent a = findAgent(text);
                if (a.State != AgentState.Busy)
                {
                    throw new Exception("Agent not on task");
                }
                Task t = a.Task;
                a.Task = null;
                if (a.NAPending)
                {
                    a.State = AgentState.NotAvailable;
                    a.NAPending = false;
                }
                else
                {
                    a.State = AgentState.Waiting;
                }
                controller.Hangup(t.Id);
                Tasks.Remove(t);
                evtTaskGone(t.Id);
                allocateTask();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        // called with mutex locked
        private void allocateTask()
        {
            List<Agent> agents = new List<Agent>();
            foreach (Agent a in Agents)
            {
                if (a.State == AgentState.Waiting)
                {
                    agents.Add(a);
                }
            }
            List<Task> tasks = new List<Task>();
            foreach (Task t in Tasks)
            {
                if (t.Status == TaskStatus.Queuing)
                {
                    tasks.Add(t);
                }
            }
            while (tasks.Count > 0 && agents.Count > 0)
            {
                var task = tasks[0];
                tasks.RemoveAt(0);
                var agent = agents[0];
                agents.RemoveAt(0);
                allocateTaskToAgent(task, agent);
            }
        }

        private void allocateTaskToAgent(Task task, Agent agent)
        {
            controller.ConnectCallToExtension(task.Id, agent.PBXExtension);
            task.Status = TaskStatus.Connected;
            task.Agent = agent;
            agent.Task = task;
            agent.State = AgentState.Busy;
            evtTaskChanged(task.Id, task.Status.ToString(), agent.Name);
            evtAgentStateChanged(agent);
        }

        internal void AgentLogout(string text)
        {
            mutex.WaitOne();
            try
            {
                Agent a = findAgent(text);
                logoutAgent(a);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        private void logoutAgent(Agent a)
        {
            if (a.State != AgentState.NotAvailable)
            {
                throw new Exception("Agent must be NotAvailable");
            }
            a.State = AgentState.NotLoggedIn;
        }

        public void AgentLogin(string Name)
        {
            mutex.WaitOne();
            try
            {
                Agent a = findAgent(Name);
                loginAgent(a);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        // called with mutex locked
        private Agent findAgent(string name)
        {
            foreach (Agent a in Agents)
            {
                if (a.Name == name)
                {
                    return a;
                }
            }
            throw new Exception("No such agent");
        }

        public void AgentAvailable(string Name)
        {
            mutex.WaitOne();
            try
            {
                Agent a = findAgent(Name);
                agentAvailable(a);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public void AgentNotAvailable(string Name)
        {
            mutex.WaitOne();
            try
            {
                Agent a = findAgent(Name);
                agentNotAvailable(a);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        private void agentNotAvailable(Agent a)
        {
            if (a.State == AgentState.Waiting)
            {
                a.State = AgentState.NotAvailable;
                return;
            }
            a.NAPending = true;
        }

        private void agentAvailable(Agent a)
        {

            if (a.State != AgentState.NotAvailable)
            {
                throw new Exception("Agent must be not available");
            }
            a.State = AgentState.Waiting;
            allocateTask();
        }

        // called with mutex locked
        private void loginAgent(Agent a)
        {
            if (a.State != AgentState.NotLoggedIn)
            {
                throw new Exception("Agent is already logged in");
            }
            a.State = AgentState.NotAvailable;
        }

        internal void evtAgentStateChanged(Agent agent)
        {
            agentStateChanged?.Invoke(agent.Name, agent.State.ToString(), agent.Task == null ? "" : agent.Task.Id);
        }

        internal void evtNewTask(string id)
        {
            newtask?.Invoke(id);
        }

        internal void evtTaskGone(string id)
        {
            taskgone?.Invoke(id);
        }

        internal void evtTaskChanged(string id, string state, string agentname)
        {
            taskchanged.Invoke(id, state, agentname);
        }

    }

    public enum TaskStatus
    {
        Queuing,
        Connected
    }

    public class Task
    {
        private Enterprise enterprise;
        public string Id { get; private set; }

        public Agent Agent { get; set; }

        private TaskStatus status;

        public TaskStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Task(Enterprise e, string id)
        {
            enterprise = e;
            Id = id;
            Status = TaskStatus.Queuing;
        }

        internal void Gone()
        {
            throw new NotImplementedException();
        }
    }

    public enum AgentState
    {
        NotLoggedIn,
        NotAvailable,
        Waiting,
        Busy
    }

    public class Agent
    {
        private Enterprise enterprise;

        public string Name
        {
            get; private set;
        }

        private AgentState state;

        public AgentState State
        {
            get
            {
                return state;
            }
            internal set
            {
                state = value;
                stateChanged();
            }
        }

        public string PBXExtension { get; private set; }

        private void stateChanged()
        {
            enterprise.evtAgentStateChanged(this);
        }

        public bool NAPending { get; set; }
        public Task Task { get; internal set; }

        public Agent(Enterprise e, string name, string extn)
        {
            enterprise = e;
            Name = name;
            State = AgentState.NotLoggedIn;
            PBXExtension = extn;
        }
    }
}
