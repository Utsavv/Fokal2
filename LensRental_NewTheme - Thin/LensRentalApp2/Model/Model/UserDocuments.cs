using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDocuments
    {
        //public Int32 UserId;
        //public string IdProofType;
        //public string IdUploadPath;
        //public string AddressProofType;
        //public string AddressProofPath;
        //public string PANNumber;
        //public string CompanyId;
        //public string passportsizePhoto;

        public Int32 UserId { get; set; }
        public Int32 DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSubType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
    }
}
