using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Models;

namespace Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Regex.Split()
            //Response.Write(new Cryptogram().Decode("53‡‡†305))6*;4826)4‡."));

            //string value = InputText.Value;
            
            //var test1 ="BostonbN; Bost tonbN, Bo.";

            //var letters = "BostonbN; Bost tonbN, Bo.".Substring(0,2);
            //var chars = Regex.Split(letters, @"\w{2}");
            //letters.ToUpper()
            //    .ToCharArray()
            //    .GroupBy(s => s)
            //    .OrderByDescending(s => s.Count())
            //    .Select((s, i) => new { letter = s.Key, count = s.Count(), index = ++i })
            //    .ToList();

            //string test = string.Empty;

            //Models.Monogram character = new Models.Monogram();
            //string test = character.Decode("BostonbN");
        }
    }
}