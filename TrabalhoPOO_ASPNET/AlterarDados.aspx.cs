﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoPOO_ASPNET
{
    public partial class AlterarDados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Atualiza Menu
            ((Index)Master).tornarAbaAtiva(((Index)Master).FindControl("menuAlterar"));
        }
    }
}