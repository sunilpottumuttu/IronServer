<%@ Page Language="C#" %>

    
<%
    
    
    
    Response.Write("<fieldset style='border: 3px solid #cccccc;	padding: 5px;font-family: Tahoma, sans-serif;		background-position: bottom right;	background-repeat: no-repeat;'>");
    Response.Write("<legend>Script</legend>");
    string postedscript = Application["zombiescript"].ToString();
    postedscript = postedscript.Replace("\r\n", "<br/>");
    postedscript = postedscript.Replace(" ", "&nbsp;");
    Response.Write(postedscript + "<br/>");
    Response.Write("</fieldset>");

    Response.Write("<fieldset style='border: 3px solid #cccccc;	padding: 5px;font-family: Tahoma, sans-serif;		background-position: bottom right;	background-repeat: no-repeat;'>");
    Response.Write("<legend>Reply</legend>");
    string reply = Application["re_zombiescript"].ToString();
    reply = reply.Replace("\r\n", "<br/>");
    reply = reply.Replace(" ", "&nbsp;");
    Response.Write(reply + "<br/>");
    Response.Write("</fieldset>");
%>

