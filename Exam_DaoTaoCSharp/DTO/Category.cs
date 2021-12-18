using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Category
    {
        string catID, catName, catDescription;
        bool catStatus;
        //Ctrl+R+E
        public string CatID { get => catID; set => catID = value; }
        public string CatName { get => catName; set => catName = value; }
        public string CatDescription { get => catDescription; set => catDescription = value; }
        public bool CatStatus { get => catStatus; set => catStatus = value; }
    }
}
