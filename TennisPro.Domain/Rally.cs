using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain.Abstracts;

namespace TennisPro.Domain
{
    public class Rally
    {
        public Player Server { get; set; }
        public Player Winner { get; set; }
        public Game Game { get; set; }
        public string Score { get; set; }
    }
}
