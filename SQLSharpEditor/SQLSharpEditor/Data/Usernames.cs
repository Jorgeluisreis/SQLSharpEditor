using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SQLSharpEditor.Data
{
    class Usernames
    {
        private string UserName
        {
            get;
            
        }
        private string Pass
        {
            get;
            
        }


        public Usernames(string username, string pass)
        {
            UserName = "sql"; ;
            Pass = "sql";
        }

        public bool checarLogin(string _username, string _pass)
        {
            return UserName == _username && Pass == _pass;
        }
    }

}

