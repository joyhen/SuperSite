using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Model.Arg
{
    public class PArgCommon : IAjaxArg
    {
        public List<Single> ids { get; set; }
    }

    public class Single
    {
        public int id { get; set; }
    }
}