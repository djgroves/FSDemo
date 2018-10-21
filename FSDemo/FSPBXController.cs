using System.IO;
using System.Net.Sockets;

namespace FSDemo
{
    internal class FSPBXController : PBXController
    {
        private FSForm fSForm;
        private Enterprise enterprise;
        private TcpClient client;
        private NetworkStream networkStream;
        private StreamReader clientStreamReader;
        private StreamWriter clientStreamWriter;

        public FSPBXController(FSForm fSForm, Enterprise enterprise)
        {
            this.fSForm = fSForm;
            this.enterprise = enterprise;
            log("FSPBXController Started");
            client = new TcpClient();
            client.Connect("192.168.1.108", 8021);
            networkStream = client.GetStream();
            clientStreamReader = new StreamReader(networkStream);
            clientStreamWriter = new StreamWriter(networkStream);
            log("FSPBXController Connected");
        }

        public bool CheckExtension(string extn)
        {
            throw new System.NotImplementedException();
        }

        public bool ConnectCallToExtension(string callid, string extn)
        {
            throw new System.NotImplementedException();
        }

        public void Hangup(string callid)
        {
            throw new System.NotImplementedException();
        }

        private void log( string v)
        {
            fSForm.log(v);
        }
    }
}