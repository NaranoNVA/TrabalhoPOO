using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TrabalhoPOO_ASPNET
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void tornarAbaAtiva(Control itemMenu)
        {
            HtmlGenericControl ativaMenu = new HtmlGenericControl("span");
            HtmlGenericControl ativaMenu2 = new HtmlGenericControl("span");
            ativaMenu.Attributes.Add("class", "mdc-tab-indicator mdc-tab-indicator--active");
            ativaMenu2.Attributes.Add("class", "mdc-tab-indicator__content mdc-tab-indicator__content--underline");
            ativaMenu.Controls.Add(ativaMenu2);

            itemMenu.Controls.Add(ativaMenu);
        }
    }
}