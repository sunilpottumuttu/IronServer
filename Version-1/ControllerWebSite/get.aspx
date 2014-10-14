<%@ Page Language="C#" %>

    
<%
    if (Request.QueryString["by"] == "ws")
    {
        string postedscript = Application["zombiescript"].ToString();
        //postedscript = postedscript.Replace("\r\n", "<br/>");
        Response.Write(postedscript);
    }


    if (Request.QueryString["by"] == "zmb")
    {

        string postedscript = Application["re_zombiescript"].ToString();
        //postedscript = postedscript.Replace("\r\n", "<br/>");
        Response.Write(postedscript);
    }
%>

