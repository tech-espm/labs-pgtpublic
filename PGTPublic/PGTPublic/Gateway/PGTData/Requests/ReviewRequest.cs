using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData.Requests
{
    public class ReviewRequest
    {

        public int ReviewContent { get; set; }
        public int ReviewRelevance { get; set; }
        public int ReviewResearch { get; set; }
        public int ReviewMemorial { get; set; }
        public int ReviewAccording { get; set; }

        public DateTime ReviewDate { get; set; }

        public int FileID { get; set; }

        public int ReviewTypeID { get; set; }

        public List<string> Comments { get; set; }

        public int UserID { get; set; }

    }
}
