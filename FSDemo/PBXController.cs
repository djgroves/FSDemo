using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDemo
{
    public interface PBXController
    {
        bool CheckExtension(string extn);
        bool ConnectCallToExtension(string callid, string extn);
        void Hangup(string callid);
    }
}
