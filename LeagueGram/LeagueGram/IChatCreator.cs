using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    interface IChatCreator
    {
        void CreatePrivat();
        void CreateChannel();
        void CreateGroup();
    }
}
