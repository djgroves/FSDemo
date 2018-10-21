using System;

namespace FSDemo
{
    class FormPBXController : PBXController
    {
        private Form1 frm1;
        private Enterprise enterprise;

        public FormPBXController(Form1 form, Enterprise e)
        {
            frm1 = form;
            enterprise = e;
            e.SetPBXController(this);
        }

        public bool CheckExtension(string extn)
        {
            return true;
        }

        public bool ConnectCallToExtension(string callid, string extn)
        {
            return true;
        }

        public void Hangup(string callid)
        {
            return;
        }

        // called by form...
        internal void MakeNewCall(string v)
        {
            enterprise.NewCall(v);
        }

        internal void MakeCallGone(string text)
        {
            enterprise.CallGone(text);
        }
    }
}
